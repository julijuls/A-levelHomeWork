using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlatDiplom.Models.UploadFiles
{

    public class FileOptions
    {/// <summary>
     /// данные из БД
     /// </summary>
        public string FilePathFromDB { get; set; }
        /// <summary>
        /// строка из бд без #(диеза)
        /// </summary>
        public string ShortFilePathFromDB { get; set; }
        /// <summary>
        /// путь к файлу для загрузки в браузере
        /// </summary>
        public string FilePathForBrowser { get; set; }
        /// <summary>
        /// имя файла с расширением
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// расширение файла
        /// </summary>
        public string FileType { get; set; }

        public bool IsExist { get; set; }

        public FileOptions(string pathFromDb)
        {

            this.FilePathFromDB = pathFromDb;
            this.ShortFilePathFromDB = (FilePathFromDB ?? "").Trim('#');
            this.FilePathForBrowser = (FilePathFromDB ?? "")
                    .Replace("\\\\samson\\", "/")
                    .Replace("\\\\Samson\\", "/")
                    .Replace("\\\\SAMSON\\", "/")
                    .Replace("z:\\", "/ip-all/")
                    .Replace("Z:\\", "/ip-all/")
                    .Replace("y:\\", "/y/")
                    .Replace("Y:\\", "/y/")
                    .Replace("c:\\dn", "/DebitNotes")
                    .Replace("C:\\DN", "/DebitNotes")
                    .Replace("\\", "/")
                    .Replace("ip-all/Moscow/ALYA-RU", "ima")
                    .Replace("ip-all/Moscow/EAPO-e-filing", "EAPO-e-filing")
                    .Replace("ip-all/Moscow/e-filing", "ime")
                    .Replace("ip-all/KZ-MSP", "KZ-MSP")
                    .Replace("ip-all/GE-MSP", "GE-MSP")
                    .Replace("ip-all/UZ-MSP", "UZ-MSP")
                    .Replace("ip-all/BY-MSP", "BY-MSP")
                    .Replace("ip-all/MD-MSP", "MD-MSP")
                    .Replace("ip-all/--mvi", "--mvi")
                    .Replace("ip-all/--MVI", "--mvi")
                    .Replace("info/perepiska", "y/perepiska")
                    .Replace("info/perepiska", "y/perepiska")
                    .Replace("ip-all/", "")
                    .Replace("#", "")
                    .Replace("'", "&#39;")
                    ;
            this.FileName = System.IO.Path.GetFileName((FilePathFromDB ?? "").Trim('#'));
            this.FileType = System.IO.Path.GetExtension((FilePathFromDB ?? "").Trim('#'));

            string filePhysicalPath = ShortFilePathFromDB
                .Replace("\\\\samson\\ip-all\\", "D:\\--mvi\\")
                .Replace("\\\\Samson\\ip-all\\", "D:\\--mvi\\")
                .Replace("\\\\SAMSON\\ip-all\\", "D:\\--mvi\\")
                .Replace("y:\\", "I:\\")
                .Replace("Y:\\", "I:\\")
                .Replace("z:\\", "D:\\")
                .Replace("Z:\\", "D:\\")
                .Replace("ip-all\\--mvi", "--mvi")
                .Replace("ip-all\\--MVI", "--mvi");
            this.IsExist = System.IO.File.Exists(filePhysicalPath);
        }

    }
}