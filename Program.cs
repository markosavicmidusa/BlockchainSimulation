using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Blockchain MarkoBlockchain = new Blockchain();

            var Bank = new Account("donald.trump@gmail.com", "12$345Donald$", "1406946710067", 200000000.00);
            var Sally = new Account("sally.johnson@gmail.com", "12345Sall!", "0101995710067");
            var John = new Account("john.johnson@gmail.com", "123J0hn45", "0101998710067");

            Sally.InitialFinancialAssets(1000.00, Bank);
            John.InitialFinancialAssets(1000.00, Bank);


            var headerMsg = new StringBuilder("BlockchainSimulation Simulation app");
            var action = new StringBuilder();
            var exit = false;


            headerMsg
                .AppendLine()
                .Append('-', headerMsg.Length)
                .AppendLine();

            action
                .Append("L -> List all transactions")
                .AppendLine("")
                .Append("A -> List all accounts")
                .AppendLine("")
                .Append("LB -> List mined blocks/ show blockchain")
                .AppendLine("")
                .Append("S -> Sally pays John 100 $")
                .AppendLine("")
                .Append("J -> John pays Sally 100 $")
                .AppendLine("")
                .Append("B -> Bank approves loan to Sally and John in amount 500 $, each")
                .AppendLine("")
                .Append("M -> Mine block")
                .AppendLine("")
                .Append("E -> Exit");


            Console.WriteLine(headerMsg);


            while (!exit)
            {

                Console.WriteLine("Please choose your action: \n");
                Console.WriteLine(action);
                var input = Console.ReadLine().Trim().ToUpper();

                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Not valid character: {0}", input);
                    continue;
                }


                switch (input)
                {

                    case "E":
                        Console.WriteLine("Exiting...Bye :)");
                        exit = true;
                        break;
                    case "L":
                        Console.WriteLine(Transaction.GetTransactions());
                        break;
                    case "LB":
                        MarkoBlockchain.ListAllBlocks();
                        break;
                    case "A":
                        Console.WriteLine(Account.GetAccounts());
                        break;
                    case "S":
                        Sally.Pay(100, John);
                        break;
                    case "J":
                        John.Pay(100, Sally);
                        break;
                    case "B":
                        Bank.Pay(500, Sally);
                        Bank.Pay(500, John);
                        break;
                    case "M":
                        Blockchain.MineBlock(false, Transaction.GetTransactions());
                        break;
                    default:
                        Console.WriteLine("Not valid character: {0}", input);
                        break;
                }

            }


        }
    }
}
