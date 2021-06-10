using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{
    [Serializable]
    public class Scene
    {
        public Points points { get; set; }
        public Click Clicker { get; set; }

        public Upgrade AutoClicker { get; set; }

        public Upgrade Employee { get; set; }

        public Upgrade Farm { get; set; }

        public Upgrade Factory { get; set; }

        public Upgrade Lab { get; set; }

        public Upgrade Portal { get; set; }

        public Purchase DoubleClick1 { get; set; }
        public Purchase DoubleClick2 { get; set; }
        public Purchase DoubleClick3 { get; set; }
        public Purchase DoubleClick4 { get; set; }
        public Purchase DoubleClick5 { get; set; }
        public Purchase DoubleClick6 { get; set; }
        public Purchase DoubleClick7 { get; set; }
        public Purchase DoubleClick8 { get; set; }


        public Purchase Multiplier1 { get; set; }
        public Purchase Multiplier2 { get; set; }
        public Purchase Multiplier3 { get; set; }
        public Purchase Multiplier4 { get; set; }
        public Purchase Multiplier5 { get; set; }
        public Purchase Multiplier6 { get; set; }
        public Purchase Multiplier7 { get; set; }
        public Purchase Multiplier8 { get; set; }


        public bool btnDoubleLock1 = false;
        public bool btnDoubleLock2 = false;
        public bool btnDoubleLock3 = false;
        public bool btnDoubleLock4 = false;
        public bool btnDoubleLock5 = false;
        public bool btnDoubleLock6 = false;
        public bool btnDoubleLock7 = false;
        public bool btnDoubleLock8 = false;
        public bool btnLock1 = false;
        public bool btnLock2 = false;
        public bool btnLock3 = false;
        public bool btnLock4 = false;
        public bool btnLock5 = false;
        public bool btnLock6 = false;
        public bool btnLock7 = false;
        public bool btnLock8 = false;
        public int Height { get; set; }

        public int Width{ get; set; }

        public int Hits { get; set; }

        public int Misses { get; set; }

        //readonly Random random = new Random();

        public Scene(int w, int h)
        {
            this.Height = h;
            this.Width = w;
            points = new Points();
            Clicker = new Click();
            AutoClicker = new Upgrade(10, 0, 0.1);
            Employee = new Upgrade(100, 0, 1.0);
            Farm = new Upgrade(1100, 0, 8);
            Factory = new Upgrade(12000, 0, 47);
            Lab = new Upgrade(130000, 0, 260);
            Portal = new Upgrade(1400000, 0, 1400);
            DoubleClick1 = new Purchase(100, 2);
            DoubleClick2 = new Purchase(1000, 2);
            DoubleClick3 = new Purchase(1000, 2);
            DoubleClick4 = new Purchase(10000, 2);
            DoubleClick5 = new Purchase(100000, 2);
            DoubleClick6 = new Purchase(1000000, 2);
            DoubleClick7 = new Purchase(10000000, 2);
            DoubleClick8 = new Purchase(100000000, 2);
            Multiplier1 = new Purchase(100, 1.05);
            Multiplier2 = new Purchase(1000, 1.05);
            Multiplier3 = new Purchase(10000, 1.05);
            Multiplier4 = new Purchase(100000, 1.05);
            Multiplier5 = new Purchase(1000000, 1.05);
            Multiplier6 = new Purchase(10000000, 1.05);
            Multiplier7 = new Purchase(100000000, 1.05);
            Multiplier8 = new Purchase(1000000000, 1.05);
            Hits = 0;
            Misses = 0;
        }        
    }
}
