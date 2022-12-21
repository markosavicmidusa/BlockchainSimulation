using System;
using System.Collections.Generic;
using System.Text;

namespace BlockchainSimulation
{
    internal class Transaction
    {
        public enum TransactionDirection
        {
            IncomingTransaction,
            OutcomingTransaction,
            InitialTransaction
        }

        private Account _sender = null;
        private Account _reciever = null;
        private DateTime _createdAt;
        private TransactionDirection _transactionDirection;
        private double _amount;

        public static List<Transaction> transactions = new List<Transaction> { };

        public Transaction(DateTime createdAt, TransactionDirection transactionDirection, double amount, Account sender, Account reciever)
        {
            _sender = sender;
            _reciever = reciever;
            _createdAt = createdAt;
            _transactionDirection = transactionDirection;
            _amount = amount;
        }
        public static string GetTransactions()
        {
            StringBuilder stringBuilder= new StringBuilder(); ;
            Console.WriteLine("Transactions: \n");

            for (int i = 0; i < transactions.Count; i++) {
                
                stringBuilder
                    .Append($"Transaction number: {i+1}")
                    .AppendLine()
                    .Append(transactions[i].ToString());
            }

            return stringBuilder.ToString();
        }
        public override string ToString()
        {
            return $"Account sender: {_sender.ToString()}\nAccount reciever: {_reciever.ToString()}\nCreatedAt: {_createdAt}\nTransactionDirection: {_transactionDirection}\nAmount: {_amount}\n\n";
             
        }

    }


}
