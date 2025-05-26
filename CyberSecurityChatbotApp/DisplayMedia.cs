using System;
using System.Drawing; // Make sure to add this using directive
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityChatbotApp
{
    internal class DisplayMedia
    {
        // Class to display the logo using ASCII art
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //  ABSOLUTE PATH
            string imagePath = @"C:\Users\lab_services_student\Desktop\CyberSecurityChatbotApp\Resources\cs2 (2).jpg";

            Console.WriteLine($"Attempting to display logo from: {imagePath}");

            // Check if the file exists:
            if (!File.Exists(imagePath))
            {
                Console.WriteLine($"Error: Image file not found at {imagePath}");
                Console.ResetColor();
                Console.WriteLine("  **CyberSecurity Awareness Bot**");
                Console.WriteLine("__________________________________");
                return;
            }

            string asciiArt = ConvertToASCII(imagePath, 40);
            if (asciiArt != null)
            {
                Console.WriteLine(asciiArt);
            }
            else
            {
                Console.WriteLine("Error: Could not display logo.");
            }
            Console.ResetColor();
            Console.WriteLine("  **CyberSecurity Awareness Bot**");
            Console.WriteLine("__________________________________");
        }

        static string ConvertToASCII(string imagePath, int maxWidth = 100)
        {
            try
            {
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine($"Error: Image file not found at {imagePath}");
                    return null;
                }

                Bitmap img = new Bitmap(imagePath);
                float ratio = (float)img.Height / img.Width;
                int newWidth = Math.Min(maxWidth, img.Width);
                int newHeight = (int)(newWidth * ratio);
                Bitmap resized = new Bitmap(newWidth, newHeight);

                using (Graphics g = Graphics.FromImage(resized))
                    g.DrawImage(img, 0, 0, newWidth, newHeight);

                StringBuilder sb = new StringBuilder();
                for (int y = 0; y < resized.Height; y++)
                {
                    for (int x = 0; x < resized.Width; x++)
                    {
                        Color c = resized.GetPixel(x, y);
                        int intensity = (int)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);

                        // Ensure index is within the bounds of asciiChars
                        int index = Math.Min(intensity * 9 / 255, 8);  // 8 is the last valid index (0 to 8)
                        char[] asciiChars = { '.', ',', ':', '+', '*', '?', '@', '#', '$' };
                        sb.Append(asciiChars[index]);
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting image: {ex.Message}");
                return null;
            }
        }
    }
}