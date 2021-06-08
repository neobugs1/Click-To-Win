using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{   
    [Serializable]
    public class Click
    {
        public int clickValue = 1;

        public int amountOfClicks { get; set; }

        public Click()
        {

        }
        public void doubleClick()
        {
            clickValue *= 2;
        }

    }
}
