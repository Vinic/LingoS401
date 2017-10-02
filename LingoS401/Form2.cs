using System;
using System.Text.RegularExpressions;
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
            var rx = new Regex("[^A-Z|^a-z|^ |^\t]");
            if (rx.IsMatch(textBoxControl.Text))
                throw new Exception("Alleen letters zijn toegestaan");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Validate(textBox1);
                Close();
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message);
            }
        }
    }
}