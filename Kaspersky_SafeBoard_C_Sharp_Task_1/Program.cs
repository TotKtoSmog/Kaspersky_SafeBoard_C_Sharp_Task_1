using System;
using System.Collections.Generic;
namespace Kaspersky_SafeBoard_C_Sharp_Task_1
{
    class Transaction
    {
        public ulong Money = 0;
        public uint Count = 0;

        public Transaction(ulong money) => SendTransaction(money);
        public void SendTransaction(ulong money)
        {
            Money += money;
            Count++;
        }
    }
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, Transaction> transactionDict = new Dictionary<string, Transaction>();
            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                int index = line.IndexOf(' ');
                ulong money = ulong.Parse(line.Substring(0, index));
                string client = line.Substring(index + 1, line.Length - index - 1);

                if (transactionDict.ContainsKey(client))
                    transactionDict[client].SendTransaction(money);
                else
                    transactionDict.Add(client, new Transaction(money));
            }
            ulong maxSum = 0;
            ulong minSum = ulong.MaxValue;
            ulong count = 1;
            foreach (var transaction in transactionDict)
            {
                if (maxSum < transaction.Value.Money)
                {
                    maxSum = transaction.Value.Money;
                    count = transaction.Value.Count;
                }
                if (minSum > transaction.Value.Money)
                    minSum = transaction.Value.Money;
            }
            Console.WriteLine($"{count} {minSum}");
            Console.ReadKey();
        }
    }
}
