﻿using ModuleBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulePL.PostModels
{
   public class AddStudentPostModel
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int? Age { get; set; }
        public IEnumerable<PaymentPost> Payments { get; set; }
    }
}
