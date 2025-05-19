using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class gorsel : Form
    {

        public gorsel(byte[] resimVerisi)
        {
            InitializeComponent();
            if (resimVerisi != null)
            {
                using (MemoryStream ms = new MemoryStream(resimVerisi))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                MessageBox.Show("Bu araca ait görsel bulunamadı.");
            }
        }
        public Form5 frm5 = new Form5();
        FormResizer resizer = new FormResizer();
        

        private void gorsel_Load(object sender, EventArgs e)
        {
           resizer.CaptureInitialSizes(this);
            this.KeyPreview = true; // Klavye olaylarını önce formun yakalamasını sağlar

            this.MinimumSize = new Size(800, 500);//ilk baştaki boyut


        }

        private void gorsel_Resize(object sender, EventArgs e)
        {
            resizer.ResizeControls(this);
            // Form boyutunu değiştirdiğinizde, içeriği yeniden boyutlandırmak için gerekli kodu buraya ekleyebilirsiniz.
            // Örneğin, pictureBox1'in boyutunu formun boyutuna göre ayarlayabilirsiniz.
            /*if (pictureBox1.Image != null)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Size = new Size(this.Width - 20, this.Height - 20);
                pictureBox1.Location = new Point(10, 10);
            }*/

        }
    }
}
