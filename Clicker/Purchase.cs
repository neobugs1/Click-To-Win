using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{
    [Serializable]
    public class Purchase
    {
        public double Cost { get; set; }
        public double Multiplier { get; set; }

        public Purchase(double Cost, double Multiplier){
            this.Cost = Cost;
            this.Multiplier = Multiplier;
        }
        public override string ToString()
        {
            if(Multiplier==2)
                return String.Format("-Двоен клик.\n-Цена {0}.", Cost.ToString("0.00"));
            else
                return String.Format("-Зголемување на заработката за 5%.\n-Цена {0}.", Cost.ToString("0.00"));

        }
    }
}
