using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{
    [Serializable]
    public class Points
    {
        public double points = 0;

        public double PpS = 0;

        public int amountOfUpgrades { get; set; }
        public int amountOfPurchases { get; set; }
        public double pointsSpentOnUpgrades { get; set; }
        public double pointsSpentOnPurchases { get; set; }

        public Points() {
            amountOfUpgrades = 0;
            amountOfPurchases = 0;
            pointsSpentOnUpgrades = 0;
            pointsSpentOnPurchases = 0;
        }

        public void buyUpgrade(Upgrade u)
        {
            if (points >= u.Cost)
            {
                points -= (int)u.Cost;
                PpS += u.CpS;
                u.add();
            }
            amountOfUpgrades++;
            pointsSpentOnUpgrades += u.Cost;
        }
        public void buyPurchase(Purchase u, Click Clicker)
        {
            if (points >= u.Cost)
            {
                points -= (int)u.Cost;
                if (u.Multiplier == 2)
                {
                    Clicker.doubleClick();
                }
                else
                {
                    PpS *= u.Multiplier;
                }
            }
            amountOfPurchases++;
            pointsSpentOnPurchases += u.Cost;
        }
    }
}
