using System.Collections.Generic;
using System.Transactions;

namespace RootCoin
{
    internal class Block
    {
        private int v1;
        private string v2;
        private List<Transaction> transactions;

        public Block(int v1, string v2, List<Transaction> transactions)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.transactions = transactions;
        }
    }
}