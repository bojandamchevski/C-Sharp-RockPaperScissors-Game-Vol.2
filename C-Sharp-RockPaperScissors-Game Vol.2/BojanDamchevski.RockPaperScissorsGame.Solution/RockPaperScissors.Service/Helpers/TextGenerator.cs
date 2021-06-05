using RockPaperScissors.Service.Interfaces;
using System;

namespace RockPaperScissors.Service.Helpers
{
    public class TextGenerator : ITextGenerator
    {
        public void GenerateText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
