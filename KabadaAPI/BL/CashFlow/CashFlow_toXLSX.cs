using System;
using System.Collections.Generic;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using X14 = DocumentFormat.OpenXml.Office2010.Excel;
using X15 = DocumentFormat.OpenXml.Office2013.Excel;


namespace Kabada {
  partial class CashFlow {
    //---------------------- entry points -------------------------------//
    public void createExcelFile(string fileFullname, short years=1) {
      //var t=createExcelFile(years);
      
      // using (var fs = new FileStream(fileFullname+".FST.xlsx", FileMode.Create, FileAccess.Write))
      //   fs.Write(t, 0, t.Length);


      xYears=years;
      using (var doc = SpreadsheetDocument.Create(fileFullname, SpreadsheetDocumentType.Workbook)){
        createPartsForExcel(doc, "CashFlow");
        generateWorksheetPartContent(worksheetPart, generateSheetdataForDetails());
        workbookPart.Workbook.Save();
        doc.Close(); 
        }
      }

    //    public byte[] createExcelFile(short years=1) {
    //      xYears=years;

    //      byte[] result = null;
    //      //byte[] templateBytes = System.IO.File.ReadAllBytes(wordTemplate);
    //      using (var templateStream = new MemoryStream()) {
    //      //    templateStream.Write(templateBytes, 0, (int)templateBytes.Length);
    //        using (var doc = SpreadsheetDocument.Open(templateStream, true)) {
    //          createPartsForExcel(doc); 
    ////        MainDocumentPart mainPart = doc.MainDocumentPart;           
    ////        ...         
    ////        mainPart.Document.Save();
    ////        templateStream.Position = 0;
    //          using (MemoryStream memoryStream = new MemoryStream()) {
    //            templateStream.CopyTo(memoryStream);
    //            result = memoryStream.ToArray();
    //            }
    //          }
    //        }
    //      return result;
    //      }

    //---------------------- locals -------------------------------//
    private short xYears;
    private WorkbookPart workbookPart;
    private WorksheetPart worksheetPart;

    //---------------------- this xlsx specific -------------------------------//
    private List<string> headers { get {
      var r=new List<string>{ "Title", "0" };
      for(var y=1; y<=xYears; y++){
        var of=(y-1)*12;
        for(var m=1; m<=12; m++)
          r.Add((of+m).ToString());
        r.Add($"Total (Year {y})");
        }
      return r;
      }}

    private Row createHeaderRow(SheetData sheet) { return createHeaderRow(sheet, headers); } 

    protected void addRow(SheetData sheet, CashFlowRow row=null){
      var w =createRow(sheet);
      createCell(w, row.title);
      createCell(w, row.mv(0));
      for(var y=1; y<=xYears; y++){
        var of=(y-1)*12;
        for(var m=1; m<=12; m++)
          createCell(w, row.mv(of+m));
        createCell(w, row.yv(y));
        }
      }

    private void addRows(SheetData sheet, CashFlowTable table) {
      if(table==null)
        return;
      if(table.title!=null)
        addRow(sheet, new CashFlowRow(table.title));
      addRows(sheet, table.rows);
      addRows(sheet, table.summaries);
      }

    private void addRows(SheetData sheet, List<CashFlowRow> rows) {
      if(rows==null)
        return;
      foreach(var o in rows)
        addRow(sheet, o);
      }

    private SheetData generateSheetdataForDetails() {
      SheetData r = new SheetData();
      createHeaderRow(r);
      addRows(r, this.openingCash);
      createRow(r);
      addRows(r, this.initialRevenue);
      createRow(r);
      addRows(r, this.salesForecast);
      createRow(r);
      addRows(r, this.investments);
      createRow(r);
      createRow(r);
      addRows(r, this.fixedCosts);
      addRows(r, this.variableCosts);
      createRow(r);
      addRows(r, this.balances);
      return r;
      }

    //---------------------- generic technical -------------------------------//
    private Cell createCell(CellValues dataType, uint styleIndex) {  
      Cell cell = new Cell();  
      cell.StyleIndex = styleIndex;  
      cell.DataType = dataType;
      return cell;  
      } 

    private Cell createCell(string text, uint styleIndex=1U) {
      var cell=createCell(CellValues.String, styleIndex);
      cell.CellValue = new CellValue(text);  
       return cell;  
      } 

    private Cell createCell(decimal? value, uint styleIndex=1U) {
      var cell=createCell(CellValues.Number, styleIndex);
      if(value!=null)
        cell.CellValue = new CellValue(value.Value);  
      return cell;  
      } 

    private Cell createCell(Row row, decimal? value, uint styleIndex=1U) {
      var cell=createCell(value, styleIndex);
      row.Append(cell);
      return cell;  
      } 

    private Cell createCell(Row row, string text, uint styleIndex=1U) {
      var cell=createCell(text, styleIndex);
      row.Append(cell);
      return cell;  
      } 


    private Row createRow(SheetData sheet) {
      var rw=new Row();
      sheet.Append(rw);
      return rw;
      }

