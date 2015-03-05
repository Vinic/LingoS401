using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lingo
{
    public partial class Form1 : Form
    {
        int guesses = 0;
        List<string> sLingoAnswer = new List<string>();
        List<string> sLingoArr = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
            openInput();
            sLingoArr.Add("vissen");
            sLingoArr.Add("banaan");
            sLingoArr.Add("afhaal");
            sLingoArr.Add("banken");
            sLingoArr.Add("bedrog");
            sLingoArr.Add("bewust");
            sLingoArr.Add("braken");
            sLingoArr.Add("chalet");
            sLingoArr.Add("achten");
            sLingoArr.Add("altijd");
            sLingoArr.Add("zekers");
            sLingoArr.Add("cursus");
            sLingoArr.Add("cellen");
            sLingoArr.Add("cabine");
            sLingoArr.Add("regios");
            sLingoArr.Add("ruilen");
        }
        
        private void openInput()
        {
            this.sLingoAnswer.Clear();
            Form2 Lingoinput = new Form2();
            Lingoinput.ShowDialog();
            string sAnswerinput = Lingoinput.textBox1.Text;
            foreach (char sChar in sAnswerinput)
            {
                sLingoAnswer.Add("" + sChar);
            }
        }

        private void genLingo()
        {
            Random r = new Random();
            int rand = r.Next(0, sLingoArr.Count);
            string sAnswerinput = sLingoArr[rand];
            foreach (char sChar in sAnswerinput)
            {
                sLingoAnswer.Add("" + sChar);
            }
            System.Console.WriteLine(sAnswerinput);
        }

        private void menuItem1_Click(object sender, EventArgs e) { openInput(); }

        private void menuItem2_Click(object sender, EventArgs e) { genLingo();  }

        private void textBox_KeyDown(object sender, KeyEventArgs e) { SendKeys.Send("{TAB}"); }

        private void button1_Click(object sender, EventArgs e)
        {               
            List<string> sUserinput = new List<string>();
            TextBox[] LTinput = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };
            TextBox[] LToutput = new TextBox[] { textBox7, textBox8, textBox9, textBox10, textBox11, textBox12 };

            foreach (TextBox item in LTinput)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    item.BackColor = Color.Red;
                    return;
                }
                else
                {
                    sUserinput.Add(item.Text);
                    item.BackColor = Color.White;
                    item.Clear();
                }
                
            }

            int iu = 0;
            foreach (TextBox item in LToutput)
            {
                item.Text = sUserinput[iu];
                iu++;  
            }

            int ia = 0;
            foreach (TextBox item in LToutput)
            {
                try
                {
                    if (sUserinput[ia] == sLingoAnswer[ia])
                    {
                        item.BackColor = Color.Green;
                    }
                    else if (sLingoAnswer.Contains(sUserinput[ia]))
                    {
                        item.BackColor = Color.Red;           
                    }
                    else
                    {
                        item.BackColor = Color.White;
                    }
                    
                    ia++;
                }
                catch(Exception z)
                {
                    System.Console.WriteLine("Er ging iets fout, probeer het opnieuw: " + z);
                }               
            }
            System.Console.WriteLine("U heeft op de knop gedrukt.");
            guesses++;
            textBox13.Text = "" + guesses;
        }
    
    }

}
