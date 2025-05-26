using System;
using System.Drawing;
using System.Media;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CyberSecurityChatbotApp
{
    internal class Program
    {

        //Main class
        static void Main(string[] args)
        {
            // Calling the classes for playing the audio and displaying the logo
            PlaySounds.PlayGreeting();
            DisplayMedia.DisplayLogo();

            // Prompt the user to enter their name
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"Hello, {userName}!");

            // Start handling user input and responses
            HandlingUsers.HandleUserInput(userName);

            // Keep the console window running until any key is pressed
            Console.WriteLine("Press any Key to exit....");
            Console.ReadKey();
        }
    }
}
