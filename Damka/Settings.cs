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
    public partial class Settings : Form
    {
        public bool gameActive;
        public static int depth;
        public Settings(bool game)
        {
            InitializeComponent();
            depth = Main.depth;
            this.gameActive = game;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            depthBar.Value = depth;
            depthNumLbl.Text = depthBar.Value.ToString();

            if (Main.blackPlayer)
            {
                BlackRadio.Checked = true;
                WhiteRadio.Checked = false;
            }
            else
            {
                BlackRadio.Checked = false;
                WhiteRadio.Checked = true;
            }

            if(gameActive)
            {
                turnBox.Enabled = false;
            }
            else
            {
                turnBox.Enabled = true;
            }
                
        }

        private void LanBox_Enter(object sender, EventArgs e)
        {
           
        }

        private void depthBar_ValueChanged(object sender, EventArgs e)
        {
            depth = depthBar.Value;
            depthNumLbl.Text = depthBar.Value.ToString();
            Main.depth = depthBar.Value;
            RealTime.depth = depthBar.Value;
        }

        private void BlackRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (BlackRadio.Checked)
                Main.blackPlayer = true;
            else
                Main.blackPlayer = false;
        }
    }
}
