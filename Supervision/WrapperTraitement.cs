using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;

namespace Supervision
{
    class WrapperTraitement
    {
        [DllImport("traitement.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void traitementMnMs(StringBuilder res, IntPtr data, int stride, int nbLig, int nbCol);

        // string = total - rouge - orange - bleu - marron - jaune
        public static string TraitementMnMs(Bitmap bmp)
        {
            StringBuilder str = new StringBuilder();
            unsafe
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                try
                {
                    traitementMnMs(str, bmpData.Scan0, bmpData.Stride, bmp.Height, bmp.Width);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                bmp.UnlockBits(bmpData);
            }

            return str.ToString();
        }

        [DllImport("traitement.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void traitementSecurity(StringBuilder res, IntPtr data, int stride, int nbLig, int nbCol);

        public static string TraitementSecurity(Bitmap bmp)
        {
            StringBuilder str = new StringBuilder();
            unsafe
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                try
                {
                    traitementSecurity(str, bmpData.Scan0, bmpData.Stride, bmp.Height, bmp.Width);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                bmp.UnlockBits(bmpData);
            }

            return str.ToString();
        }
    }
}
