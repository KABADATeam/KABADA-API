using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace KabadaAPI {
  public abstract class SofficeManager {
    public static void ConvertToPDF(BLontext context, string inputFile, string outputFile=null)
    {
        var args = new List<string>();
        var officePath = Path.Combine(context.sofficeDirectory, "soffice.exe");
        var tmpDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs" );
        if (!Directory.Exists(tmpDir)) { Directory.CreateDirectory(tmpDir); }

        var convertedFile = Path.Combine(tmpDir, Path.GetFileNameWithoutExtension(inputFile) + ".pdf");
           
         if (!File.Exists(inputFile)) throw new Exception(String.Format("Inputfile {0} NOT FOUND", inputFile));
        //args.AddRange(new[] { "--convert-to", "pdf:writer_pdf_Export", inputFile, "--norestore", "--writer", "--headless", "--outdir", tmpDir });
         args.AddRange(new[] { "--convert-to", "pdf", inputFile, "--outdir", tmpDir });

            var procStartInfo = new ProcessStartInfo(officePath);
        foreach (var arg in args) { procStartInfo.ArgumentList.Add(arg); }
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        procStartInfo.CreateNoWindow = true;
        procStartInfo.WorkingDirectory = Environment.CurrentDirectory;

        var process = new Process() { StartInfo = procStartInfo };
        Process[] pname = Process.GetProcessesByName("soffice");

        while (pname.Length > 0)       //simultaneously only one instance of LibreOffice can be run 
        {
            Thread.Sleep(1000);
            pname = Process.GetProcessesByName("soffice");
        }
        process.Start();
        process.WaitForExit();
            
        if (process.ExitCode != 0)  throw new Exception("soffice is failed with code="+process.ExitCode);            
        else
        {
                if (!String.IsNullOrEmpty(outputFile))
                {
                    if (File.Exists(outputFile)) File.Delete(outputFile);
                    if (File.Exists(convertedFile)) File.Move(convertedFile, outputFile);
                }
        }
    }

    }
}
