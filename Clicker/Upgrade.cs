using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{
    [Serializable]
    public class Upgrade
    {
        public double Cost { get; set; }

        public int Amount { get; set; }

        public double CpS { get; set; }

        public static int multiplier = 1;

        public double totalCpS = 0;

        public Upgrade(double cost, int amount, double cpS)
        {
            this.Cost = cost;
            this.Amount = amount;
            this.CpS = cpS * multiplier;
        }
        public void add()
        {
            Amount++;
            totalCpS += CpS;
            Cost *= 1.15;
            CpS *= 1.11;
        }
        public override string ToString()
        {
            return String.Format("-Секоја надградба ви носи {0} поени во секундa.\n-Сите заедно носат {1}.", CpS.ToString("0.00"), totalCpS.ToString("0.00"));
        }
    }
}
