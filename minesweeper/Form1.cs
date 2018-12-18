using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper
{


    public partial class Form1 : Form
    {
        //
        //Vars
        //
        byte counter = 0;
        Random rnd = new Random();
        int[] bom = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] linkerRand = { 0, 9, 18, 27, 36, 45, 54, 63, 72 };
        int[] rechterRand = { 8, 17, 26, 35, 44, 53, 62, 71, 80 };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (e as MouseEventArgs);
            if (me.Button == MouseButtons.Left)
            {
                int tag = int.Parse((sender as Button).Tag.ToString());
                string check = checkBoms(tag).ToString();
                (sender as Button).Enabled = false;
                (sender as Button).Text = check;
            }
            if (me.Button == MouseButtons.Right)
            {
                (sender as Button).Text = "?";
            }
            counter++;
            if (counter == 71)
            {
                MessageBox.Show("Gefeliciteerd!");
                initPLayField();
            }
        }
        private void Bomb_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (e as MouseEventArgs);
            if (me.Button == MouseButtons.Left)
            {
                (sender as Button).Enabled = false;
                (sender as Button).Text = "Bom";
                MessageBox.Show("Game over!");
                counter = 0;
                initPLayField();
            }
            if (me.Button == MouseButtons.Right)
            {
                (sender as Button).Text = "?";
            }
        }
        private void initBoms()
        {
            for (int i = 0; i < 10; i++)
            {
                bom[i] = rnd.Next(0, 81);
            }
            int[] boms = bom.Distinct().ToArray();
            if (boms.Length != bom.Length)
            {
                initBoms();
            }
        }
        private void initPLayField()
        {
            initBoms();
            for (int i = 0; i < 81; i++)
            {
                flowLayoutPanel1.Controls.RemoveAt(0);
            }
            for (int i = 0; i < 81; i++)
            {
                Button button = new Button();
                button.Tag = i;
                if (i == bom[0] || i == bom[1] || i == bom[2] || i == bom[3] || i == bom[4] || i == bom[5] || i == bom[6] || i == bom[7] || i == bom[8] || i == bom[9])
                {
                    button.MouseDown += Bomb_Click;
                }
                else
                {
                    button.MouseDown += Button_Click;
                }
                button.Size = new Size(50, 50);
                flowLayoutPanel1.Controls.Add(button);
            }
        }
        private int checkBoms(int value)
        {
            bool links = false;
            bool rechts = false;
            byte uit = 0;

            for (int i = 0; i < linkerRand.Length; i++)
            {
                if (linkerRand[i] == value)
                {
                    links = true;
                }
            }
            for (int i = 0; i < rechterRand.Length; i++)
            {
                if (rechterRand[i] == value)
                {
                    rechts = true;
                }
            }

            if (links == true && rechts == false)
            {
                for (int i = 0; i < bom.Length; i++)
                {
                    if ((value + 1) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value - 8) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value - 9) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value + 9) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value + 10) == bom[i])
                    {
                        uit += 1;
                    }
                }
            }
            if (links == false && rechts == false)
            {
                for (int i = 0; i < bom.Length; i++)
                {
                    if ((value - 1) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value + 1) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value - 8) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value + 8) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value - 9) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value + 9) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value - 10) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value + 10) == bom[i])
                    {
                        uit += 1;
                    }
                }
            }
            if (links == false && rechts == true)
            {
                for (int i = 0; i < bom.Length; i++)
                {
                    if ((value - 1) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value + 8) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value - 9) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value + 9) == bom[i])
                    {
                        uit += 1;
                    }
                    if ((value - 10) == bom[i])
                    {
                        uit += 1;
                    }
                }
            }

            return uit;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            initBoms();
            for (int i = 0; i < 81; i++)
            {
                Button button = new Button();
                button.Tag = i;
                if (i == bom[0] || i == bom[1] || i == bom[2] || i == bom[3] || i == bom[4] || i == bom[5] || i == bom[6] || i == bom[7] || i == bom[8] || i == bom[9])
                {
                    button.MouseDown += Bomb_Click;
                }
                else
                {
                    button.MouseDown += Button_Click;
                }
                button.Size = new Size(50, 50);
                flowLayoutPanel1.Controls.Add(button);

            }
        }
    }
}
