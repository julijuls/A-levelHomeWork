using PlatDiplom.Models;
using PlatDiplom.Models.PlatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlatDiplom.Services
{
    public class PaymentManager
    {
        nemo_freshEntities db;

        public PaymentManager(nemo_freshEntities db)
        {
            this.db = db;
        }

        public List<PaymentsData> GetAllPAFirms(Filterplat filter, int startRec, int? pageSize, string order, string orderDir, out int totalRecords)
        {
            var query = db.PaymentsRU.Select(x => new PaymentsData
            {

                id_plat = x.id_plat,
                PurOfPayment = x.PurOfPayment,
                sum = x.sum,
                OurCase = x.OurCase,
                region_id = x.region_id,
                currency_id = x.currency_id,
                currency = x.Currencies.currencycode,
                User = x.Users.Username,
                Paid = x.Paid,
                File = x.File,

                Bank_id = x.Bank_id

            });
            if (filter.Country != null)
            {
                query = query.Where(x => x.region_id == filter.Country);
            }
            if (filter.Status == 1)
            {
                query = query.Where(x => x.Paid != null);
            }
            else if (filter.Status == 0)
            {
                query = query.Where(x => x.Paid == null);
            }




            if (orderDir != null)
            {
                switch (order)
                {

                    case "1":
                        query = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(x => x.PurOfPayment) : query.OrderBy(x => x.PurOfPayment);
                        break;
                    case "2":
                        query = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(x => x.sum) : query.OrderBy(x => x.sum);
                        break;
                    case "3":
                        query = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(x => x.OurCase) : query.OrderBy(x => x.OurCase);
                        break;
                    case "4":
                        query = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(x => x.Users.Username) : query.OrderBy(x => x.Users.Username);
                        break;
                    case "5":
                        query = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(x => x.Paid) : query.OrderBy(x => x.Paid);
                        break;
                    case "6":
                        query = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(x => x.File) : query.OrderBy(x => x.File);
                        break;
                    default:
                        query = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? query.OrderByDescending(x => x.id_plat) : query.OrderBy(x => x.id_plat);
                        break;
                }
            }


            totalRecords = query.Count();

            var preRes = query.ToList();
            if (pageSize != null)
                preRes = preRes.Skip(startRec).Take(pageSize.Value).ToList();
            var result = preRes.Select(x => new PaymentsData
            {

                id_plat = x.id_plat,
                PurOfPayment = x.PurOfPayment,
                sum = x.sum,
                OurCase = x.OurCase,
                region_id = x.region_id,
                currency_id = x.currency_id,
                currency = x.Currencies.currencycode,
                User = x.Users.Username,
                Paid = x.Paid,
                File = x.File,

                Bank_id = x.Bank_id



            }).ToList();

            return result;
        }
    }
}