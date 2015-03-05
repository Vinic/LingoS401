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
        List<string> sLingoList = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
            openInput();
            sLingoList.Add("vissen");
            sLingoList.Add("banaan");
            sLingoList.Add("afhaal");
            sLingoList.Add("banken");
            sLingoList.Add("bedrog");
            sLingoList.Add("bewust");
            sLingoList.Add("braken");
            sLingoList.Add("chalet");
            sLingoList.Add("achten");
            sLingoList.Add("altijd");
            sLingoList.Add("zekers");
            sLingoList.Add("cursus");
            sLingoList.Add("cellen");
            sLingoList.Add("cabine");
            sLingoList.Add("regios");
            sLingoList.Add("ruilen");
        }
        
        private void openInput()
        {
            this.sLingoAnswer.Clear();
            Form2 LingoInput = new Form2();
            LingoInput.ShowDialog();
            string sAnswerInput = LingoInput.textBox1.Text;
            foreach (char sChar in sAnswerInput)
            {
                sLingoAnswer.Add("" + sChar);
            }
        }

        private void genLingo()
        {
            Random _R = new Random();
            int rand = _R.Next(0, sLingoList.Count);
            string sAnswerInput = sLingoList[rand];
            foreach (char sChar in sAnswerInput)
            {
                sLingoAnswer.Add("" + sChar);
            }
            System.Console.WriteLine(sAnswerInput);
        }

        private void menuItem1_Click(object sender, EventArgs e) { openInput(); }

        private void menuItem2_Click(object sender, EventArgs e) { genLingo();  }

        private void textBox_KeyDown(object sender, KeyEventArgs e) { SendKeys.Send("{TAB}"); }

        private void button1_Click(object sender, EventArgs e)
        {               
            List<string> sUserInput = new List<string>();
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
                    sUserInput.Add(item.Text);
                    item.BackColor = Color.White;
                    item.Clear();
                }
                
            }

            int iu = 0;
            foreach (TextBox item in LToutput)
            {
                item.Text = sUserInput[iu];
                iu++;  
            }

            int ia = 0;
            foreach (TextBox item in LToutput)
            {
                try
                {
                    if (sUserInput[ia] == sLingoAnswer[ia])
                    {
                        item.BackColor = Color.Green;
                    }
                    else if (sLingoAnswer.Contains(sUserInput[ia]))
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
