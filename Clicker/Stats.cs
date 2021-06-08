using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicker
{
    public partial class Stats : Form
    {
        public Scene scene { get; set; }
        public Stats(Scene scene)
        {
            this.scene = scene;
            InitializeComponent();
            labelPoints.Text = String.Format("{0}", scene.points.points.ToString("0.00"));
            labelPpS.Text = String.Format("{0}", scene.points.PpS.ToString("0.00"));
            labelPointsPClick.Text = String.Format("{0}", scene.Clicker.clickValue);
            labelHandMade.Text = String.Format("{0}", scene.Clicker.amountOfClicks);
            labelUpgrades.Text = String.Format("{0}", scene.points.amountOfUpgrades);
            labelPurchases.Text = String.Format("{0}", scene.points.amountOfPurchases);
            labelUpgrades2.Text = String.Format("{0}", scene.points.pointsSpentOnUpgrades.ToString("0.00"));
            labelPurchases2.Text = String.Format("{0}", scene.points.pointsSpentOnPurchases.ToString("0.00"));
        }
    }
}
