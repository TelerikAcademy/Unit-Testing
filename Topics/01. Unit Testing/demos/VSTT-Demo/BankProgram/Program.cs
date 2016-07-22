using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();



            Debug.Assert(bank.AccountsCount > 0);
            

        }
    }
}
