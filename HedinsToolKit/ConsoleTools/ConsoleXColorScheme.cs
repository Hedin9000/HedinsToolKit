using System;
using System.Collections.Generic;
using System.Text;

namespace HedinsToolKit.ConsoleTools
{
    public class ConsoleXColorScheme
    {

        public ConsoleXColor<int> IntColor { get; set; }
        public ConsoleXColor<float> FloatColor { get; set; }
        public ConsoleXColor<decimal> DecimalColor { get; set; }
        public ConsoleXColor<long> LongColor { get; set; }
        public ConsoleXColor<string> StringColor { get; set; }
        public ConsoleXColor<Enum> EnumColor { get; set; }
        public ConsoleXColor<bool> BoolColor { get; set; }

        public ConsoleXColor<object> NullColor { get; set; }
        public ConsoleXColor<object> DefaultColor { get; set; }
        public ConsoleXColor<string> ConsoleXErrorMessageColor { get; set; }
        public ConsoleXColor<string> ConsoleXTextColor { get; set; }



        


    }
}
