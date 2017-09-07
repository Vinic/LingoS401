using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lingo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Validate(TextBox textBoxControl)
        {
            Regex rx = new Regex("[^A-Z|^a-z|^ |^\t]");
            if (rx.IsMatch(textBoxControl.Text))
                throw new Exception("Alleen letters zijn toegestaan");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Validate(textBox1);
                this.Close();
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message);
            }
            
        }
    }
}
