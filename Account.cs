using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainSimulation
{

    internal class Account
    {

        private string _accountNumber;
        private string _jmbg;
        private DateTime _createdAt;
        private double _amount;
        public string _username { get; set; }
        public string _password { get; set; }

        private static List<Account> accounts = new List<Account> { };


        public Account(string username, string password, string jmbg, double amount = 0.0)
        {
            _username = username;
            _password = Encription.SHA1Encription(password);
            _jmbg = jmbg;
            _createdAt = DateTime.Now;
            _accountNumber = Encription.GenerateAccountNumberSHA256(_username, _password, _jmbg, _createdAt);
            _amount = amount;

            accounts.Add(this);
        }

        public void InitialFinancialAssets(double amount, Account sender)
        {

            sender.Pay(amount, this);

        }
        public void Pay(double amount, Account reciever) {

            this._amount -= amount;
            AddTransaction(new Transaction(DateTime.Now, Transaction.TransactionDirection.OutcomingTransaction, amount, this, reciever));

            reciever.Recieve(amount, this);
        }
        private void Recieve(double amount, Account sender)
        {
            this._amount += amount;
            AddTransaction(new Transaction(DateTime.Now, Transaction.TransactionDirection.IncomingTransaction, amount, sender, this));
        }
        private void AddTransaction(Transaction t) 
        {
            Transaction.transactions.Add(t);
        }
       
        public static string GetAccounts()
        {
            StringBuilder stringBuilder = new StringBuilder(); ;
            Console.WriteLine("Accounts: \n");

            for (int i = 0; i < accounts.Count; i++)
            {
            
                stringBuilder
                    .Append($"Account Number: {i + 1} \n")
                    .AppendLine()
                    .Append(accounts[i].ToString())
                    .AppendLine();
            }
            
            return stringBuilder.ToString();
           
        }


        public override string ToString()
        {
            string _amountString = _amount.ToString("C");
            return $"Username: {_username}\nPassword: {_password}\nAccountNumber: {_accountNumber}\nJmbg: {_jmbg}\nAmount: {_amountString}";
       
        }
       
        //Enums are types, not variables. Therefore they are 'static' per definition, you dont need the keyword.
    }


}
