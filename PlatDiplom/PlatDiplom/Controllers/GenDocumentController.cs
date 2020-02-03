using DocumentFormat.OpenXml.CustomProperties;
using PlatDiplom.Helpers;
using PlatDiplom.Models.PlatModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateEngine.Docx;

namespace PlatDiplom.Controllers
{
    public class GenDocumentController : Controller
    {
        [HttpPost]
        public ActionResult genDn(PlatForDNView platList)
        {

            nemo_freshEntities db = new nemo_freshEntities();

            if (platList == null)
            {
                return Json(new JsonResponseModel("Error", "No dn"), JsonRequestBehavior.AllowGet);
            }

            TableContent t1 = new TableContent("OurActionsTable");
            int i_servises = 1;
            foreach (var a in platList.Payments)
            {
                if (a.PurOfPayment != null || a.PurOfPayment.Length != 0)
                {
                    t1.AddRow(
                            new FieldContent("Num", i_servises++.ToString() ?? ""),
                            new FieldContent("ActionDescr", a.PurOfPayment),
                            new FieldContent("Sum", a.sum != null ? String.Format("{0:f2}", a.sum) : "")
                         );


                }
            }

            var valuesToFill = new Content(t1, new FieldContent("Total", String.Format("{0:f2}", platList.SelectedSum))

            );

            var newNameFolder = Properties.Resources.DiscLetter + @"\DNDocs\";
            // var newNameFolder = @"C:\DNDocs\Plat\";
            var newNameDoc = "PatentRegistry.docx";

            if (!Directory.Exists(newNameFolder))
            {
                Directory.CreateDirectory(newNameFolder);
            }
            string fullPathFile = newNameFolder + newNameDoc;

            int count = 1;
            string fileNameOnly = Path.GetFileNameWithoutExtension(fullPathFile);
            string extension = Path.GetExtension(fullPathFile);
            string path = Path.GetDirectoryName(fullPathFile);
            string newFullPath = fullPathFile;

            while (System.IO.File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                newFullPath = Path.Combine(path, tempFileName + extension);
                fullPathFile = newFullPath;
            }


            var templatePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "DnTemplates/RegistrPlat.docx";
            System.IO.File.Copy(templatePath, fullPathFile, true);
            using (var outputDoc = new TemplateProcessor(fullPathFile).SetRemoveContentControls(true))
            {
                outputDoc.FillContent(valuesToFill);
                outputDoc.SaveChanges();
            }
            // var doc = DocumentsGetter.GetDnDocument(dn.No, Url.Content("~"), fullPathFile);

            db.SaveChanges();

            var doc = DocumentGetter.GetDnDocument("8888", Url.Content("~"), fullPathFile);
            return Json(new JsonResponseModel("Ok", "") { Doc = doc }, JsonRequestBehavior.AllowGet);
            //return "OK";
        }

    }
}