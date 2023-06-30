using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.Util;
using System.IO;

namespace Kursach
{
    public partial class Form2 : Form
    {
        private Image<Bgr, byte> image = null;

        private string fileName = string.Empty;
        internal Point startPoint;

        public Form2(Image<Bgr, byte> image)
        {
            this.image = image;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;

            fileName = $"WCVC_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.jpg";

            pictureBox1.Image = image.Bitmap;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
    
            startPoint = Cursor.Position;//при нажатии кнопки мыши по panel запоминаем абсолютные координаты указателя мыши.
           
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)//события "отпускания" кнопки мыши
        {
                Size size = new Size(Math.Abs(startPoint.X - Cursor.Position.X), Math.Abs(startPoint.Y - Cursor.Position.Y));//вычисляем размер выделенной области
                var bm = new Bitmap(size.Width, size.Height);// создаем bitmap заданного размера

                Graphics graphics = Graphics.FromImage(bm as Image);

                graphics.CopyFromScreen(startPoint, new Point(0, 0), bm.Size); //копируем часть изображения экрана в bitmap

                pictureBox2.Image = bm; //выводим в picturebox
       
        }
 

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox3.Image.Save(fileName, ImageFormat.Jpeg);

                if (File.Exists(fileName))  
                {
                    Close();
                }
                else
                {
                    throw new Exception("Не удалось сохранить изображение");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null) // если изображение в pictureBox1 имеется
            {
                int P = 235;
                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap bmpImg = new Bitmap(pictureBox2.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap result = new Bitmap(bmpImg.Width, bmpImg.Height);
                // перебираем в циклах все пиксели исходного изображения
                Color color = new Color();
                try
                {
                    for (int j = 0; j < bmpImg.Height; j++)
                    {
                        for (int i = 0; i < bmpImg.Width; i++)
                        {
                            color = bmpImg.GetPixel(i, j);
                            int K = (color.R + color.G + color.B) / 3;
                            result.SetPixel(i, j, K <= P ? Color.Black : Color.White);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // выводим черно-белый Bitmap в pictureBox2
                pictureBox3.Image = result;

                int width, height, min_height, max_height;
                int led_position0, led_position1, led_position2, led_position3, led_position4, led_position5, led_position6, led_position7, led_position8, led_position9;
                
                bool flag0 = false;
                bool flag1 = false;
                bool flag2 = false;
                bool flag3 = false;
                bool flag4 = false;
                bool flag5 = false;
                bool flag6 = false;
                bool flag7 = false;
                bool flag8 = false;
                bool flag9 = false;


                string message = "";

                height = result.Height;
                width = result.Width;

                min_height = (int)Math.Floor(height * 0.825);
                max_height = (int)Math.Ceiling(height * 0.85);


                Console.WriteLine(height);
                Console.WriteLine(width);
                Console.WriteLine(min_height);
                Console.WriteLine(max_height);
                
                

                led_position9 = (int)Math.Round(width * 0.51546);
                led_position8 = (int)Math.Round(width * 0.567);
                led_position7 = (int)Math.Round(width * 0.61856);
                led_position6 = (int)Math.Round(width * 0.6701);
                led_position5 = (int)Math.Round(width * 0.72165);
                led_position4 = (int)Math.Round(width * 0.773196);
                led_position3 = (int)Math.Round(width * 0.82474);
                led_position2 = (int)Math.Round(width * 0.87629);
                led_position1 = (int)Math.Round(width * 0.92784);
                led_position0 = (int)Math.Round(width * 0.97938);

                Console.WriteLine(led_position9);
                Console.WriteLine(led_position8);
                Console.WriteLine(led_position7);
                Console.WriteLine(led_position6);
                Console.WriteLine(led_position5);
                Console.WriteLine(led_position4);
                Console.WriteLine(led_position3);
                Console.WriteLine(led_position2);
                Console.WriteLine(led_position1);
                Console.WriteLine(led_position0);

               for (int j = min_height; j < max_height; j++)
                {
                    for(int i = led_position9 - 2; i < led_position9 + 2; i++)
                    {
                        color = result.GetPixel(i, j);
                        if ((color.R == 255) && (color.G == 255) && (color.B == 255))
                        {
                            flag9 = true;
                        }
                    }
                    for (int i = led_position8 - 2; i < led_position8 + 2; i++)
                    {
                        color = result.GetPixel(i, j);
                        if ((color.R == 255) && (color.G == 255) && (color.B == 255))
                        {
                            flag8 = true;
                        }
                    }
                    for (int i = led_position7 - 2; i < led_position7 + 2; i++)
                    {
                        color = result.GetPixel(i, j);
                        if ((color.R == 255) && (color.G == 255) && (color.B == 255))
                        {
                            flag7 = true;
                        }
                    }
                    for (int i = led_position6 - 2; i < led_position6 + 2; i++)
                    {
                        color = result.GetPixel(i, j);
                        if ((color.R == 255) && (color.G == 255) && (color.B == 255))
                        {
                            flag6 = true;
                        }
                    }
                    for (int i = led_position5 - 2; i < led_position5 + 2; i++)
                    {
                        color = result.GetPixel(i, j);
                        if ((color.R == 255) && (color.G == 255) && (color.B == 255))
                        {
                            flag5 = true;
                        }
                    }
                    for (int i = led_position4 - 2; i < led_position4 + 2; i++)
                    {
                        color = result.GetPixel(i, j);
                        if ((color.R == 255) && (color.G == 255) && (color.B == 255))
                        {
                            flag4 = true;
                        }
                    }
                    for (int i = led_position3 - 2; i < led_position3 + 2; i++)
                    {
                        color = result.GetPixel(i, j);
                        if ((color.R == 255) && (color.G == 255) && (color.B == 255))
                        {
                            flag3 = true;
                        }
                    }
                    for (int i = led_position2 - 2; i < led_position2 + 2; i++)
                    {
                        color = result.GetPixel(i, j);
                        if ((color.R == 255) && (color.G == 255) && (color.B == 255))
                        {
                            flag2 = true;
                        }
                    }
                    for (int i = led_position1 - 2; i < led_position1 + 2; i++)
                    {
                        color = result.GetPixel(i, j);
                        if ((color.R == 255) && (color.G == 255) && (color.B == 255))
                        {
                            flag1 = true;
                        }
                    }
                    for (int i = led_position0 - 2; i < led_position0 + 2; i++)
                    {
                        color = result.GetPixel(i, j);
                        if ((color.R == 255) && (color.G == 255) && (color.B == 255))
                        {
                            flag0 = true;
                        }                    
                    }
                }

               if (flag0 == true)
               {
                    message = message + "Led0 is ON ";
               }
               else
               {
                    message = message + "Led0 is Off ";
               }
              
                if (flag1 == true)
               {
                    message = message + "Led1 is ON ";
               }
               else
               {
                    message = message + "Led1 is Off ";
               }
               
                if (flag2 == true)
               {
                    message = message + "Led2 is ON ";
               }
               else
               {
                    message = message + "Led2 is Off ";
               }
               
               if (flag3 == true)
               {
                    message = message + "Led3 is ON ";
               }
               else
               {
                    message = message + "Led3 is Off ";
               }
                
               if (flag4 == true)
               {
                    message = message + "Led4 is ON ";
               }
               else
               {
                    message = message + "Led4 is Off ";
               }

                if (flag5 == true)
                {
                    message = message + "Led5 is ON ";
                }
                else
                {
                    message = message + "Led5 is Off ";
                }

                if (flag6 == true)
                {
                    message = message + "Led6 is ON ";
                }
                else
                {
                    message = message + "Led6 is Off ";
                }

                if (flag7 == true)
                {
                    message = message + "Led7 is ON ";
                }
                else
                {
                    message = message + "Led7 is Off ";
                }

                if (flag8 == true)
                {
                    message = message + "Led8 is ON ";
                }
                else
                {
                    message = message + "Led8 is Off ";
                }

                if (flag9 == true)
                {
                    message = message + "Led9 is ON ";
                }
                else
                {
                    message = message + "Led9 is Off ";
                }

                MessageBox.Show(message);
                
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
