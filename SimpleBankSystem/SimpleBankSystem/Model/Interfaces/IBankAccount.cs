using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankSystem.Model.Interfaces
{
    interface IBankAccount
    { 
        void Withdraw(int _amount);

        void Deposit(int _amount);

        void Rename(string _newName);

        void Delete();

        void SendFunds(int _amount);

        void TransferFunds(int _amount);
    }
}
