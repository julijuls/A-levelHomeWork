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
        public ActionResult genDn(List<PlatType> platList)
        {

            nemo_freshEntities db = new nemo_freshEntities();

            var platListModel = new PlatForDNView
            {
                Payments = new List<PaymentsRU>(),
                SelectedSum = null
            };
            foreach (var item in platList)
            {
                var localplatList = new List<PaymentsRU>();
                localplatList = db.PaymentsRU.Where(x => x.id_plat == item.Id).ToList();
                platListModel.Payments.AddRange(localplatList);

            }
            platListModel.Payments = platListModel.Payments.Distinct().OrderBy(x => x.id_plat).ToList();
            platListModel.SelectedSum = platListModel.Payments.Sum(x => x.sum).ToString();



            TableContent t1 = new TableContent("OurActionsTable");
            int i_servises = 1;
            foreach (var a in platListModel.Payments)
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

            var valuesToFill = new Content(t1, new FieldContent("Total", String.Format("{0:f2}", platListModel.SelectedSum))

            );

            var newNameFolder = Properties.Resource.DiscLetter + @"\DNDocs\";
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

            db.SaveChanges();

            var doc = DocumentGetter.GetDnDocument(Url.Content("~"), fullPathFile);
            return Json(new JsonResponseModel("Ok", "") { Doc = doc }, JsonRequestBehavior.AllowGet);
        }

    }
}