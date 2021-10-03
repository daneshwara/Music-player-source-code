using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musix
{
    public partial class formSplash : Form
    {
        Random ran = new Random();

        public formSplash()
        {
            InitializeComponent();
            
            //this.TransparencyKey = (BackColor);
            //this.BackColor = Color.White;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = System.Windows.Forms.FormWindowState.Normal;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(bunifuProgressBar1.Value==100)
            {
                timer1.Stop();
                this.Hide();
                new Form1().Show();
                return;
            }
            try
            {
                bunifuProgressBar1.Value += ran.Next(1, 1);
            }
            catch (Exception)
            {
                timer1.Stop();
                this.Hide();
                new Form1().Show();

            }
            

        }
    }
}
