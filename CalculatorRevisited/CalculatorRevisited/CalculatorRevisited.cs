using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Dnes bude vasim ukolem vytvorit formularovou reprezentaci kalkulacky. Priblizny vzhled si nakreslime na tabuli
 * (Pokud jsem to nenakreslil, pripomente mi to prosim!)
 * Inspirujte se kalkulackou ve Windows.
 * Pozadovane prvky/funkcionality:
 * - Tlacitka pro kazde z cisel 0-9
 * - Tlacitka pro operace +, -, *, a /
 * - Tlacitko pro = (vypsani vysledku)
 * - Textbox, do ktereho se propisou cisla/operace pri stisku jejich tlacitek
 * - Textbox s vysledkem operace (mozne sloucit s predeslym, nechavam na vas)
 * - Tlacitko pro vymazani textu v textboxu s cisly a operaci
 * 
 * Volitelne prvky/funkcionality:
 * - Tlacitko pro mazani cisel a operaci v textboxu zprava vzdy po jednom znaku
 * - Pokud mam vypsany vysledek a hned po tom stisknu tlacitko nejake operace, vysledek se vezme jako prvni cislo a
 *   rovnou mohu po zadani operace zadat druhe cislo
 * - Moznost ulozeni vysledku do nekolika preddefinovanych labelu/neinteraktivnich textboxu (treba kombinaci comboboxu a tlacitka, kde
 *   v comboboxu vyberu do ktereho labelu/textboxu se mi to ulozi a tlacitkem provedu ulozeni)
 *   + pridat tlacitko pro kazdy label/neint. textbox, kterym ulozeny vysledek pouziju jako cislo do vypoctu
 * - Pridani mocnin/odmocnin atd. (napr. pomoci dalsich tlacitek, ktere rovnou misto daneho cisla daji jeho (popr. zaokrouhlenou) odmocninu apod.)
 * - Cokoliv dalsiho vas napadne! :)
 * 
 * Snazte se o to, aby byla kalkulacka v ramci moznosti hezka, a aby bylo jeji ovladani intuitivni a aby mel kazdy prvek v okne dobre vyuziti
 */

namespace CalculatorRevisited
{
    public partial class CalculatorRevisited : Form
    {
        public bool operation = true;
        public CalculatorRevisited()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            if (operation)
            {
                textBox1.Text += "+";
                operation = false;
            }
            else
            {
                MessageBox.Show("you already have one operation you greedy");
            }
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            if (operation)
            {
                textBox1.Text += "-";
                operation = false;
            }
            else
            {
                MessageBox.Show("you already have one operation you greedy");
            }
        }

        private void button_multiply_Click(object sender, EventArgs e)
        {
            if (operation)
            {
                textBox1.Text += "*";
                operation = false;
            }
            else
            {
                MessageBox.Show("you already have one operation you greedy");
            }
        }

        private void button_divide_Click(object sender, EventArgs e)
        {
            if (operation)
            {
                textBox1.Text += "/";
                operation = false;
            }
            else
            {
                MessageBox.Show("you already have one operation you greedy");
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            operation = true;
        }

        private void button_ClearOne_Click(object sender, EventArgs e)
        {
            char[] list = textBox1.Text.ToCharArray();
            string newText = "";
            if (list[list.Length-1] == '+' || list[list.Length - 1] == '-' || list[list.Length - 1] == '/' || list[list.Length - 1] == '*')
            {
                operation = true;
            }
            for (int i = 0; i < list.Length - 1; i++)
            {
                newText += list[i];
            }
            textBox1.Text = newText;
        }

        private void button_Equal_Click(object sender, EventArgs e)
        {
            int number1 = 0;
            int number2 = 0;
            string deeznuts = "";
            char operationz = ' ';
            int operationzIndex = 0;
            int result = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (!int.TryParse(textBox1.Text[i].ToString(), out int resultz))
                {
                    operationzIndex = i;
                    operationz = textBox1.Text[i];
                }
            }
            for (int i = 0; i < operationzIndex; i++)
            {
                deeznuts += textBox1.Text[i];
            }
            number1 = int.Parse(deeznuts);
            deeznuts = "";
            for (int i = operationzIndex + 1; i < textBox1.Text.Length; i++)
            {
                deeznuts += textBox1.Text[i];
            }
            number2 = int.Parse(deeznuts);
            deeznuts = "";
            switch (operationz)
            {
                case '+':
                    result = number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
                case '*': 
                    result = number1 * number2;
                    break;
                case '/':
                    result = number1 / number2;
                    break;
            }
            textBox1.Text = result.ToString();
            operation = true;
        }
    }
}
