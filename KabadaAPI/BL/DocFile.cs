using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using Path = System.IO.Path;
using DocumentFormat.OpenXml;
using System.Reflection;

namespace Kabada {
  public partial class DocFile {
    public MemoryStream stream;
    public string fileName;

        protected BLontext context;
        protected Guid planId;
        protected BusinessPlanBL plan;
        protected MainDocumentPart mainDoc;
        protected IEnumerable<BookmarkStart> bookmarkStarts;
        protected IEnumerable<BookmarkEnd> bookmarkEnds;

        protected const string NODATASUFFIX = "_nodata";
        protected const string LINEFORMAT = "- {0}";
        protected const string FILETEMPLATE = "Kabada_export.docx";
        protected const string NODATATEXT = "No Data";
        protected const string PLANFILENAMEFORMAT = "Kabada_export_{0}.docx";
        protected Dictionary<byte, string> risksValues = new Dictionary<byte, string>() { {1,"High"},{2,"Medium"},{3,"Low"} };
        public DocFile(BLontext context) { this.context = context; }
        public DocFile(BLontext context, Guid planId, string templateFile=null, bool saveToDisk=false, List<string> images=null) { 
            this.context = context; 
            Create(planId, templateFile, images);
            if (saveToDisk) SaveToDisk();
        }
        internal void Create(Guid planId, string templateFile=null, List<string> images=null)
        {            
            this.planId = planId;
            var template = getTemplateFromFile(templateFile);

            plan = new BusinessPlansRepository(context).getPlanBLfull(planId, context.userGuid);     //BusinessPlanBL 
            if (plan.o.Id == Guid.Empty) throw new Exception("Plan not found");
            plan.textSupport = new TexterRepository(context);
            setDefaultFileName();
            var r = new IndustryRiskS();
            if(plan.activity!=null)
                r.read(context, plan.activity.Id);
            using (stream = new MemoryStream())
            {
                stream.Write(template, 0, (int)template.Length);

                using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
                {
                    Body body = doc.MainDocumentPart.Document.Body;
                    mainDoc = doc.MainDocumentPart;
                    bookmarkStarts = body.Descendants<BookmarkStart>();
                    bookmarkEnds = body.Descendants<BookmarkEnd>();
                    fillPlanImage();                    
                    //Title page
                    fillTextField("kabada_planName", plan.o.Title);
                    fillTextField("kabada_naceCode", plan.naceCode); 
                    //Business Canvas Page
                    fillTextFieldMultiLine("kabada_bc_keyDist", plan.keyDist, true);
                    fillTextFieldMultiLine("kabada_bc_keySupp", plan.keySupp, true);
                    fillTextFieldMultiLine("kabada_bc_keyAct", plan.namesActivities, true);
                    fillTextFieldMultiLine("kabada_bc_keyRes", plan.keyRes, true);
                    fillTextFieldMultiLine("kabada_bc_keyValProp", plan.valProp, true);
                    fillTextFieldMultiLine("kabada_bc_custRel", plan.custRel, true);
                    fillTextFieldMultiLine("kabada_bc_channels", plan.channels, true);
                    fillTextFieldMultiLine("kabada_bc_custSeg", plan.custSeg, true);
                    fillTextFieldMultiLine("kabada_bc_costFixed", plan.costFixed, true);
                    fillTextFieldMultiLine("kabada_bc_costVariable", plan.costVariable, true);
                    fillTextFieldMultiLine("kabada_bc_revenue", plan.revenue, true);
                    fillObject("kabada_valProps", plan.valProps);
                    fillTable<ConsumerSegment_doc>("kabada_cs_consumerTable", plan.custSeG.consumer);
                    fillTable<BusinessSegment_doc>("kabada_cs_businessTable", plan.custSeG.business);
                    fillTable<PublicSegment_doc>("kabada_cs_publicTable", plan.custSeG.publicNgo);
                    fillTable<Channel_doc>("kabada_channels", plan.channelS);
                    fillTable<CustRelElement_doc>("kabada_cr_getCust", plan.CustomerRelationship.getCust);
                    fillTable<CustRelElement_doc>("kabada_cr_keepCust", plan.CustomerRelationship.keepCust);
                    fillTable<CustRelElement_doc>("kabada_cr_convCust", plan.CustomerRelationship.convCust);
                    fillTable<RevenueStreamElement_doc>("kabada_rs_consumer", plan.revenuE.consumer);
                    fillTable<RevenueStreamElement_doc>("kabada_rs_business", plan.revenuE.business);
                    fillTable<RevenueStreamElement_doc>("kabada_rs_public", plan.revenuE.publicNgo);
                    fillTable<KeyRes_doc>("kabada_keyResources", plan.keyResources);
                    fillObject("kabada_keyActivities", plan.keyActivities);
                    fillTable<KeyPartnersElement_doc>("kabada_kp_dist", plan.keyPartners.distributors);
                    fillTable<KeyPartnersElement_doc>("kabada_kp_supp", plan.keyPartners.suppliers);
                    fillTable<KeyPartnersElement_doc>("kabada_kp_other", plan.keyPartners.others);
                    fillTable<CostElement_doc>("kabada_fixedCost", plan.Costs.fixedCosts);
                    fillTable<CostElement_doc>("kabada_variableCost", plan.Costs.variableCosts);
                    fillTextFieldMultiLine("kabada_swot_s", plan.Swot.strengths);
                    fillTextFieldMultiLine("kabada_swot_w", plan.Swot.weaknesses);
                    fillTextFieldMultiLine("kabada_swot_o", plan.Swot.opportunities);
                    fillTextFieldMultiLine("kabada_swot_t", plan.Swot.threats);
                    //fillIndustryDataImages(images);
                    fillObject("kabada_industryRisks", r.risks);

                }
                stream.Close();
            }
        }

