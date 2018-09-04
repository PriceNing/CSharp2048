using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Sharp2048
{
    public partial class Form1 : Form
    {
        int[,] map = new int[4,4];
        Image[] img = new Image[11];
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //初始化控件
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        PictureBox picUnit = new PictureBox();
                        picUnit.Height = 64;
                        picUnit.Width = 64;
                        picUnit.Margin = new Padding(0);
                        GameMapLayoutPanel.Controls.Add(picUnit, i, j);
                    }
                }
                //读取图像
                string[] imgNumber = Directory.GetFiles(@"./Skin/", "*.png");
                for (int i = 0; i < imgNumber.Length; i++)
                {
                    img[i] = Image.FromFile(imgNumber[i]);
                }
                //初始化棋盘数组
                map = Init(map);
                //刷新棋盘
                RefreshMap();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void RefreshMap()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (map[i,j])
                    {
                        case 2:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[0];
                            break;
                        case 4:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[1];
                            break;
                        case 8:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[2];
                            break;
                        case 16:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[3];
                            break;
                        case 32:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[4];
                            break;
                        case 64:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[5];
                            break;
                        case 128:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[6];
                            break;
                        case 256:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[7];
                            break;
                        case 512:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[8];
                            break;
                        case 1024:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[9];
                            break;
                        case 2048:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = img[10];
                            break;
                        case 0:
                            ((PictureBox)GameMapLayoutPanel.GetControlFromPosition(i, j)).Image = null;
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            label1.Text = score.ToString();
        }

        private int[,] Init(int[,] array)
        {
            Random rand = new Random();
            int randX_1 = rand.Next(0, 4);
            int randY_1 = rand.Next(0, 4);
            int randX_2 = rand.Next(0, 4);
            int randY_2 = rand.Next(0, 4);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    map[i, j] = 0;
                }
            }
            array[randX_1, randY_1] = 2;
            array[randX_2, randY_2] = 2;
            
            return array;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //按下上
            if (e.KeyCode == Keys.Up)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (j != 0)
                            {
                                if (map[i, j - 1] == 0)
                                {
                                    map[i, j - 1] = map[i, j];
                                    map[i, j] = 0;
                                }
                                else if (map[i, j - 1] == map[i, j])
                                {
                                    map[i, j - 1] = map[i, j] * 2;
                                    score += map[i, j - 1];
                                    map[i, j] = 0;
                                }
                            }

                        }
                    }
                }
                

            }
            //按下下
            if (e.KeyCode == Keys.Down)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (j != 3)
                            {
                                if (map[i, j + 1] == 0)
                                {
                                    map[i, j + 1] = map[i, j];
                                    map[i, j] = 0;
                                }
                                else if (map[i, j + 1] == map[i, j])
                                {
                                    map[i, j + 1] = map[i, j] * 2;
                                    score += map[i, j + 1];
                                    map[i, j] = 0;
                                }

                            }

                        }
                    }
                }
            }
            //按下右
            if (e.KeyCode == Keys.Right)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (i != 3)
                            {
                                if (map[i + 1, j] == 0)
                                {
                                    map[i + 1, j] = map[i, j];
                                    map[i, j] = 0;
                                }
                                else if (map[i + 1, j] == map[i, j])
                                {
                                    map[i + 1, j] = map[i, j] * 2;
                                    score += map[i + 1, j];
                                    map[i, j] = 0;
                                }

                            }

                        }
                    }
                }
            }
            //按下右
            if (e.KeyCode == Keys.Left)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (i != 0)
                            {
                                if (map[i - 1, j] == 0)
                                {
                                    map[i - 1, j] = map[i, j];
                                    map[i, j] = 0;
                                }
                                else if (map[i - 1, j] == map[i, j])
                                {
                                    map[i - 1, j] = map[i, j] * 2;
                                    score += map[i - 1, j];
                                    map[i, j] = 0;
                                }

                            }

                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (!IsGameOver())
                {
                    Random rand = new Random();
                    int count = 0;
                    while (true)
                    {
                        count++;
                        int randX_1 = rand.Next(0, 4);
                        int randY_1 = rand.Next(0, 4);
                        if (map[randX_1, randY_1] == 0)
                        {
                            map[randX_1, randY_1] = 2;
                            break;
                        }
                    }
                    RefreshMap();
                }
                else
                {
                    MessageBox.Show(string.Format("游戏结束，您的得分为{0}分！", score),"游戏结束");
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            map[i, j] = 0;
                        }
                    }
                    score = 0;
                    RefreshMap();
                }
            }
            
        }
        private bool IsGameOver()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (map[i,j] == 0)
                    {
                        count += 1;
                    }
                }
            }
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
