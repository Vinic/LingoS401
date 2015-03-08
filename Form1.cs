﻿using System;
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
        // De iGuesses is een integer die telt hoeveel keer er geraden is
        private int iGuesses;
        // De list sLingoAnswer heeft de chars van het woord dat geraden moet worden
        List<string> sLingoAnswer = new List<string>();
        // sLingoList is list met allemaal 6 letter woorden, die door een void willekeurig gekozen worden
        List<string> sLingoList = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
            // Geeft als eerste het input scherm weer, hier kan je een woord invoeren
            openInput();
            // De adds voegen de 6 letter woorden toe
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
            // Als er woord in de list zat wordt hij hier weggehaald 
            this.sLingoAnswer.Clear();
            // Initialiseert het andere input scherm
            Form2 LingoInput = new Form2();
            // Zorgt ervoor dat je niet iets kan doen met het hoofdscherm
            LingoInput.ShowDialog();
            // Haalt de text vanuit de input box
            string sAnswerInput = LingoInput.textBox1.Text;
            // Haalt elke char van de string op en zet het in het Answer list
            foreach (char sChar in sAnswerInput)
            {
                sLingoAnswer.Add("" + sChar);
            }
        }

        // Zelfde idee als bij openInput, maar hier wordt een willekeurig woord gekozen vanuit de LingoList door een random
        private void genLingo()
        {
            this.sLingoAnswer.Clear();
            Random _R = new Random();
            int R = _R.Next(0, sLingoList.Count);
            string sAnswerInput = sLingoList[R];
            foreach (char sChar in sAnswerInput)
            {
                sLingoAnswer.Add("" + sChar);
            }
            System.Console.WriteLine(sAnswerInput);
        }

        // De menuItem clicks zijn voor de gui knoppen
        private void menuItem1_Click(object sender, EventArgs e) { openInput(); }

        private void menuItem2_Click(object sender, EventArgs e) { genLingo();  }

        /*
         * De textBox_KeyDown_First, alleen KeyDown en Last zijn voor het invoeren van woord dat de gebruiker denkt dat het is
         * Dit is gemakkelijk doordat de tabs automatisch worden gedaan
         */
        private void textBox_KeyDown_First(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                
            }
            else
            {
                this.SelectNextControl(
                    ActiveControl,
                    forward: true,
                    tabStopOnly: true,
                    nested: true,
                    wrap: true
                );
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
                 
            if(e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                this.SelectNextControl(
                    ActiveControl,
                    forward: false,
                    tabStopOnly: true,
                    nested: true,
                    wrap: true
                );
            }
            else
            {
                this.SelectNextControl(
                    ActiveControl,
                    forward: true,
                    tabStopOnly: true,
                    nested: true,
                    wrap: true
                );
            }
        }

        private void textbox_KeyDown_Last(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                this.SelectNextControl(
                    ActiveControl,
                    forward: false,
                    tabStopOnly: true,
                    nested: true,
                    wrap: true
                );
            }
        }

        // Checkt of het woord van de gebruiker goed is
        private void button1_Click(object sender, EventArgs e)
        {   
            // Maak een nieuwe list aan van de gebruiker input
            List<string> sUserInput = new List<string>();

            // Maak een array van alle textboxes
            TextBox[] LTinput = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };
            TextBox[] LToutput = new TextBox[] { textBox7, textBox8, textBox9, textBox10, textBox11, textBox12 };

            // Voegt de waarde van elke input textbox toe aan sUserInput, als er niks in staat stopt het script en wordt het vakje rood
            foreach (TextBox item in LTinput)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    LTinput[1].BackColor = Color.Red;
                    return;
                }
                else
                {
                    sUserInput.Add(item.Text);
                    item.BackColor = Color.White;
                    item.Clear();
                }
                
            }

            // Zorgt ervoor dat alle chars in de sUserInput in de output wordt gezet 
            int iu = 0;
            foreach (TextBox item in LToutput)
            {
                item.Text = sUserInput[iu];
                iu++;  
            }

            /* Dit is de daadwerkelijke checker voor het woord, als het goed is worden alle vakjes groen, als de letter niet in het woord staat blijft het wit
             * Als de letter niet op de goede plek staat zal het vakje rood worden
             */
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
            // Telt het aantal keren dat er geraden is
            iGuesses++;
            // Zet de text van textbox13 gelijk aan de integer iGuesses
            textBox13.Text = "" + iGuesses;
        }
    
    }

}