        private void fillObject(string name, List<IndustryRisk> values)
        {
            var bm = new DocBookmark(context);
            bm.find(bookmarkStarts, bookmarkEnds, name);

            if (bm.bms != null && bm.bme != null)
            {
                var rp = removeBookmarkText(bm);
                RunProperties rp_h2 = (RunProperties)rp.Clone();
                rp_h2.Append(new Bold());
                rp_h2.Append(new FontSize() { Val = "36" });
                RunProperties rp_h3 = (RunProperties)rp.Clone();
                rp_h3.Append(new Bold());
                rp_h3.Append(new FontSize() { Val = "28" });
                RunProperties rp_b = (RunProperties)rp.Clone();
                rp_b.Append(new Bold());               
                
                if (values != null)
                {
                    OpenXmlElement elem = bm.bms.Parent;
                    //var insListElem = bm.bms.Parent;
                    var oldCat = "";
                    foreach (var val in values)
                    {
                        var p = new Paragraph();
                        elem.InsertAfterSelf(p);
                        elem = p;
                        var cat = val.category[0].ToString().ToUpper() + val.category.Substring(1).ToLower();
                        if (val.category != oldCat) elem = addText(p, cat, rp_h2, endBreak: true);
                        oldCat = val.category;
                        elem = addText(elem, val.type, rp_h3, endBreak:true);
                        elem = addText(elem, "Likelihood / Severity: ", rp_b);
                        if (val.likelihood != null || val.severity != null)
                            elem = addText(elem, String.Format("{0} / {1}", val.likelihood == null ? "" : risksValues[val.likelihood.Value], val.severity == null ? "":risksValues[val.severity.Value]), addColor(rp_b, val.severity, val.likelihood), endBreak:true);
                        elem = addText(elem, val.comments, rp);                                      
                        elem = addText(elem, String.Format("\u24BE Possible country - specific deviations: {0} - {1}", val.countryDeviationScore, val.countryDeviationComment), addColor(rp,0), endBreak:true );
                    }
                }
                bm.bms.Remove();
            }
        }
        private RunProperties addColor(RunProperties rp, byte? i=null, byte? j=null)
        {
            RunProperties rp_colored = (RunProperties)rp.Clone();
            var k = 100;
            if (i == 0) k = 0;
            else
            if (i != null && j != null) { decimal n = (i.Value + j.Value)/2m;k = n < 2 ? 1 : n==2?(int)n:3; }
            else
            if (i == null && j == null) k = 0;

            switch (k)
            {
                case 0: //light blue
                    rp_colored.Highlight?.Remove();
                    rp_colored.Append(new Shading() { Fill = "E6F7ff" });
                    break;
                case 1: //green
                    rp_colored.Append(new Color() { Val = "c80000" });
                    rp_colored.Highlight?.Remove();
                    rp_colored.Append(new Shading() { Fill = "F4CCCC" });
                    
                    break;
                case 2: //yellow
                    rp_colored.Append(new Color() { Val = "B45F06" });
                    rp_colored.Highlight?.Remove();
                    rp_colored.Append(new Shading() { Fill = "ffe599" });
                    break;
                case 3: //red
                    rp_colored.Append(new Color() { Val = "3F6600" });
                    rp_colored.Highlight?.Remove();
                    rp_colored.Append(new Shading() { Fill = "B7EB8F" });
                    break;
                }
           
            return rp_colored;
        }

