using PlatDiplom.Models;
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
        List<PaymentsData> GetPaymentsList(Filterplat filter);
        void Create(PaymentsRU payment);
        PaymentsRU GetPaymentByID(int id);
        void EditPayments(PaymentsRU payment);
        PlatForDNView PaymentCollection(List<PlatType> ClientList);
        void MarkAsPaid(List<PlatType> platList, string fullPathFile);
        SelectList GetCountries(int? id);
        SelectList GetStatus(int? id);
        SelectList GetCurrencies(int? id);
        SelectList GetUsers(int? id);
        void Save();
    }
}