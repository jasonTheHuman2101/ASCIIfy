using System;
using System.IO;
using System.Drawing;

namespace ASCIIfy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0) { Console.WriteLine("No file path to image provided"); }
            else
            {
                bool passed = false;
                try
                {
                    File.ReadAllBytes(args[0]);
                    passed = true;
                }
                catch
                {
                    Console.WriteLine("Invalid File");
                }
                if (passed) { RenderImage(args[0]); }
            }
        }

        static void RenderImage(string path)
        {
            //Open image
            Bitmap b = new Bitmap(path);
            int width = b.Width;
            int height = b.Height;

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    Color pixelColor = b.GetPixel(w, h);
                    RenderPixel(pixelColor);
                }
            }
        }

        static void RenderPixel(Color c)
        {

        }
    }
}