        private void fillObject(string name, List<KeyValuePair<string, List<KeyAct_doc>>> values)
        {
            var t = getDocTable(name, mainDoc.Document.Body);
            removeTableBookmark(name);
            if (t != null)
            {
                Table temp_t = (Table)t.Clone();
                Table cur_t = t;
                var i = 0;
                foreach (var v in values)
                {
                    i++;                   
                        fillTableBody<KeyAct_doc>(cur_t, v.Value);
                        RunProperties rp_h = new RunProperties();
                        rp_h.Append(new Bold());

                        rp_h.Append(new FontSize() { Val = "28" });
                        var p = new Paragraph();
                        cur_t.InsertBeforeSelf(p);
                    if (i!=1) addText(p, " ", rp_h, endBreak: true);
                        addText(p, v.Key, rp_h, endBreak: true);
                        if (i < values.Count)
                            cur_t = cur_t.InsertAfterSelf((Table)temp_t.Clone());                    
                }                
            }
        }
            private void fillObject(string name, List<ValueProp_doc> values)
        {           
            var bm = new DocBookmark(context);
            bm.find(bookmarkStarts, bookmarkEnds, name);

            if (bm.bms != null && bm.bme != null)
            {
                var rp = removeBookmarkText(bm);

                if (values != null)
                {
                    OpenXmlElement elem = bm.bms.Parent;
                    var insListElem = bm.bms.Parent;

                    foreach (var val in values)
                    {
                        
                        RunProperties rp_h = (RunProperties)rp.Clone();
                        rp_h.Append(new Bold());
                        var rp_n = (RunProperties)rp_h.Clone();
                        rp_h.Append(new FontSize() { Val = "28" });
                        var p = new Paragraph();
                        elem.InsertAfterSelf(p);
                        //elem = addText(elem, "", rp, null, true);
                        elem = addText(p, val.title, rp_h, endBreak: true);
                        elem = addText(elem, ValueProp_doc.t_prodType, rp_n);
                        elem = addText(elem, val.prodType, rp,endBreak: true);
                        elem = addText(elem, ValueProp_doc.t_priceLevel, rp_n);
                        elem = addText(elem, val.priceLevel, rp, endBreak: true);
                        elem = addText(elem, ValueProp_doc.t_addIncomeSource, rp_n);
                        elem = addText(elem, val.addIncomeSource, rp,endBreak:true);
                        elem = addText(elem, ValueProp_doc.t_productFeatures, rp_n);
                        insListElem = p;
                        elem = addList(insListElem, val.productFeatures);
                        p = new Paragraph();
                        elem.InsertAfterSelf(p);
                        elem = addText(p, ValueProp_doc.t_summary, rp_n);
                        var summary = new List<string>() { ValueProp_doc.t_price+val.priceLevel,
                        ValueProp_doc.t_innov+val.innovLevel,
                        ValueProp_doc.t_qual+val.qualityLevel,
                        ValueProp_doc.t_diff+val.diffLevel};
                        elem = addList(p, summary);
                        p = new Paragraph();
                        elem.InsertAfterSelf(p);
                        elem = addText(p, "", rp, null, true);
                    }
                }
                bm.bms.Remove();
            }
            //fillTextFieldNoData(name, values == null || values.Count == 0 ? value : "");
        }

