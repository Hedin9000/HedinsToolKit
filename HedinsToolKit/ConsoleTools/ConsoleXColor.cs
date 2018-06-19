using System;
using System.Collections.Generic;
using System.Text;

namespace HedinsToolKit.ConsoleTools
{
    public class ConsoleXColor<T>
    {
        public ConsoleXColor()
        {
            MakeBackgroud = arg => BackgroundColor;
            MakeForeground = arg => ForegroundColor;
        }
        public ConsoleColor BackgroundColor { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public Func<T, ConsoleColor> MakeBackgroud { get; set; }
        public Func<T, ConsoleColor> MakeForeground { get; set; }
    }
}
