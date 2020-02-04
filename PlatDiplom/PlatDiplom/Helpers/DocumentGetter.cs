using PlatDiplom.Models.PlatModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PlatDiplom.Helpers
{
    public class DocumentGetter
    {
        public static Document GetDnDocument(string startUrl, string fullPathFile)
        {
            string Path = Properties.Resource.DiscLetter + @"\DNDocs\";
            var file = "";
            if (Directory.Exists(Path))
            {
                string[] files = Directory.GetFiles(Path).ToArray();
                if (files.Count() != 0)
                {

                    foreach (var i in files)
                    {
                        if (i == fullPathFile)
                        {
                            file = i;
                        }

                    }

                    string docName = System.IO.Path.GetFileName(file);
                    Document d = new Document()
                    {
                        Name = docName,
                        Link = startUrl + "DNDocs/" + docName
                    };

                    return d;
                }
            }

            return null;

        }

    }
}