        internal void SaveToDisk() {
            if (String.IsNullOrEmpty(fileName)) throw new Exception("No filename parameter");
            if (File.Exists(fileName)) throw new Exception(String.Format("File {0} already exists",fileName));
            System.IO.File.WriteAllBytes(fileName, stream.ToArray());            
        }
        private byte[] getTemplateFromFile(string fn)
        {
            if (String.IsNullOrEmpty(fn)) fn = FILETEMPLATE;
            var dir = Path.GetDirectoryName(fn);
            var tmpFile = "";
            if (String.IsNullOrEmpty(dir))
            {
                dir = new BusinessPlansRepository(context).iniPath;
                tmpFile = Path.Combine(dir, fn); 
            }
            else tmpFile = fn;
            return System.IO.File.ReadAllBytes(tmpFile);
        }
        private void setDefaultFileName() { 
            if(String.IsNullOrEmpty(fileName)) fileName = String.Format(PLANFILENAMEFORMAT, plan.o.Title); }
        private Table getDocTable(string bookmark, Body body)
        {
            return body.Descendants<Table>().Where(tbl => tbl.InnerXml.Contains(bookmark)).FirstOrDefault();
        }
        private void removeTableBookmark(string name)
        {
            var bm = new DocBookmark(context);
            bm.find(bookmarkStarts, bookmarkEnds, name);

            if (bm.bms != null && bm.bme != null)
                bm.bms.Remove();
        }
        private void fillTable<T>(string name, List<T> list)
        {            
            var t = getDocTable(name, mainDoc.Document.Body);
            fillTableBody<T>(t, list);
            removeTableBookmark(name);
        }
        private void fillTableBody<T>(Table t, List<T> list)
        {
            if (t != null)
            {
                var tcPr = t.GetFirstChild<TableRow>().GetFirstChild<TableCell>().TableCellProperties;
                if (list==null || list.Count == 0)
                {
                    var tr = new TableRow();
                    foreach (FieldInfo prop in typeof(T).GetFields())
                    {
                        fillTableCell(tr, "", (TableCellProperties)tcPr.Clone());
                    }
                    t.Append(tr);
                }
                else
                {
                    foreach (var l in list)
                    {
                        var tr = new TableRow();
                        foreach (FieldInfo prop in typeof(T).GetFields())
                        {
                            fillTableCell(tr, prop.GetValue(l)?.ToString(), (TableCellProperties)tcPr.Clone(),isLink(prop.Name));
                        }
                        if (tr.LastChild != null)
                            t.Append(tr);
                    }
                }
            }
        }
        private bool isLink(string value) { 
            var list = new List<string>() {"Website", "web" };
            return list.Contains(value);
        }
        private void fillTableCell(TableRow tr, string value, TableCellProperties tcPr=null, bool ifLink=false)
        {
            var tc = new TableCell();
            if (tcPr != null) tc.Append(tcPr);
            var p = new Paragraph();
            tc.Append(p);

            if (ifLink) { fillHyperLink(value,value,p); }
            else
            {
                var r = new Run();
                r.Append(new Text(value));
                var rPr = new RunProperties();
                rPr.Append(new RunFonts { Ascii = "Arial", HighAnsi = "Arial" });
                rPr.Append(new FontSize { Val = new StringValue("21") });
                r.PrependChild(rPr);
                p.Append(r);
            }

            
           
            tr.Append(tc);
        }
        private void fillHyperLink(string title, string url, OpenXmlElement elem)
        {
            try
            {          
                var rel = mainDoc.AddHyperlinkRelationship(new UriBuilder(url).Uri, true);

                // Append the hyperlink with formatting.
                elem.AppendChild(
                    new Hyperlink(
                        new Run(
                            new RunProperties(
                                // This should be enough if starting with a template
                                new RunStyle { Val = "Hyperlink", },
                                // Add these settings to style the link yourself
                                new Underline { Val = UnderlineValues.Single },
                                new Color { ThemeColor = ThemeColorValues.Hyperlink }),
                            new Text { Text = title }
                        ))
                    { History = OnOffValue.FromBoolean(true), Id = rel.Id });
            }
            catch (Exception e)
            {
                context.logWarning(e.Message);
                context.logWarning("Text field is created instead of hyperlink!");
                elem.AppendChild(new Run(new Text { Text = title }));
            }
        }
            private void fillTextFieldMultiLine(string name, List<string> values, bool noDataLabel=false)
        {
            String value = null;
            var bm = new DocBookmark(context);
            bm.find(bookmarkStarts, bookmarkEnds, name);
            
            if (bm.bms != null&&bm.bme != null)   {
               var rp = removeBookmarkText(bm);
               if (values != null)
                {
                    addText(bm.bms, values, rp,LINEFORMAT);                    
                }
                bm.bms.Remove();                                   
            }
            if(noDataLabel)
                fillTextFieldNoData(name,values==null||values.Count==0?value:"");            
        }
        private void fillTextFieldMultiLine(string name, List<KeyValuePair<string,List<string>>> values, bool noDataLabel=false)
        {
            String value = null;
            var bm = new DocBookmark(context);
            bm.find(bookmarkStarts, bookmarkEnds, name);

            if (bm.bms != null && bm.bme != null)
            {
                var rp = removeBookmarkText(bm);
                
                if (values != null)
                {
                    OpenXmlElement elem = bm.bms;
                    foreach (var val in values)
                    {
                        RunProperties rp_h = (RunProperties)rp.Clone();
                        rp_h.Append(new Bold());
                        elem = addText(elem, val.Key, rp_h, endBreak:true);
                        elem = addText(elem, val.Value, rp, LINEFORMAT,true);
                    }
                }
                bm.bms.Remove();
            }
            if(noDataLabel)
                fillTextFieldNoData(name, values == null || values.Count == 0 ? value : "");
        }

