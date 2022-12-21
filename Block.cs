using System;
using System.Text;

namespace BlockchainSimulation
{
    public class Block {

        public int _blockNumber;
        public int _nonce = 0;
        public string _data = "";
        public string _previousHash;
        public string _hash = "";
        public DateTime? _created = null;
        

        public Block(int blockNumber, string data, string previousHash, string hash, int nonce, DateTime minedAt)
        {
            _blockNumber = blockNumber;
            _data = data;
            _nonce = nonce;
            _previousHash = previousHash;
            _hash = hash;
            _created = minedAt;
   
        }

        public override string ToString()
        {
            StringBuilder stringRepresentation = new StringBuilder("Block number " + _blockNumber + " ");
            stringRepresentation
                .AppendLine()
                .Append('-', stringRepresentation.Length)
                .AppendLine()
                .Append("Nonce: " + _nonce)
                .AppendLine()
                .Append("PreviousHash: " + _previousHash)
                .AppendLine()
                .Append("Hash: " + _hash)
                .AppendLine()
                .Append("Created at: " + _created)
                .AppendLine()
                .Append("Data: " + _data)
                .AppendLine();


            return stringRepresentation.ToString();
        }
    }

}
