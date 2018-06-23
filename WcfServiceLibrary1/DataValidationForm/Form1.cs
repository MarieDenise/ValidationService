using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataValidationForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new
              ServiceReference1.Service1Client();
            int[] returnObj;

            returnObj = client.Validate();
            if(returnObj[4] == 0)
            {
                MessageBox.Show(" The Schema of the data is valid.  The number of objects parsed in the given links are " + returnObj[0] + " and " + returnObj[1] + "  The number of null occurences " + returnObj[2] + "  The number of parsing errror " + returnObj[3] );

            }
            else
            {
                MessageBox.Show(" The Schema of the data is invalid.  The number of objects parsed in the given links are " + returnObj[0] + " and " + returnObj[1] + "  The number of null occurences " + returnObj[2] + "  The number of parsing errror " + returnObj[3]);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