        private void fillTextFieldNoData(string name, string value=null)
            {      
                fillTextField(name + NODATASUFFIX, value==null?NODATATEXT:value);
            }
        private void fillTextField(string name, string value)
            {
                var bm = new DocBookmark(context);
                bm.find(bookmarkStarts, bookmarkEnds, name);

                if (bm.bms != null && bm.bme != null)
                {
                    var rp = removeBookmarkText(bm);
                    if(!String.IsNullOrEmpty(value)) addText(bm.bms, value, rp);
                    bm.bms.Remove();
                }                   
            }
        //private void fillListField(IEnumerable<BookmarkStart> bookmarkStarts, IEnumerable<BookmarkEnd> bookmarkEnds, string name, List<string> values)
        //{
        //    String value = null;
        //    var bm = new DocBookmark(context);
        //    bm.find(bookmarkStarts, bookmarkEnds, name);

        //    if (bm.bms != null && bm.bme != null)
        //    {
        //        var rp = removeBookmarkText(bm.bms, bm.bme);
        //        if (values != null)
        //        {
        //            var insertElement = bm.bms.Parent.PreviousSibling();
        //            addList(insertElement, values);
        //        }
        //        bm.bms.Remove();


        //    }
        //    fillTextFieldNoData(bookmarkStarts, bookmarkEnds, name, values == null || values.Count == 0 ? value : "");
        //}
        private RunProperties removeBookmarkText(DocBookmark bm)
        {
            var rProp = bm.bms.Parent.Descendants<Run>().Where(rp => rp.RunProperties != null).Select(rp => rp.RunProperties).FirstOrDefault();
            if (bm.bms.PreviousSibling() == null && bm.bme.ElementsAfter().Count(e => e.GetType() == typeof(Run)) == 0)
            {
                bm.bms.Parent.RemoveAllChildren();
            }
            else
            {
                var list = bm.bms.ElementsAfter().Where(r => r.IsBefore(bm.bme)).ToList();
                var trRun = list.Where(rp => rp.GetType() == typeof(Run) && ((Run)rp).RunProperties != null).Select(rp => ((Run)rp).RunProperties).FirstOrDefault();
                if (trRun != null)
                    rProp = (RunProperties)trRun.Clone();
                for (var n = list.Count(); n > 0; n--)
                    list[n - 1].Remove();
            }
            return rProp;
        }
        private Run addText(OpenXmlElement elem, string value, RunProperties rp, string format = null, bool endBreak=false, bool tabChar=false,  HexBinaryValue ch=null)
        {
           // var bmRp = removeBookmarkText(bms, bme);
            //if (rp == null) rp = bmRp;
            var nr = new Run();
            if (tabChar) nr.Append(new TabChar());
            if (rp != null)
                nr.RunProperties = (RunProperties)rp.Clone();
            if (!String.IsNullOrEmpty(format)) value = String.Format(format, value);
            if (ch!=null)
               nr.Append(new SymbolChar() { Char=ch });
            nr.Append(new Text(){Text = value, Space = SpaceProcessingModeValues.Preserve });
            if (endBreak) nr.Append(new Break());
            if ((elem.Parent == null) || (elem.GetType() == typeof(Paragraph)))
                elem.Append(nr); 
            else
                elem.InsertAfterSelf(nr);
            return nr;
        }
        private Run addText(OpenXmlElement elem, List<string> value, RunProperties rp, string format=null, bool endBreak=false)
        {
            var nr = new Run();
            if (rp != null)
                nr.RunProperties = (RunProperties)rp.Clone();
            foreach (var v in value)
            {
                var line = v;
                if (!String.IsNullOrEmpty(format)) line = String.Format(format, v);
                nr.Append(new Text(line));
                if(v!=value.Last()) nr.Append(new Break());               
            }
            if (endBreak) nr.Append(new Break());
            if ((elem.Parent == null) || (elem.GetType() == typeof(Paragraph)))
                elem.Append(nr);
            else
                elem.InsertAfterSelf(nr);
            return nr;
        }