    private Row createHeaderRow(SheetData sheet, IEnumerable<string> headers) {  
      Row workRow = createRow(sheet);
      foreach(var h in headers)
        createCell(workRow, h, 2U);  
      return workRow;  
      } 

    private Sheet createPartsForExcel(SpreadsheetDocument document, string sheetName=null) {  
      workbookPart = document.AddWorkbookPart(); 
      workbookPart.Workbook=new Workbook();

     worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
     worksheetPart.Worksheet = new Worksheet(new SheetData());

     var sheets = workbookPart.Workbook.AppendChild<Sheets>(new Sheets());

     if(sheetName==null)
       return null;
     return createSheet(workbookPart, worksheetPart, sheetName, 1);




      //SheetData partSheetData = GenerateSheetdataForDetails();  
       

      //WorkbookStylesPart workbookStylesPart1 = workbookPart1.AddNewPart<WorkbookStylesPart>("rId3");  
      //generateWorkbookStylesPartContent(workbookStylesPart1);  

      //WorksheetPart worksheetPart1 = workbookPart1.AddNewPart<WorksheetPart>("rId1");
      //GenerateWorksheetPartContent(worksheetPart1, partSheetData);
      }  

    private Sheet createSheet(WorkbookPart bookP, WorksheetPart wsP, string sheetName, UInt32 sheetId) {
      var sh = new Sheet(){ Id = bookP.GetIdOfPart(wsP), SheetId = sheetId, Name = sheetName };
      bookP.Workbook.Sheets.Append(sh);
      return sh;
      }

    //private void generateWorkbookPartContent(WorkbookPart workbookPart1, string sheetName="Cash Flow", UInt32 sheetId=1U, string id="rId1" ) {  
    //  Workbook workbook1 = new Workbook();
    //  Sheets sheets1 = new Sheets();
    //  Sheet sheet1 = new Sheet() { Name = sheetName, SheetId = (UInt32Value)sheetId, Id =id };
    //  sheets1.Append(sheet1);  
    //  workbook1.Append(sheets1);  
    //  workbookPart1.Workbook = workbook1;  
    //  }

