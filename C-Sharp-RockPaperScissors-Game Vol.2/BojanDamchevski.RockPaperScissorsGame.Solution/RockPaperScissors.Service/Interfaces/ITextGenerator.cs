using System;

namespace RockPaperScissors.Service.Interfaces
{
    public interface ITextGenerator
    {
        void GenerateText(string text, ConsoleColor color);
    }
}