        //private void replaceBookmarkText(DocBookmark bm, string value, RunProperties rp = null)
        //{
        //    var bmRp = removeBookmarkText(bm);
        //    if (rp == null) rp = bmRp;
        //    addText(bm.bms, value, rp);
        //}
        private void fillIndustryDataImages(List<string> images)
        {
            if (images != null)
            {
                if (!String.IsNullOrEmpty(images[0])) {
                    var imageId = getImageId("rate.png");
                    if (!String.IsNullOrEmpty(imageId))
                    {
                        var imgContent = Convert.FromBase64String(images[0]);
                        fillImage(imgContent, imageId);
                    }
                }
                if (!String.IsNullOrEmpty(images[1]))
                {
                    var imageId = getImageId("summary.png");
                    if (!String.IsNullOrEmpty(imageId))
                    {
                        var imgContent = Convert.FromBase64String(images[1]);
                        fillImage(imgContent, imageId);
                    }
                }
            }
        }
        private void fillPlanImage()
        {
            if (plan.o.Img != null)
            {
                var imageId = getImageId("businessPlan.jpg");
                if (!String.IsNullOrEmpty(imageId))
                {
                    var imgContent = new UserFilesRepository(context, new DAcontext(context.config, context.logger)).byId(plan.o.Img.Value).Content;
                    fillImage(imgContent, imageId);
                }
            }
        }
        private void fillImage(byte[] imgContent, string imageId)
        {
            ImagePart imagePart = (ImagePart)mainDoc.GetPartById(imageId);
            BinaryWriter writer = new BinaryWriter(imagePart.GetStream());
            writer.Write(imgContent);
            writer.Close();
        }
        private string getImageId(string imgName)
        {            
            var blip = GetBlipForPicture(imgName, mainDoc.Document);
            if (blip != null)
                return blip.Embed.Value;
            return null;            
        }
        private DocumentFormat.OpenXml.Drawing.Blip GetBlipForPicture(string picName, Document document)
        {
            return document.Descendants<DocumentFormat.OpenXml.Drawing.Pictures.Picture>()
                 .Where(p => picName == p.NonVisualPictureProperties.NonVisualDrawingProperties.Name)
                 .Select(p => p.BlipFill.Blip)
                 .FirstOrDefault();
        }
        
        private OpenXmlElement addList(OpenXmlElement elem,List<string> list)
        {
            int i = 0;
            foreach (string l in list)
            {
                //Adding the bulleted list dynamically 
                i++;
                Paragraph np = new Paragraph
                    (new ParagraphProperties(
                        new NumberingProperties(
                           new NumberingLevelReference() { Val = 0 },
                           new NumberingId() { Val = 4 })),
                           new Run(
                            new RunProperties(),
                            new Text(l) { Space = SpaceProcessingModeValues.Preserve }));
                if (elem.Parent != null)
                    elem.InsertAfterSelf(np);
                else
                    elem.Append(np);
                elem = np;
            }
            return elem;
        }
        public byte[] ToPdf()
        {
            if (stream==null) return null;
            var p = new BusinessPlanBL();            
            p.textSupport = new TexterRepository(context);                        
            var fn = p.filePath("_Kabada_export.docx"); //temp file name
            System.IO.File.WriteAllBytes(fn, stream.ToArray()); //write to file on disk
            SofficeManager.ConvertToPDF(context, fn);
            var fnPdf = Path.ChangeExtension(fn, ".pdf");
            var temp = System.IO.File.ReadAllBytes(fnPdf);
            File.Delete(fn);
            File.Delete(fnPdf);
            return temp;
        }
    }
  }
