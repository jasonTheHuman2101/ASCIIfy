using System;
using System.IO;
using System.Drawing;

namespace ASCIIfy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Check the arg is a valid path
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
            
            // get width and height for loop
            int width = b.Width;
            int height = b.Height;

            //Loop through each pixel
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    Color pixelColor = b.GetPixel(w, h); //Extract pixel color
                    RenderPixel(pixelColor); //Render to console
                }
                Console.WriteLine();
            }
        }

        static void RenderPixel(Color c)
        {
            int r = c.R;
            int g = c.G;
            int b = c.B;
            float average = (r + g + b) / 3; //Average out the color

            char pixChar;
            if(average < 51) { pixChar = ' '; }
            else if(average < 102) { pixChar = '░'; }
            else if (average < 153) { pixChar = '▒'; }
            else if (average < 204) { pixChar = '▓'; }
            else { pixChar = '█';  }

            Console.Write(pixChar);
        }
    }
}
