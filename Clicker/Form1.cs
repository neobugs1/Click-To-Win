using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicker
{
    public partial class Form1 : Form
    {/*
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
        public bool btnLock5 =false;
        public bool btnLock6 = false;
        public bool btnLock7 = false;
        public bool btnLock8 = false;
        */
        public int timerCount = 0;
        public Scene scene { get; set; }
        public Form1()
        {

            InitializeComponent();  
            timer1.Start();
            scene = new Scene(Width,Height);
            DoubleBuffered = true;
            groupBox1.SendToBack();
            groupBox2.SendToBack();
            groupBox3.SendToBack();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.points.points += scene.points.PpS;
            updateLabels();            
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            scene.points.points += scene.Clicker.clickValue;
            scene.Clicker.amountOfClicks++;
            labelClicks.Text = String.Format("{0} поени", (int)scene.points.points);
        }
        private void btnAutoClicker_Click(object sender, EventArgs e)
        {
            scene.points.buyUpgrade(scene.AutoClicker);
        }
        
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            scene.points.buyUpgrade(scene.Employee);
        }
        private void btnFarm_Click(object sender, EventArgs e)
        {
            scene.points.buyUpgrade(scene.Farm);
        }
        private void btnFactory_Click(object sender, EventArgs e)
        {
            scene.points.buyUpgrade(scene.Factory);
        }

        private void btnLab_Click(object sender, EventArgs e)
        {
            scene.points.buyUpgrade(scene.Lab);
        }
        private void btnPortal_Click(object sender, EventArgs e)
        {
            scene.points.buyUpgrade(scene.Portal);
        }
        public static string RoundUpNumber(double num)
        {
            if (num < 1000)
                return num.ToString();
            if (num >= 1000 && num < 1000000)
                return (Math.Round(Convert.ToDecimal(num) / 1000, 1)).ToString() + "K";
            if (num >= 1000000 && num < 1000000000)
                return (Math.Round(Convert.ToDecimal(num) / 1000000, 1)).ToString() + "M";
            if (num >= 1000000000 && num < 1000000000000)
                return (Math.Round(Convert.ToDecimal(num) / 1000000000, 1)).ToString() + "B";
            if (num >= 1000000000000 && num < 1000000000000000)
                return (Math.Round(Convert.ToDecimal(num) / 1000000000000, 1)).ToString() + "T";
            if (num >= 1000000000000000 && num < 1000000000000000000)
                return (Math.Round(Convert.ToDecimal(num) / 1000000000000000, 1)).ToString() + "Qa";
            if (num >= 1000000000000000000)
                return (Math.Round(Convert.ToDecimal(num) / 1000000000000000000, 1)).ToString() + "Qi";
            else
                return "Олабави";
        }
        public void updateLabels()
        {
            labelClicksPerSecond.Text = String.Format("{0} поени/сек", scene.points.PpS.ToString("0.00"));
            labelClicks.Text = String.Format("{0} поени", RoundUpNumber(scene.points.points));
            labelAmountAuto.Text = String.Format("Вкупно: {0}", scene.AutoClicker.Amount);
            labelAutoClicker.Text = String.Format("{0} поени", scene.AutoClicker.Cost.ToString(".00"));
            labelAmountEmp.Text = String.Format("Вкупно: {0}", scene.Employee.Amount);
            labelEmployee.Text = String.Format("{0} поени", scene.Employee.Cost.ToString(".00"));
            labelAmountFarm.Text = String.Format("Вкупно: {0}", scene.Farm.Amount);
            labelFarmCost.Text = String.Format("{0} поени", scene.Farm.Cost.ToString(".00"));
            labelAmountFactory.Text = String.Format("Вкупно: {0}", scene.Factory.Amount);
            labelFactory.Text = String.Format("{0} поени", scene.Factory.Cost.ToString(".00"));
            labelAmountLab.Text = String.Format("Вкупно: {0}", scene.Lab.Amount);
            labelLab.Text = String.Format("{0} поени", scene.Lab.Cost.ToString(".00"));
            labelPortalAmount.Text = String.Format("Вкупно: {0}", scene.Portal.Amount);
            labelPortalCost.Text = String.Format("{0} поени", scene.Portal.Cost.ToString(".00"));
            labelAmountClick.Text = String.Format("{0}", scene.Clicker.clickValue);
            WinMultiplier.Text = String.Format("Multiplier: {0}", Upgrade.multiplier);
        }
        public void checkButtonUpgrade(Upgrade u, Button btn)
        {
            if (scene.points.points >= u.Cost)
            {
                btn.Enabled = true;
            }
            else
            {
                btn.Enabled = false;
            }
        }
        public void checkButtonPurchase(Purchase u, Button btn, bool btnLock)
        {
            if (btnLock == false)
            {
                if (scene.points.points >= u.Cost)
                {
                    btn.Enabled = true;
                }
                else
                {
                    btn.Enabled = false;
                }
            }
            else
            {
                btn.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pbAutoClicker.Maximum = (int)scene.AutoClicker.Cost;
            pbEmployee.Maximum = (int)scene.Employee.Cost;
            pbFarm.Maximum = (int)scene.Farm.Cost;
            pbFactory.Maximum = (int)scene.Factory.Cost;
            pbLab.Maximum = (int)scene.Lab.Cost;
            pbPortal.Maximum = (int)scene.Portal.Cost;

            if (scene.points.points <= pbAutoClicker.Maximum)
            {
                pbAutoClicker.Value = (int)scene.points.points;
            }
            else
            {
                pbAutoClicker.Value = pbAutoClicker.Maximum;
            }
            checkButtonUpgrade(scene.AutoClicker, btnAutoClicker);


            if (scene.points.points <= pbEmployee.Maximum)
            {
                pbEmployee.Value = (int)scene.points.points;
            }
            else
            {
                pbEmployee.Value = pbEmployee.Maximum;
            }
            checkButtonUpgrade(scene.Employee, btnEmployee);



            if (scene.points.points <= pbFarm.Maximum)
            {
                pbFarm.Value = (int)scene.points.points;
            }
            else
            {
                pbFarm.Value = pbFarm.Maximum;
            }
            checkButtonUpgrade(scene.Farm, btnFarm);



            if (scene.points.points <= pbFactory.Maximum)
            {
                pbFactory.Value = (int)scene.points.points;
            }
            else
            {
                pbFactory.Value = pbFactory.Maximum;
            }
            checkButtonUpgrade(scene.Factory, btnFactory);



            if (scene.points.points <= pbLab.Maximum)
            {
                pbLab.Value = (int)scene.points.points;
            }
            else
            {
                pbLab.Value = pbLab.Maximum;
            }
            checkButtonUpgrade(scene.Lab, btnLab);



            if (scene.points.points <= pbPortal.Maximum)
            {
                pbPortal.Value = (int)scene.points.points;
            }
            else
            {
                pbPortal.Value = pbPortal.Maximum;
            }
            checkButtonUpgrade(scene.Portal, btnPortal);

            checkButtonPurchase(scene.DoubleClick1, btnDoubleClick, scene.btnDoubleLock1);
            checkButtonPurchase(scene.DoubleClick2, btnDoubleClick2, scene.btnDoubleLock2);
            checkButtonPurchase(scene.DoubleClick3, btnDoubleClick3, scene.btnDoubleLock3);
            checkButtonPurchase(scene.DoubleClick4, btnDoubleClick4, scene.btnDoubleLock4);
            checkButtonPurchase(scene.DoubleClick5, btnDoubleClick5, scene.btnDoubleLock5);
            checkButtonPurchase(scene.DoubleClick6, btnDoubleClick6, scene.btnDoubleLock6);
            checkButtonPurchase(scene.DoubleClick7, btnDoubleClick7, scene.btnDoubleLock7);
            checkButtonPurchase(scene.DoubleClick8, btnDoubleClick8, scene.btnDoubleLock8);

            checkButtonPurchase(scene.Multiplier1, btnMultiplier, scene.btnLock1);
            checkButtonPurchase(scene.Multiplier2, btnMultiplier2, scene.btnLock2);
            checkButtonPurchase(scene.Multiplier3, btnMultiplier3, scene.btnLock3);
            checkButtonPurchase(scene.Multiplier4, btnMultiplier4, scene.btnLock4);
            checkButtonPurchase(scene.Multiplier5, btnMultiplier5, scene.btnLock5);
            checkButtonPurchase(scene.Multiplier6, btnMultiplier6, scene.btnLock6);
            checkButtonPurchase(scene.Multiplier7, btnMultiplier7, scene.btnLock7);
            checkButtonPurchase(scene.Multiplier8, btnMultiplier8, scene.btnLock8);

            if (scene.points.points >= 10000000)
            {
                btnWin.Enabled = true;
            }
            else
            {
                btnWin.Enabled = false;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Width -= 2;
            pictureBox1.Height -= 2;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Width += 2;
            pictureBox1.Height += 2;
        }



        private void btnAutoClicker_MouseHover(object sender, EventArgs e)
        {
            
            toolTip1.Show(scene.AutoClicker.ToString(),btnAutoClicker);
        }

        private void btnEmployee_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Employee.ToString(), btnEmployee);
        }

        private void btnFarm_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Farm.ToString(), btnFarm);
        }

        private void btnFactory_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Factory.ToString(), btnFactory);
        }

        private void btnLab_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Lab.ToString(), btnLab);
        }

        private void btnPortal_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Portal.ToString(), btnPortal);
        }



        private void btnDoubleClick_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.DoubleClick1, scene.Clicker);
            scene.btnDoubleLock1 = true;
        }

        private void btnDoubleClick2_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.DoubleClick2, scene.Clicker);
            scene.btnDoubleLock2 = true;
        }

        private void btnDoubleClick3_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.DoubleClick3, scene.Clicker);
            scene.btnDoubleLock3 = true;
        }

        private void btnDoubleClick4_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.DoubleClick4, scene.Clicker);
            scene.btnDoubleLock4 = true;
        }

        private void btnDoubleClick5_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.DoubleClick5, scene.Clicker);
            scene.btnDoubleLock5 = true;
        }

        private void btnDoubleClick6_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.DoubleClick6, scene.Clicker);
            scene.btnDoubleLock6 = true;
        }

        private void btnDoubleClick7_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.DoubleClick7, scene.Clicker);
            scene.btnDoubleLock7 = true;
        }

        private void btnDoubleClick8_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.DoubleClick8, scene.Clicker);
            scene.btnDoubleLock8 = true;
        }

        private void btnMultiplier_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.Multiplier1, scene.Clicker);
            scene.btnLock1 = true;
        }

        private void btnMultiplier2_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.Multiplier2, scene.Clicker);
            scene.btnLock2 = true;
        }

        private void btnMultiplier3_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.Multiplier3, scene.Clicker);
            scene.btnLock3 = true;
        }

        private void btnMultiplier4_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.Multiplier4, scene.Clicker);
            scene.btnLock4 = true;
        }

        private void btnMultiplier5_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.Multiplier5, scene.Clicker);
            scene.btnLock5 = true;
        }

        private void btnMultiplier6_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.Multiplier6, scene.Clicker);
            scene.btnLock6 = true;
        }

        private void btnMultiplier7_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.Multiplier7, scene.Clicker);
            scene.btnLock7 = true;
        }

        private void btnMultiplier8_Click(object sender, EventArgs e)
        {
            scene.points.buyPurchase(scene.Multiplier8, scene.Clicker);
            scene.btnLock8 = true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog()== DialogResult.OK)
            {
                save(sfd.FileName);
            }
        }
        private void save(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, scene);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                read(ofd.FileName);
            }
        }
        private void read(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                IFormatter formatter = new BinaryFormatter();
                scene = (Scene)formatter.Deserialize(fs);
            }
        }

        private void btnWin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Честитки, победивте, дали сакате да почнете повторно со 2 пати поголема заработувачка?", "You win!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Upgrade.multiplier *= 2;
                scene = new Scene(Width, Height);
                //Upgrade.multiplier *= 2;
                scene.Clicker.clickValue *= 2;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сигурни ли сте дека сакате да почнете нова игра?","New Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                scene = new Scene(Width, Height);
            }
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stats stats = new Stats(scene);
            stats.Show();
        }
        
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credits credits = new Credits();
            credits.Show();
        }

        private void btnDoubleClick_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.DoubleClick1.ToString(), btnDoubleClick);
        }

        private void btnDoubleClick2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.DoubleClick2.ToString(), btnDoubleClick2);

        }

        private void btnDoubleClick3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.DoubleClick3.ToString(), btnDoubleClick3);

        }

        private void btnDoubleClick4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.DoubleClick4.ToString(), btnDoubleClick4);

        }

        private void btnDoubleClick5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.DoubleClick5.ToString(), btnDoubleClick5);

        }

        private void btnDoubleClick6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.DoubleClick6.ToString(), btnDoubleClick6);

        }

        private void btnDoubleClick7_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.DoubleClick7.ToString(), btnDoubleClick7);

        }

        private void btnDoubleClick8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.DoubleClick8.ToString(), btnDoubleClick8);

        }

        private void btnMultiplier_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Multiplier1.ToString(), btnMultiplier);
        }


        private void btnMultiplier2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Multiplier2.ToString(), btnMultiplier2);

        }

        private void btnMultiplier3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Multiplier3.ToString(), btnMultiplier3);

        }

        private void btnMultiplier4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Multiplier4.ToString(), btnMultiplier4);

        }

        private void btnMultiplier5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Multiplier5.ToString(), btnMultiplier5);

        }

        private void btnMultiplier6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Multiplier6.ToString(), btnMultiplier6);

        }

        private void btnMultiplier7_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Multiplier7.ToString(), btnMultiplier7);

        }

        private void btnMultiplier8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(scene.Multiplier8.ToString(), btnMultiplier8);

        }

        private void btnWin_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Победа", btnWin);

        }

        private void helpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Credits credits = new Credits();
            credits.Show();
        }
    }
}
