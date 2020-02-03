using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlatDiplom.Models.PlatModel
{
    public class JsonResponseModel
    {
        public JsonResponseModel(string result, string content)
        {
            Result = result;
            Content = content;
            Doc = new Document();
        }
        public string Result { get; set; }
        public string Content { get; set; }
        public Document Doc { get; set; }
    }
}