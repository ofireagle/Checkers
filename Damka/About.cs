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
    public partial class About : Form
    {
        //flag(true) = about tab  flag(false) = instructions tab
        public About(bool flag)
        {
            InitializeComponent();
            if (flag)
                tabControl1.SelectedTab = abtPage;
            else
                tabControl1.SelectedTab = instPage;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
