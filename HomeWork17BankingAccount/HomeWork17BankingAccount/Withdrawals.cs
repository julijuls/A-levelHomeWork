using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17BankingAccount
{
    class Withdrawals<T> 
    {
        public Account<T> AccountId { get; set; }  
       
        public int Sum { get; set; }        

        public void Execute()
        {
            if (AccountId.Sum > Sum)
            {
               
                AccountId.Sum -= Sum;

                if (Sum > 0) { 


                Console.WriteLine($"Снятие  {Sum} со счета {AccountId.Id},Остаток {AccountId.Sum}");
                }
                else
                {
                    Console.WriteLine($"Внесение  {-Sum} на счет {AccountId.Id},Остаток {AccountId.Sum}");
                }
            }
            else
            {
                Console.WriteLine($"Недостаточно денег на счете {AccountId.Id},Доступный баланс :{AccountId.Sum}");
            }
        }
    }
}
