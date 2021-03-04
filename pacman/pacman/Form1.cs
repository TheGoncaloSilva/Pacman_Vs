using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman
{
    public partial class Form1 : Form
    {
        public int cpf = 0;
        public int[] pf1 = new int[2];
        public int[,] pf = new int[2, 4];
        public int[] pf2 = new int[2];
        public int[,] tab;
        public int lives = 3;
        public int num = 0;
        public int intl = 9;
        public int intc = 8;
        public int sr = 0;
        public int lp = 7;
        public int cp = 8;
        public int lin = 0;
        public int col = 0;
        public int score = 0;
        public double[] intn=new double[4];
        public int comer = 0;
        public int comeraux = 0;

        public Form1()
        {
            InitializeComponent();
        }
        public void fechar()
        {
            MessageBox.Show("A sua pontuação é de: " + score);
            this.Close();
        }

        public void escrever()
        {
           
            for (int c = 0; c < 16; c++)
            {
                for (int l = 0; l < 17; l++)
                {
                    if (tab[c, l] == 0)
                    {
                        dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\Black2.png");
                    }
                    else if (tab[c, l] == 1)
                    {
                        dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\pacblue.png");
                    }
                    else if (tab[c, l] == 2)
                    {
                        dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\pacblue.png");
                    }
                    else if (tab[c, l] == 3)
                    {
                        dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\barrra.png");
                    }
                    else if (tab[c, l] == 4)
                    {
                        dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\pacmanim.png");
                    }
                    else if (tab[c, l] == 5)
                    {
                        dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\Black.png");
                    }
                    else if (tab[c, l] == 6)
                    {
                        if (comeraux == 0)
                        {
                            dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\fant1.png");
                        }
                        else
                        {
                            dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\fant3.png");
                        }
                    }
                    else if (tab[c, l] == 7)
                    {
                        dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\Black.png");
                    }
                    else if (tab[c, l] == 8)
                    {
                        dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\Black1.png");
                    }
                    else if (tab[c, l] == 9)
                    {
                        if (comeraux == 0)
                        {
                            dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\fant2.png");
                        }
                        else
                        {
                            dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\fant3.png");
                        }
                    }
                    else if(tab[c, l] == 10)
                    {
                        dataGridView1.Rows[c].Cells[l].Value = Image.FromFile(Application.StartupPath + "\\Imagens\\Black.png");
                    }

                    else
                    {
                        MessageBox.Show("ERROR");
                    }
                }
            }
            if (lives == 3)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "//Imagens/pacmanim.png");
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "//Imagens/pacmanim.png");
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "//Imagens/pacmanim.png");
            }
            else if (lives == 2)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "//Imagens/pacmanim.png");
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "//Imagens/pacmanim.png");
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "//Imagens/Black.png");
            }
            else if (lives == 1)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "//Imagens/pacmanim.png");
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "//Imagens/Black.png");
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "//Imagens/Black.png");
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                fechar();
            }
            label1.Text = score.ToString();
        }

        public void fantasmas()
        {
            pf2[0] = lp;
            pf2[1] = cp;
            cpf = 0;
            sr = 0;
            Array.Clear(pf, 0, 3);

            if (lp + 1 < 16)
            {
                if (tab[lp + 1, cp] == 0 || tab[lp + 1, cp] == 7 || tab[lp + 1, cp] == 8)
                {
                    pf[0, cpf] = lp + 1;
                    pf[1, cpf] = cp;

                    cpf++;
                    sr++;
                }else if(tab[lp + 1, cp] == 4 && comeraux==0)
                {
                    lives--;
                }
            }
            if (lp - 1 >= 0)
            {
                if (tab[lp - 1, cp] == 0 || tab[lp - 1, cp] == 7 || tab[lp - 1, cp] == 8)
                {
                    pf[0, cpf] = lp - 1;
                    pf[1, cpf] = cp;

                    cpf++;
                    sr++;
                }
                else if (tab[lp - 1, cp] == 4 && comeraux == 0)
                {
                    lives--;
                }
            }
            if (cp + 1 < 17)
            {
                if (tab[lp, cp + 1] == 0 || tab[lp, cp + 1] == 7 || tab[lp, cp + 1] == 8)
                {
                    pf[0, cpf] = lp;
                    pf[1, cpf] = cp + 1;

                    cpf++;
                    sr++;
                }
                else if (tab[lp, cp + 1] == 4 && comeraux == 0)
                {
                    lives--;
                }
            }
            if (cp - 1 >= 0)
            {
                if (tab[lp, cp - 1] == 0 || tab[lp, cp - 1] == 7 || tab[lp, cp - 1] == 8)
                {
                    pf[0, cpf] = lp;
                    pf[1, cpf] = cp - 1;

                    cpf++;
                    sr++;
                }
                else if (tab[lp, cp - 1] == 4 && comeraux == 0)
                {
                    lives--;
                }
            }
        }

        public double ai()
        {
            int cont = 0;
            double choose;
            int aux = 0;
            Array.Clear(intn, 0, 4);
            if (intl + 1 < 16)
            {
                if (tab[intl + 1, intc] == 0 || tab[intl + 1, intc] == 7 || tab[intl + 1, intc] == 8 || tab[intl + 1, intc] == 3)
                {
                    intn[cont] = Math.Sqrt((((intl + 1) - lin) * ((intl + 1) - lin)) + ((intc - col) * (intc - col)));
                    cont++;
                    

                }else if(tab[intl + 1, intc] == 4 && comeraux == 0)
                {
                    lives--;
                }
            }
            if (intl - 1 >= 0)
            {
                if (tab[intl - 1, intc] == 0 || tab[intl - 1, intc] == 7 || tab[intl - 1, intc] == 8 || tab[intl - 1, intc] == 3)
                {
                    intn[cont] = Math.Sqrt((((intl - 1) - lin) * ((intl - 1) - lin)) + ((intc - col) * (intc - col)));
                    cont++;
                    
                }
                else if (tab[intl - 1, intc] == 4 && comeraux == 0)
                {
                    lives--;
                }
            }
            if (intc + 1 < 17)
            {
                if (tab[intl, intc + 1] == 0 || tab[intl, intc + 1] == 7 || tab[intl, intc + 1] == 8 || tab[intl, intc + 1] == 3)
                {
                    intn[cont] = Math.Sqrt(((intl - lin) * (intl - lin)) + (((intc + 1) - col) * ((intc + 1) - col)));
                    cont++;
                    
                }
                else if (tab[intl, intc + 1] == 4 && comeraux == 0)
                {
                    lives--;
                }
            }
            if (intc - 1 >= 0)
            {
                if (tab[intl, intc - 1] == 0 || tab[intl, intc - 1] == 7 || tab[intl, intc - 1] == 8 || tab[intl, intc - 1] == 3)
                {
                    intn[cont] = Math.Sqrt(((intl - lin) * (intl - lin)) + (((intc - 1) - col) * ((intc - 1) - col)));
                    cont++;
                    
                }
                else if (tab[intl, intc - 1] == 4 && comeraux == 0)
                {
                    lives--;
                }
            }
            for (int i = 0; i <= 3; i++)
            {
                if (intn[i] != 0)
                {
                    aux++;
                }
            }
            choose = intn[0];

            if (comeraux == 0)
            {
                for (int i = 1; i < aux; i++)
                {
                    if (choose > intn[i])
                    {
                        choose = intn[i];
                    }
                }
            }
            else
            {
                for (int i = 1; i < aux; i++)
                {
                    if (choose < intn[i])
                    {
                        choose = intn[i];
                    }
                }
            }

            return choose;
        }
        public void fant1()
        {
            score += 2000;
            tab[lp, cp] = 0;
            lp = 7;
            cp = 8;
            tab[lp, cp] = 6;
        }
        public void fant2()
        {
            score += 4000;
            tab[intl, intc] = 0;
            intl = 9;
            intc = 8;
            tab[intl, intc] = 9;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
                    tab = new int[,] {{ 4, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0 },
                                      { 8, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 8 },
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0 },
                                      { 0, 0, 0, 0, 1, 0, 0, 8, 1, 8, 0, 0, 1, 0, 0, 0, 0 },
                                      { 2, 2, 2, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 2, 2, 2 },
                                      { 2, 2, 2, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 2, 2, 2 },
                                      { 5, 10, 10, 0, 1, 0, 1, 1, 3, 1, 1, 0, 1, 0, 10, 10, 5 },
                                      { 2, 2, 2, 0, 1, 0, 1, 7, 9, 7, 1, 0, 1, 0, 2, 2, 2 },
                                      { 2, 2, 2, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 2, 2, 2 },
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0 },
                                      { 8, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 8 },
                                      { 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1 },
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};
                                     
            

            // 5- mudar de posição ; 4- pacman; 3- barreira dos maus; 2- espaço vazio; 1-paredes
            // 6- fantasmas; 7-preto com bolas amarelas; 8- bolas amarelas grandes
          
            for (int l = 0; l < 16; l++)
            {
                dataGridView1.Rows.Add();
            }

            
            escrever();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down && lin + 2 < 17 || e.KeyCode == Keys.S && lin + 2 < 17)
            {
                if(tab[lin + 1, col] == 0 || tab[lin+1,col]==4 || tab[lin + 1, col] == 7 || tab[lin + 1, col] == 8 || tab[lin + 1, col] == 6 || tab[lin + 1, col] == 9)
                {
                    if (tab[lin+1, col]== 0 || tab[lin + 1, col] == 4 || tab[lin + 1, col] == 7)
                    {
                        score +=10;
                        tab[lin + 1, col] = 4;
                        tab[lin, col] = 7;
                        lin++;

                    }
                    else if (tab[lin + 1, col] == 8)
                    {
                        score += 100;
                        tab[lin + 1, col] = 4;
                        tab[lin, col] = 7;
                        lin++;
                        comeraux=1;

                    }
                    else if (tab[lin + 1, col] == 6 && comeraux == 0 || tab[lin + 1, col] == 9 && comeraux==0)
                    {
                        lives--;
                    }
                    else if(tab[lin + 1, col] == 6 && comeraux != 0)
                    {
                        fant1();
                    }
                    else if (tab[lin + 1, col] == 9 && comeraux != 0)
                    {
                        fant2();
                    }

                }
                
            }
            else if (e.KeyCode == Keys.Up && lin - 1 >= 0 || e.KeyCode == Keys.W && lin - 1 >= 0)
            {
                if (tab[lin - 1, col] == 0 || tab[lin - 1, col] == 4 || tab[lin - 1, col] == 7 || tab[lin - 1, col] == 8 || tab[lin - 1, col] == 6 || tab[lin - 1, col] == 9)
                {
                    if (tab[lin - 1, col] == 0 || tab[lin - 1, col] == 4 || tab[lin - 1, col] == 7)
                    {
                        score += 10;
                        tab[lin - 1, col] = 4;
                        tab[lin, col] = 7;
                        lin--;
                    }
                    else if (tab[lin - 1, col] == 8)
                    {
                        score += 100;
                        tab[lin - 1, col] = 4;
                        tab[lin, col] = 7;
                        lin--;
                        comeraux=1;
                    }
                    else if (tab[lin - 1, col] == 6 && comeraux == 0 || tab[lin - 1, col] == 9 && comeraux == 0)
                    {
                        lives--;
                    }
                    else if (tab[lin - 1, col] == 6 && comeraux != 0)
                    {
                        fant1();
                    }
                    else if (tab[lin - 1, col] == 9 && comeraux != 0)
                    {
                        fant2();
                    }
                } 
                  
            }
            else if (e.KeyCode == Keys.Right && col + 2 < 18 || e.KeyCode == Keys.D && col + 2 < 18 )
            {
                if (tab[lin, col + 1] == 5)
                {
                    
                    tab[8, 1] = 4;
                    tab[lin, col] = 5;
                    lin = 8;
                    col = 1;
                    
                }
                else if(tab[lin,col+1]==0 || tab[lin , col+1] == 4 || tab[lin, col+1] == 7 || tab[lin, col+1] == 8 || tab[lin, col + 1] == 6 || tab[lin, col + 1] == 9 || tab[lin, col + 1] == 10)
                {
                    if (tab[lin, col+1] == 0 || tab[lin, col + 1] == 4 || tab[lin, col + 1] == 7 || tab[lin, col + 1] == 10)
                    {
                        score += 10;
                        tab[lin, col + 1] = 4;
                        tab[lin, col] = 7;
                        col++;
                    }
                    else if (tab[lin, col+1] == 8)
                    {
                        score += 100;
                        tab[lin, col + 1] = 4;
                        tab[lin, col] = 7;
                        col++;
                        comeraux=1;
                    }
                    else if (tab[lin, col + 1] == 6 && comeraux == 0 || tab[lin, col + 1] == 9 && comeraux == 0)
                    {
                        lives--;
                    }
                    else if (tab[lin, col + 1] == 6 && comeraux != 0)
                    {
                        fant1();
                    }
                    else if (tab[lin, col + 1] == 9 && comeraux != 0)
                    {
                        fant2();
                    }
                }
            }

            else if (e.KeyCode == Keys.Left && col - 1 >= 0 || e.KeyCode == Keys.A && col - 1 >= 0)
            {
                if (tab[lin, col - 1] == 5)
                {
                   
                    tab[8, 15] = 4;
                    tab[lin, col] = 5;
                    lin = 8;
                    col = 15;
                    
                }
                else if(tab[lin,col-1]==0 || tab[lin, col-1] == 4 || tab[lin, col-1] == 7 || tab[lin, col-1] == 8 || tab[lin, col - 1] == 6 || tab[lin, col - 1] == 9 || tab[lin, col - 1] == 10)
                {
                    if (tab[lin, col - 1] == 0 || tab[lin, col - 1] == 4 || tab[lin, col - 1] == 7 || tab[lin, col - 1] == 10)
                    {
                        score += 10;
                        tab[lin, col - 1] = 4;
                        tab[lin, col] = 7;
                        col--;
                    }
                    else if (tab[lin, col - 1] == 8)
                    {
                        score += 100;
                        tab[lin, col - 1] = 4;
                        tab[lin, col] = 7;
                        col--;
                        comeraux=1;
                    }
                    else if (tab[lin, col - 1] == 6 && comeraux == 0 || tab[lin, col - 1] == 9 && comeraux == 0)
                    {
                        lives--;
                    }
                    else if (tab[lin, col - 1] == 6 && comeraux != 0)
                    {
                        fant1();
                    }
                    else if (tab[lin, col - 1] == 9 && comeraux != 0)
                    {
                        fant2();
                    }

                }

            }
            
            escrever();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fechar();
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fantasmas();
            Random RNG = new Random();
            int saber = RNG.Next(0, sr);
            pf1[0] = pf[0, saber];
            pf1[1] = pf[1, saber];
            num = tab[pf1[0], pf1[1]];
            tab[pf1[0], pf1[1]] = 6;
            tab[pf2[0], pf2[1]] = num;
            lp = pf1[0];
            cp = pf1[1];
            escrever();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            double vr;
            vr=ai();
            if (comer > 15)
            {
                comeraux = 0;
                comer = 0;
            }

            if (comeraux != 0)
            {
                comer++;
            }
            if (intl + 1 < 16)
            {
                if (tab[intl + 1, intc] == 0 || tab[intl + 1, intc] == 7 || tab[intl + 1, intc] == 8)
                {
                    if (Math.Sqrt((((intl + 1) - lin) * ((intl + 1) - lin)) + ((intc - col) * (intc - col))) == vr)
                    {
                        if (tab[intl + 1, intc] == 0)
                        {
                            tab[intl + 1, intc] = 9;
                            tab[intl , intc] = 0;
                            intl++;
                        }
                        else if (tab[intl + 1, intc] == 7)
                        {
                            tab[intl + 1, intc] = 9;
                            tab[intl, intc] = 7;
                            intl++;
                        }
                        else if(tab[intl + 1, intc] == 8)
                        {
                            tab[intl + 1, intc] = 9;
                            tab[intl, intc] = 8;
                            intl++;
                        }
                    }
                   
                }
            }
            if (intl - 1 >= 0)
            {
                if (tab[intl - 1, intc] == 0 || tab[intl - 1, intc] == 7 || tab[intl - 1, intc] == 8 || tab[intl - 1, intc] == 3)
                {
                    if (Math.Sqrt((((intl - 1) - lin) * ((intl - 1) - lin)) + ((intc - col) * (intc - col))) == vr)
                    {
                        if (tab[intl - 1, intc] == 0)
                        {
                            tab[intl - 1, intc] = 9;
                            tab[intl, intc] = 0;
                            intl--;
                        }
                        else if (tab[intl - 1, intc] == 7)
                        {
                            tab[intl - 1, intc] = 9;
                            tab[intl, intc] = 7;
                            intl--;
                        }
                        else if (tab[intl - 1, intc] == 8)
                        {
                            tab[intl - 1, intc] = 9;
                            tab[intl, intc] = 8;
                            intl--;
                        }
                        else if (tab[intl - 1, intc] == 3)
                        {
                            tab[intl - 2, intc] = 9;
                            tab[intl-1, intc] = 3;
                            tab[intl, intc] = 10;
                            intl-=2;
                        }
                    }
                }

                
            }
            if (intc + 1 < 17)
            {
                if (tab[intl, intc + 1] == 0 || tab[intl, intc + 1] == 7 || tab[intl, intc + 1] == 8)
                {
                    if( Math.Sqrt(((intl - lin) * (intl - lin)) + (((intc + 1) - col) * ((intc + 1) - col))) == vr)
                    {
                        if (tab[intl , intc + 1] == 0)
                        {
                            tab[intl, intc + 1] = 9;
                            tab[intl, intc] = 0;
                            intc++;
                        }
                        else if (tab[intl , intc + 1] == 7)
                        {
                            tab[intl, intc + 1] = 9;
                            tab[intl, intc] = 7;
                            intc++;
                        }
                        else if (tab[intl, intc + 1] == 8)
                        {
                            tab[intl, intc + 1] = 9;
                            tab[intl, intc] = 8;
                            intc++;
                        }
                    }
                }
            }
            if (intc - 1 >= 0)
            {
                if (tab[intl, intc - 1] == 0 || tab[intl, intc - 1] == 7 || tab[intl, intc - 1] == 8)
                {
                    if (Math.Sqrt(((intl - lin) * (intl - lin)) + (((intc - 1) - col) * ((intc - 1) - col))) == vr)
                    {
                        if (tab[intl, intc - 1] == 0)
                        {
                            tab[intl, intc - 1] = 9;
                            tab[intl, intc] = 0;
                            intc--;
                        }
                        else if (tab[intl, intc - 1] == 7)
                        {
                            tab[intl, intc - 1] = 9;
                            tab[intl, intc] = 7;
                            intc--;
                        }
                        else if (tab[intl, intc - 1] == 8)
                        {
                            tab[intl, intc - 1] = 9;
                            tab[intl, intc] = 8;
                            intc--;
                        }
                    }

                }
            }
            escrever();
            listBox1.Items.Add("lin + 1 ");
            listBox1.Items.Add(Math.Sqrt((((intl + 1) - lin) * ((intl + 1) - lin)) + ((intc - col) * (intc - col))));
            listBox1.Items.Add("lin - 1 ");
            listBox1.Items.Add(Math.Sqrt((((intl - 1) - lin) * ((intl - 1) - lin)) + ((intc - col) * (intc - col))));
            listBox1.Items.Add("col + 1 ");
            listBox1.Items.Add(Math.Sqrt(((intl - lin) * (intl - lin)) + (((intc + 1) - col) * ((intc + 1) - col))));
            listBox1.Items.Add("col - 1 ");
            listBox1.Items.Add(Math.Sqrt(((intl - lin) * (intl - lin)) + (((intc - 1) - col) * ((intc - 1) - col))));
            listBox1.Items.Add(1);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
