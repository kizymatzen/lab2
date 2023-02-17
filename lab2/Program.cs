using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using EllipticCurve;
using System.Transactions;

namespace RootCoin
{
    class Program
    {
        static void Main(string[] args)
        {

            PrivateKey key1 = new PrivateKey();
            PublicKey wallet1 = key1.publicKey();

            PrivateKey key2 = new PrivateKey();
            PublicKey wallet2 = key1.publicKey();

            Blockchain rootcoin = new.Blockchain(2, 100);

            Console.WriteLine("Start the Miner.");

            string blockJSON = JsonConvert.SerializeObject(rootcoin, formatting.Indented);
            Console.WriteLine(BlockJSON);

            if (rootcoin.IsChainValid)


            Block newBlock = new Block(1, DateTime.Now.ToString("yyyyMMddHmmssffff"), "amount: 50", "");
            string blockJSON = JsonConvert.SerializeObject(newBlock, Formatting.Indented);
            Console.WriteLine(BlockJSON);
        }
    }
    
    class Blockchain
    {

    }

    class Block
    {
        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public string timestamp { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }
        
        public Block(int index, string timestap, string data, string previousHash="")
        {
            this.Index = index;
            this.timestamp = timestamp;
            this.Data = data;
            this.PreviousHash = previousHash;
        }

        public string CalculateHash()
        {
            string blockData = this.Index + this.Index.PreviousHash + this.Timestamp + this.Data;
            byte[] blockBytes = Encoding.ASCII.GetBytes(blockData);
            byte[] hashBytes = SHA256.Create().ComputeHash(blockBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
       
       
}