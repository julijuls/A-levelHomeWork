using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17BankingAccount
{
    class Transaction<T,K>  
    {
        public Account<T> FromAccount { get; set; } 
        public Account<K> ToAccount { get; set; }   
        
        public int Sum { get; set; }        

        public void Execute()
        {
            if (FromAccount.Sum > Sum)
            {
                FromAccount.Sum -= Sum;
                ToAccount.Sum += Sum;
                Console.WriteLine($"Счет {FromAccount.Id}: {FromAccount.Sum}$ \nСчет {ToAccount.Id}: {ToAccount.Sum}$");
            }
            else
            {
                Console.WriteLine($"Недостаточно денег на счете {FromAccount.Id}");
            }
        }
    }
}
