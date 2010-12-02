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
                        Image src = Image.FromFile(path);
                        Bitmap dest = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        Graphics g = Graphics.FromImage(dest);
                        g.DrawImage(src, new Rectangle(new Point(0, 0), src.Size), new Rectangle(new Point(0, 0), src.Size), GraphicsUnit.Pixel);
                        dest.Save(path + ".32bpp" + fi.Extension);
                        src.Dispose();
                    }
                    catch { }
                }
            }
        }
    }
}
