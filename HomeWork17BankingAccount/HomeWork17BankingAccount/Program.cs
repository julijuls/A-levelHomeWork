using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17BankingAccount
{
    class Program
    {
   
            static void Main(string[] args)
            {
            Account<string> acc1 = new Account<string>("1") { Sum = 400000 };
            Account<string> acc2 = new Account<string>("2") { Sum = 30000 };
            Account<int> acc3 = new Account<int>(3) { Sum = 700000 };
            Account<int> acc4 = new Account<int>(4) { Sum = 50000 };

            Transaction<string,int> transaction1 = new Transaction<string,int>//between accounts
            {
                FromAccount = acc1,
                ToAccount = acc3,
                Sum = 10000
            };
 
            transaction1.Execute();
            Withdrawals<int> transaction2 = new Withdrawals<int>//withdrawal own account
            {
                AccountId = acc3,
                Sum = -5000
            };
            transaction2.Execute();

            Console.Read();
        }
        
    }
}
