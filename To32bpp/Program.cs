using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace To32bpp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string path in args)
            {
                if (File.Exists(path))
                {
                    try
                    {
                        FileInfo fi = new FileInfo(path);
                        Image imgLoad = Image.FromFile(path);
                        Bitmap bmp2 = new Bitmap(imgLoad.Width, imgLoad.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        Graphics g = Graphics.FromImage(bmp2);
                        g.DrawImageUnscaled(imgLoad, new Point(0, 0));
                        bmp2.Save(path + ".32bpp" + fi.Extension);
                    }
                    catch { }
                }
            }
        }
    }
}
