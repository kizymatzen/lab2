using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using EllipticCurve;
using System.Transactions;
using Lab2_Kizy;

namespace Lab2_Kizy
{
    class Block
    {
        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public string timestamp { get; set; }
        public string Hash { get; set; }
        public string Timestamp { get; private set; }
        public int Nonce { get; private set; }
        public List<Transaction> Transactions { get; private set; }


        public Block(int index, string timestap, List<Transaction> transactions, string previousHash = "")
        {
            this.Index = index;
            this.timestamp = timestamp;
            this.Transactions = transactions;
            this.PreviousHash = previousHash;
            this.Hash = CalculateHash();
            this.Nonce = 0;
        }

        public string CalculateHash()
        {
            string blockData = this.Index + this.PreviousHash + this.Timestamp + this.Transactions.ToString();
            byte[] blockBytes = Encoding.ASCII.GetBytes(blockData);
            byte[] hashBytes = SHA256.Create().ComputeHash(blockBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        public void Mine(int difficulty)
        {
            while (this.Hash.Substring(0, difficulty) != new String('0', difficulty))
            {
                this.Nonce++;
                this.Hash = this.CalculateHash();
                //Console.WriteLine("Mining: " + this.Hash);
            }

            Console.WriteLine("Block has been mined: " + this.Hash); 
        }
    }
}
