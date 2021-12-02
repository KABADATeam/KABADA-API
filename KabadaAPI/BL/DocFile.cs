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
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_keyValProp", null);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_custRel", null);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_channels", null);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_custSeg", null);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_costFixed", null);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_costVariable", null);
                    fillTextFieldMultiLine(bms, bme, "kabada_bc_revenue", null);
                    //
                    //fillPlanTextFieldWrapped(bms,bme, "kabada_bc_prod",plan.descriptionPropostion)
                    //fillProductsTable(body);

                }
                stream.Close();
            }
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
        //private void fillProductsTable(Body body)
        //{
        //    var products = new PlanProducts();
        //    products.read(context, plan.Id);
        //    var b_vp_table = getDocTable("kabada_valuePropositions", body);
        //    //TableRow b_vp_row = b_vp_table.Elements<TableRow>().Last();
        //    if (b_vp_table != null)
        //    {
        //        foreach (var p in products?.products)
        //        {
        //            b_vp_table.Append(new TableRow(new TableCell(new Paragraph(new Run(new Text(p.name))))
        //                                          , new TableCell(new Paragraph(new Run(new Text(p.product_type))))
        //                                          , new TableCell(new Paragraph(new Run(new Text(p.price))))
        //                                          , new TableCell(new Paragraph(new Run(new Text(p.value))))
        //                             ));
        //        }
        //    }
        //}
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
        private void fillListField(IEnumerable<BookmarkStart> bookmarkStarts, IEnumerable<BookmarkEnd> bookmarkEnds, string name, List<string> values)
        {
            String value = null;
            var bm = new DocBookmark(context);
            bm.find(bookmarkStarts, bookmarkEnds, name);

            if (bm.bms != null && bm.bme != null)
            {
                var rp = removeBookmarkText(bm.bms, bm.bme);
                if (values != null)
                {
                    var insertElement = bm.bms.Parent.PreviousSibling();
                    addList(values, insertElement);
                }
                bm.bms.Remove();


            }
            fillTextFieldNoData(bookmarkStarts, bookmarkEnds, name, values == null || values.Count == 0 ? value : "");
        }
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
        private void addText(BookmarkStart bms, string value, RunProperties rp)
        {
           // var bmRp = removeBookmarkText(bms, bme);
            //if (rp == null) rp = bmRp;
            var nr = new Run();
            if (rp != null)
                nr.RunProperties = (RunProperties)rp.Clone();
            nr.Append(new Text(value));
            bms.InsertAfterSelf(nr);            
        }
        private void addText(BookmarkStart bms, List<string> value, RunProperties rp, string format=null)
        {
            // var bmRp = removeBookmarkText(bms, bme);
            //if (rp == null) rp = bmRp;
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
            bms.InsertAfterSelf(nr);
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
        
        private void addList(List<string> list, OpenXmlElement elem)
        {
            int i = 0;
            foreach (string l in list)
            {
                //Adding the bulleted list dynamically 
                i++;
                Paragraph np = new Paragraph
                    (new ParagraphProperties(
                        new NumberingProperties(
                           new NumberingLevelReference() { Val = 1 },
                           new NumberingId() { Val = i })),
                           new Run(
                            new RunProperties(),
                            new Text(l) { Space = SpaceProcessingModeValues.Preserve }));
                if (elem.Parent != null)
                    elem.InsertAfterSelf(np);
                else
                    elem.Append(np);
                elem = np;
            }            
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
