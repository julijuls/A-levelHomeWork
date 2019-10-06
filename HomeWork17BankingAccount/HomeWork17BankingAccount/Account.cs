using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17BankingAccount
{
    class Account<T>
    {
        public T Id { get; private set; } // номер счета
        public int Sum { get; set; }
        public Account(T _id)
        {
            Id = _id;
        }
    }
}
