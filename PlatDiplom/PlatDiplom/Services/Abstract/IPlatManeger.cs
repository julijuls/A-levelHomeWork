using PlatDiplom.Models.PlatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlatDiplom.Services
{

    public interface IPlatManeger
    {
        SelectList GetCountries(int? id);
        SelectList GetStatus(int? id);
        SelectList GetCurrencies(int? id);
        SelectList GetUsers(int? id);
    }
}