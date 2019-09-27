using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BURLAK
{
    public partial class Form1 : Form
    {
        public string filename;
        public Form1()
        {

            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //открыть файл
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                filename = openFileDialog1.FileName;
                //вставляем в окно
                Bitmap image1 = new Bitmap(filename);
                pictureBox1.Size = new System.Drawing.Size(150, 150);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                pictureBox1.Image = image1;
            }
            catch
            {
                MessageBox.Show("Взяли не картинку");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                //запускаем стрим
                Stream myStream;
                //выбираем путь сохранения
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "picture (*.jpg)|*.jpg|All files (*.jpg)|*.jpg",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };
                //если путь доступен то сохраняем как нужно
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        //Bitmap bmp = new Bitmap(Image.FromFile(filename), 555, 555);
                        //bmp.Dispose();

                        Bitmap b1 = new Bitmap(openFileDialog1.FileName);
                        Bitmap b2 = new Bitmap(b1, new Size(Convert.ToInt32(X.Text), Convert.ToInt32(Y.Text)));
                        b2.Save(saveFileDialog1.FileName + ".jpg ");
                        MessageBox.Show(saveFileDialog1.FileName + ".jpg " + " с размерами " + X.Text + " на " + Y.Text);
                        //  bmp.Save(saveFileDialog1.FileName);

                    }
                }

            }
            catch
            {
                MessageBox.Show("Не указали формат фотографии или указали в папку куда сохранить нельзя!");
            }
        }

    } }

