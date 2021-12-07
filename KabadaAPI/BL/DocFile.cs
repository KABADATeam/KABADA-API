using System.IO;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using KabadaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Path = System.IO.Path;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
using TableCell = DocumentFormat.OpenXml.Wordprocessing.TableCell;
using TableRow = DocumentFormat.OpenXml.Wordprocessing.TableRow;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using RunProperties = DocumentFormat.OpenXml.Wordprocessing.RunProperties;
using ParagraphProperties = DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties;
using DocumentFormat.OpenXml;
using Break = DocumentFormat.OpenXml.Wordprocessing.Break;
using System.Reflection;

namespace Kabada {
  public partial class DocFile {
    public MemoryStream stream;
    public string fileName;

        protected BLontext context;
        protected Guid planId;
        protected BusinessPlanBL plan;
        protected const string NODATASUFFIX = "_nodata";
        protected const string LINEFORMAT = "- {0}";
        protected const string FILETEMPLATE = "Kabada_export.docx";
        protected const string NODATATEXT = "No Data";
        protected const string PLANFILENAMEFORMAT = "Kabada_export_{0}.docx";
        public DocFile(BLontext context) { this.context = context; }
        public DocFile(BLontext context, Guid planId, string templateFile=null, bool saveToDisk=false) { 
            this.context = context; 
            Create(planId, templateFile);
            if (saveToDisk) SaveToDisk();
        }
        internal void Create(Guid planId, string templateFile=null)
        {            
            this.planId = planId;
            var template = getTemplateFromFile(templateFile);

            plan = new BusinessPlansRepository(context).getPlanBLfull(planId, context.userGuid);     //BusinessPlanBL 
            if (plan.o.Id == Guid.Empty) throw new Exception("Plan not found");
            plan.textSupport = new TexterRepository(context);
            setDefaultFileName();
            using (stream = new MemoryStream())
            {
                stream.Write(template, 0, (int)template.Length);

                using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
                {
                    Body body = doc.MainDocumentPart.Document.Body;
                    var bms = body.Descendants<BookmarkStart>();
                    var bme = body.Descendants<BookmarkEnd>();
                    fillPlanImage(doc.MainDocumentPart);                    
                    //Title page
                    fillTextField(bms,bme, "kabada_planName", plan.o.Title);
                    fillTextField(bms, bme, "kabada_naceCode", plan.naceCode); 
                    //Business Canvas Page
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_keyDist", plan.keyDist);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_keySupp", plan.keySupp);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_keyAct", plan.namesActivities);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_keyRes", plan.keyRes);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_keyValProp", plan.valProp);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_custRel", plan.custRel);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_channels", plan.channels);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_custSeg", plan.custSeg);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_costFixed", plan.costFixed);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_costVariable", plan.costVariable);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_revenue", plan.revenue);
                    fillObject(bms, bme, "kabada_valProps", plan.valProps);
                    fillTable<ConsumerSegment_doc>(body, "kabada_cs_consumerTable", plan.custSeG.consumer);
                    fillTable<BusinessSegment_doc>(body, "kabada_cs_businessTable", plan.custSeG.business);
                    //
                    //fillPlanTextFieldWrapped(bms,bme, "kabada_bc_prod",plan.descriptionPropostion)
                    //fillProductsTable(body);

                }
                stream.Close();
            }
        }

        private void fillObject(IEnumerable<BookmarkStart> bookmarkStarts, IEnumerable<BookmarkEnd> bookmarkEnds, string name, List<ValueProp_doc> values)
        {
            String value = null;
            var bm = new DocBookmark(context);
            bm.find(bookmarkStarts, bookmarkEnds, name);

            if (bm.bms != null && bm.bme != null)
            {
                var rp = removeBookmarkText(bm.bms, bm.bme);

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
            fillTextFieldNoData(bookmarkStarts, bookmarkEnds, name, values == null || values.Count == 0 ? value : "");
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
        private void fillTable<T>(Body body, string name, List<T> list)
        {            
            var t = getDocTable(name, body);
            fillTableBody<T>(t, list);
           
        }
        private void fillTableBody<T>(Table t, List<T> list)
        {
            if (t != null)
            {
                var tcPr = t.GetFirstChild<TableRow>().GetFirstChild<TableCell>().TableCellProperties;
                foreach (var l in list)
                {
                    var tr = new TableRow();
                    foreach (FieldInfo prop in typeof(T).GetFields())
                    {
                        var tc = new TableCell();
                        tc.Append(tcPr.Clone());
                        tc.Append(new Paragraph(new Run(new Text(prop.GetValue(l)?.ToString()))));
                        tr.Append(tc);
                    }
                    if(tr.LastChild!=null)
                        t.Append(tr);                   
                }
            }
        }

            private void fillTextFieldMultiLine(IEnumerable<BookmarkStart> bookmarkStarts, IEnumerable<BookmarkEnd> bookmarkEnds, string name, List<string> values)
        {
            String value = null;
            var bm = new DocBookmark(context);
            bm.find(bookmarkStarts, bookmarkEnds, name);
            
            if (bm.bms != null&&bm.bme != null)   {
               var rp = removeBookmarkText(bm.bms, bm.bme);
               if (values != null)
                {
                    addText(bm.bms, values, rp,LINEFORMAT);                    
                }
                bm.bms.Remove();                                   
            }
            fillTextFieldNoData(bookmarkStarts, bookmarkEnds, name,values==null||values.Count==0?value:"");            
        }
        private void fillTextFieldMultiLine(IEnumerable<BookmarkStart> bookmarkStarts, IEnumerable<BookmarkEnd> bookmarkEnds, string name, List<KeyValuePair<string,List<string>>> values)
        {
            String value = null;
            var bm = new DocBookmark(context);
            bm.find(bookmarkStarts, bookmarkEnds, name);

            if (bm.bms != null && bm.bme != null)
            {
                var rp = removeBookmarkText(bm.bms, bm.bme);
                
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
            fillTextFieldNoData(bookmarkStarts, bookmarkEnds, name, values == null || values.Count == 0 ? value : "");
        }

        private void fillTextFieldNoData(IEnumerable<BookmarkStart> bookmarkStarts, IEnumerable<BookmarkEnd> bookmarkEnds, string name, string value=null)
            {      
                fillTextField(bookmarkStarts, bookmarkEnds, name + NODATASUFFIX, value==null?NODATATEXT:value);
            }
        private void fillTextField(IEnumerable<BookmarkStart> bookmarkStarts, IEnumerable<BookmarkEnd> bookmarkEnds, string name, string value)
            {
                var bm = new DocBookmark(context);
                bm.find(bookmarkStarts, bookmarkEnds, name);

                if (bm.bms != null && bm.bme != null)
                {
                    var rp = removeBookmarkText(bm.bms, bm.bme);
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
        private RunProperties removeBookmarkText(BookmarkStart bms, BookmarkEnd bme)
        {
            var rProp = bms.Parent.Descendants<Run>().Where(rp => rp.RunProperties != null).Select(rp => rp.RunProperties).FirstOrDefault();
            if (bms.PreviousSibling() == null && bme.ElementsAfter().Count(e => e.GetType() == typeof(Run)) == 0)
            {
                bms.Parent.RemoveAllChildren();
            }
            else
            {
                var list = bms.ElementsAfter().Where(r => r.IsBefore(bme)).ToList();
                var trRun = list.Where(rp => rp.GetType() == typeof(Run) && ((Run)rp).RunProperties != null).Select(rp => ((Run)rp).RunProperties).FirstOrDefault();
                if (trRun != null)
                    rProp = (RunProperties)trRun.Clone();
                for (var n = list.Count(); n > 0; n--)
                    list[n - 1].Remove();
            }
            return rProp;
        }
        private Run addText(OpenXmlElement elem, string value, RunProperties rp, string format = null, bool endBreak=false, bool tabChar=false)
        {
           // var bmRp = removeBookmarkText(bms, bme);
            //if (rp == null) rp = bmRp;
            var nr = new Run();
            if (tabChar) nr.Append(new TabChar());
            if (rp != null)
                nr.RunProperties = (RunProperties)rp.Clone();
            if (!String.IsNullOrEmpty(format)) value = String.Format(format, value);
            nr.Append(new Text(value));
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
        
        private void replaceBookmarkText(BookmarkStart bms, BookmarkEnd bme, string value, RunProperties rp = null)
        {
            var bmRp = removeBookmarkText(bms, bme);
            if (rp == null) rp = bmRp;
            addText(bms, value, rp);
        }

        private void fillPlanImage(MainDocumentPart mainDocPart)
        {
            if (plan.o.Img != null)
            {
                var imageId = getPlanImageId(mainDocPart);
                if (!String.IsNullOrEmpty(imageId))
                {
                    var imgContent = new UserFilesRepository(context, new DAcontext(context.config, context.logger)).byId(plan.o.Img.Value).Content;
                    ImagePart imagePart = (ImagePart)mainDocPart.GetPartById(imageId);
                    BinaryWriter writer = new BinaryWriter(imagePart.GetStream());
                    writer.Write(imgContent);
                    writer.Close();
                }
            }
        }
        private string getPlanImageId(MainDocumentPart mainDocPart)
        {            
            var blip = GetBlipForPicture("businessPlan.jpg", mainDocPart.Document);
            if (blip != null)
                return blip.Embed.Value;
            return null;            
        }
        private Blip GetBlipForPicture(string picName, Document document)
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
