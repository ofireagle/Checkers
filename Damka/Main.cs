using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Damka
{
    public partial class Main : Form
    {
        public static int depth = 10;
        public static bool blackPlayer = false; //defult that the first turn = white

        public Main()
        {
            InitializeComponent();
        }

       


        private void SingleButton_Click(object sender, EventArgs e)
        {
            RealTime singleFR = new RealTime(false, depth);
            singleFR.Show();
            singleFR.Invalidated += SingleFR_Invalidated;
        }

        private void SingleFR_Invalidated(object sender, InvalidateEventArgs e)
        {
            this.Show();
        }




        private void MultiButton_Click(object sender, EventArgs e)
        {
            RealTime MultiFR = new RealTime(true, depth);
            MultiFR.Show();
            MultiFR.Invalidated += MultiFR_Invalidated;
        }

        private void MultiFR_Invalidated(object sender, InvalidateEventArgs e)
        {
            this.Show();
        }



        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            About abtFR = new About(true); //true = abtTab
            abtFR.Show();
            abtFR.Invalidated += abtFR_Invalidated;
        }
        private void abtFR_Invalidated(object sender, InvalidateEventArgs e)
        {
            this.Show();
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            
            Settings stFR = new Settings(false);
            stFR.Show();
            stFR.Invalidated += stFR_Invalidated;
        }

        private void stFR_Invalidated(object sender, InvalidateEventArgs e)
        {
            this.Show();
        }

        private void InstructionButton_Click(object sender, EventArgs e)
        {
            About instFR = new About(false); //false = instTab
            instFR.Show();
            instFR.Invalidated += InstFR_Invalidated;
            
        }

        private void InstFR_Invalidated(object sender, InvalidateEventArgs e)
        {
            this.Show();
        }
    
    }
}
