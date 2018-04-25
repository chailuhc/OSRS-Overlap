using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRS_Overlap_Items
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {            
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true     

               
                using (Form form = new Form())
                {
                    form.Text = "OverLapped";
                    form.Size = new Size(arrAllFiles.Length * 25 + 60, arrAllFiles.Length * 25 + 60);
                    int x = 0;
                    int y = 0;
                    foreach (string i in arrAllFiles)
                    {
                        x += 60;
                    
                        PictureBox p = new PictureBox();
                        p.Size = new Size(60, 60);
                        p.BackgroundImage = SetImageOpacity(Image.FromFile(i), 1F);
                        p.BackgroundImageLayout = ImageLayout.Zoom;
                        p.Location = new Point(x, 0);
                        form.Controls.Add(p);

                    }
                     x = 0;
                     y = 0;
                    foreach (string i in arrAllFiles)
                    {
                        x += 60;

                        PictureBox p = new PictureBox();
                        p.Size = new Size(60, 60);
                        p.BackgroundImage = SetImageOpacity(Image.FromFile(i), 1F);
                        p.BackgroundImageLayout = ImageLayout.Zoom;
                        p.Location = new Point(0, x);
                        form.Controls.Add(p);

                    }
                    x = 0;
                    y = 0;

                    for(int i =0; i < arrAllFiles.Length; i++)
                    {

                        y += 60;
                        x = 0;
                        int count = 0;
                        for (int o = 0; o < arrAllFiles.Length; o++)
                        {
                            x += 60;

                            PictureBox p = new PictureBox();
                            p.Size = new Size(60, 60);
                            p.BackColor = Color.Transparent;
                            p.BackgroundImage = SetImageOpacity(Image.FromFile(arrAllFiles[i]), 1F);
                            p.BackgroundImageLayout = ImageLayout.Zoom;
                            p.Location = new Point(x, y);
                            form.Controls.Add(p);


                            PictureBox p2 = new PictureBox();
                            p2.Size = new Size(60, 60);
                            p2.BackColor = Color.Transparent;
                            p2.BackgroundImage = SetImageOpacity(Image.FromFile(arrAllFiles[count]), .5F);
                            p2.BackgroundImageLayout = ImageLayout.Zoom;
                            p2.Location = new Point(0, 0);
                            p.Controls.Add(p2);

                            count++;
                        }

                    }

                    form.ShowDialog();
                }
            }

           
        }

        public Image SetImageOpacity(Image image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = opacity;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
