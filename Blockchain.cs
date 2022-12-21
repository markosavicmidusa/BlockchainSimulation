using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace BlockchainSimulation
{
    public class Blockchain
    {
        private static bool initialized = false;
        public static string _targetHash;

        public static List<Block> blockchain = new List<Block>();

        public Blockchain(string targetHash = "000FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF")
        {
            _targetHash = targetHash;

            if (!initialized)
            {

                var previousHashBigInt = new BigInteger(0);
                MineBlock(true);

                initialized = true;

            }
            else
            {
                Console.WriteLine("The BlockchainSimulation has been initialized !");
            }
        }
        public static void MineBlock( bool isGenesisBlock, string data = "Genesis Block Data...") {

            BigInteger blockHashDecimal;
            BigInteger targetHashDecimal = BigInteger.Parse(Blockchain._targetHash, NumberStyles.AllowHexSpecifier);
            
            string blockData;
            string blockHash;

            DateTime minedAt;
            StringBuilder previousHash = new StringBuilder();
            int blockNumber;

            if (isGenesisBlock)
            {
                previousHash.Append('0', 64).ToString();
                blockNumber = 1;
                
            }
            else{
                previousHash.Append(blockchain[blockchain.Count - 1]._hash.ToString());
                blockNumber = Convert.ToInt32(blockchain[blockchain.Count-1]._blockNumber) + 1;
               
            }
            

            if(!isGenesisBlock)
                Console.WriteLine("Mining...");
            
            var nonce = 0;
            while (true)
            {

                minedAt = DateTime.Now;
                blockData = string.Join(",", blockNumber, nonce, data, previousHash.ToString(), minedAt);
                blockHash = Encription.SHA256Encription(blockData);
                blockHashDecimal = BigInteger.Parse("00" + blockHash, NumberStyles.AllowHexSpecifier);
                

                if (blockHashDecimal < targetHashDecimal)
                    break;

                nonce++;
            }

            if (!isGenesisBlock)
                Console.WriteLine("Mining finished...");
     

            blockchain.Add(new Block(blockNumber, data, previousHash.ToString() , blockHash.ToString(), nonce, minedAt));
            Transaction.transactions.Clear();
        }

        public void ListAllBlocks() { 
            foreach(var block in blockchain)
                Console.WriteLine(block);

        }

    }

}
