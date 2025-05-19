using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    internal class FormResizer
    {
        private Dictionary<Control, Rectangle> controlOriginalRects = new Dictionary<Control, Rectangle>();
        private Size formOriginalSize;

        public void CaptureInitialSizes(Form form)
        {
            formOriginalSize = form.Size;
            foreach (Control control in form.Controls)
            {
                controlOriginalRects[control] = new Rectangle(control.Location, control.Size);
            }
        }

        public void ResizeControls(Form form)
        {
            float xRatio = (float)form.Width / formOriginalSize.Width;
            float yRatio = (float)form.Height / formOriginalSize.Height;

            foreach (var entry in controlOriginalRects)
            {
                Control control = entry.Key;
                Rectangle originalRect = entry.Value;

                int newX = (int)(originalRect.X * xRatio);
                int newY = (int)(originalRect.Y * yRatio);
                int newWidth = (int)(originalRect.Width * xRatio);
                int newHeight = (int)(originalRect.Height * yRatio);

                control.Location = new Point(newX, newY);
                control.Size = new Size(newWidth, newHeight);
            }
        }
    }
}