    private void generateWorksheetPartContent(WorksheetPart worksheetPart1, SheetData sheetData1) {
      Worksheet worksheet1 = new Worksheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
      worksheet1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
      worksheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
      worksheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
      SheetDimension sheetDimension1 = new SheetDimension() { Reference = "A1" };

      SheetViews sheetViews1 = new SheetViews();

      SheetView sheetView1 = new SheetView() { TabSelected = true, WorkbookViewId = (UInt32Value)0U };
      Selection selection1 = new Selection() { ActiveCell = "A1", SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A1" } };

      sheetView1.Append(selection1);

      sheetViews1.Append(sheetView1);
      SheetFormatProperties sheetFormatProperties1 = new SheetFormatProperties() { DefaultRowHeight = 15D, DyDescent = 0.25D };

      PageMargins pageMargins1 = new PageMargins() { Left = 0.7D, Right = 0.7D, Top = 0.75D, Bottom = 0.75D, Header = 0.3D, Footer = 0.3D };
      worksheet1.Append(sheetDimension1);
      worksheet1.Append(sheetViews1);
      worksheet1.Append(sheetFormatProperties1);
      worksheet1.Append(sheetData1);
      worksheet1.Append(pageMargins1);
      worksheetPart1.Worksheet = worksheet1;
      }

    //private void generateWorkbookStylesPartContent(WorkbookStylesPart workbookStylesPart1) {  
    //  Stylesheet stylesheet1 = new Stylesheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };  
    //  stylesheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");  
    //  stylesheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");  

    //  Fonts fonts1 = new Fonts() { Count = (UInt32Value)2U, KnownFonts = true };  

    //  Font font1 = new Font();  
    //  FontSize fontSize1 = new FontSize() { Val = 11D };  
    //  Color color1 = new Color() { Theme = (UInt32Value)1U };  
    //  FontName fontName1 = new FontName() { Val = "Calibri" };  
    //  FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 2 };  
    //  FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };  

    //  font1.Append(fontSize1);  
    //  font1.Append(color1);  
    //  font1.Append(fontName1);  
    //  font1.Append(fontFamilyNumbering1);  
    //  font1.Append(fontScheme1);  

    //  Font font2 = new Font();  
    //  Bold bold1 = new Bold();  
    //  FontSize fontSize2 = new FontSize() { Val = 11D };  
    //  Color color2 = new Color() { Theme = (UInt32Value)1U };  
    //  FontName fontName2 = new FontName() { Val = "Calibri" };  
    //  FontFamilyNumbering fontFamilyNumbering2 = new FontFamilyNumbering() { Val = 2 };  
    //  FontScheme fontScheme2 = new FontScheme() { Val = FontSchemeValues.Minor };  

    //  font2.Append(bold1);  
    //  font2.Append(fontSize2);  
    //  font2.Append(color2);  
    //  font2.Append(fontName2);  
    //  font2.Append(fontFamilyNumbering2);  
    //  font2.Append(fontScheme2);  

    //  fonts1.Append(font1);  
    //  fonts1.Append(font2);  

    //  Fills fills1 = new Fills() { Count = (UInt32Value)2U };  

    //  Fill fill1 = new Fill();  
    //  PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };  

    //  fill1.Append(patternFill1);  

    //  Fill fill2 = new Fill();  
    //  PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };  

    //  fill2.Append(patternFill2);  

    //  fills1.Append(fill1);  
    //  fills1.Append(fill2);  

    //  Borders borders1 = new Borders() { Count = (UInt32Value)2U };  

    //  Border border1 = new Border();  
    //  LeftBorder leftBorder1 = new LeftBorder();  
    //  RightBorder rightBorder1 = new RightBorder();  
    //  TopBorder topBorder1 = new TopBorder();  
    //  BottomBorder bottomBorder1 = new BottomBorder();  
    //  DiagonalBorder diagonalBorder1 = new DiagonalBorder();  

    //  border1.Append(leftBorder1);  
    //  border1.Append(rightBorder1);  
    //  border1.Append(topBorder1);  
    //  border1.Append(bottomBorder1);  
    //  border1.Append(diagonalBorder1);  

    //  Border border2 = new Border();  

    //  LeftBorder leftBorder2 = new LeftBorder() { Style = BorderStyleValues.Thin };  
    //  Color color3 = new Color() { Indexed = (UInt32Value)64U };  

    //  leftBorder2.Append(color3);  

    //  RightBorder rightBorder2 = new RightBorder() { Style = BorderStyleValues.Thin };  
    //  Color color4 = new Color() { Indexed = (UInt32Value)64U };  

    //  rightBorder2.Append(color4);  

    //  TopBorder topBorder2 = new TopBorder() { Style = BorderStyleValues.Thin };  
    //  Color color5 = new Color() { Indexed = (UInt32Value)64U };  

    //  topBorder2.Append(color5);  

    //  BottomBorder bottomBorder2 = new BottomBorder() { Style = BorderStyleValues.Thin };  
    //  Color color6 = new Color() { Indexed = (UInt32Value)64U };  

    //  bottomBorder2.Append(color6);  
    //  DiagonalBorder diagonalBorder2 = new DiagonalBorder();  

    //  border2.Append(leftBorder2);  
    //  border2.Append(rightBorder2);  
    //  border2.Append(topBorder2);  
    //  border2.Append(bottomBorder2);  
    //  border2.Append(diagonalBorder2);  

    //  borders1.Append(border1);  
    //  borders1.Append(border2);  

    //  CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };  
    //  CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U };  

    //  cellStyleFormats1.Append(cellFormat1);  

    //  CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)3U };  
    //  CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U };  
    //  CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyBorder = true };  
    //         CellFormat cellFormat4 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };  

    //  cellFormats1.Append(cellFormat2);  
    //  cellFormats1.Append(cellFormat3);  
    //  cellFormats1.Append(cellFormat4);  

    //  CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };  
    //  CellStyle cellStyle1 = new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };  

    //  cellStyles1.Append(cellStyle1);  
    //  DifferentialFormats differentialFormats1 = new DifferentialFormats() { Count = (UInt32Value)0U };  
    // TableStyles tableStyles1 = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleLight16" };  

    //  StylesheetExtensionList stylesheetExtensionList1 = new StylesheetExtensionList();  

    //  StylesheetExtension stylesheetExtension1 = new StylesheetExtension() { Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}" };  
    //  stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");  
    //         X14.SlicerStyles slicerStyles1 = new X14.SlicerStyles() { DefaultSlicerStyle = "SlicerStyleLight1" };  

    //  stylesheetExtension1.Append(slicerStyles1);  

    //  StylesheetExtension stylesheetExtension2 = new StylesheetExtension() { Uri = "{9260A510-F301-46a8-8635-F512D64BE5F5}" };  
    //  stylesheetExtension2.AddNamespaceDeclaration("x15", "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main");  
    //  X15.TimelineStyles timelineStyles1 = new X15.TimelineStyles() { DefaultTimelineStyle = "TimeSlicerStyleLight1" };  

    //  stylesheetExtension2.Append(timelineStyles1);  

    //  stylesheetExtensionList1.Append(stylesheetExtension1);  
    //  stylesheetExtensionList1.Append(stylesheetExtension2);  

    //  stylesheet1.Append(fonts1);  
    //  stylesheet1.Append(fills1);  
    //  stylesheet1.Append(borders1);  
    //  stylesheet1.Append(cellStyleFormats1);  
    //  stylesheet1.Append(cellFormats1);  
    //  stylesheet1.Append(cellStyles1);  
    //  stylesheet1.Append(differentialFormats1);  
    //  stylesheet1.Append(tableStyles1);  
    //  stylesheet1.Append(stylesheetExtensionList1);  

    //  workbookStylesPart1.Stylesheet = stylesheet1;  
    //  }


    }
  }
