using System;
using System.Collections.Generic;
using System.Text;

namespace HedinsToolKit.ConsoleTools
{
    public static class ConsoleX
    {
        private static ConsoleXColorScheme _colorScheme;

        static ConsoleX()
        {
        
        }

        public static void SetColorScheme(ConsoleXColorScheme consoleXColorScheme)
        {
            _colorScheme = consoleXColorScheme;
        }

        public static void Write<T>(T data, ConsoleXColor<T> color)

        {
            Console.BackgroundColor = color.MakeBackgroud(data);
            Console.ForegroundColor = color.MakeForeground(data);
            Console.Write(data);
            Console.BackgroundColor = _colorScheme.DefaultColor.MakeBackgroud();

        }
        public static void WriteLine<T>(string data, ConsoleXColor<T> color)
        {
            SetColor(color);
            Console.WriteLine(data);
            SetColor(_colorScheme.DefaultColor);
        }
        public static void Write(string data, ConsoleColor color)
        {
            var backColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(data);
            
            Console.ForegroundColor = backColor;
        }

        public static void WriteLine(string data, ConsoleColor color)
        {
            Write(data + Environment.NewLine, color);
        }

        public static void PrintValue(string name, object item)
        {

            Console.Write($"{name}:");
            switch (item)
            {
                case bool boolValue:
                   // WriteLine(boolValue.ToString(), boolValue ? ConsoleColor.Green : ConsoleColor.Red);
                    WriteLine(boolValue.ToString(), boolValue ? _colorScheme.BoolTrueColor : _colorScheme.BoolFalseColor);
                    break;
                case string stringValue:
                    //WriteLine(stringValue, ConsoleColor.Cyan);
                    WriteLine(stringValue, _colorScheme.StringColor);
                    break;
                case int intValue:
                    //WriteLine(intValue.ToString(), ConsoleColor.Yellow);
                    WriteLine(intValue.ToString(), _colorScheme.IntColor);
                    break;
                case float floatValue:
                    //WriteLine(floatValue.ToString(), ConsoleColor.Yellow);
                    WriteLine(floatValue.ToString(), _colorScheme.FloatColor);
                    break;
                case decimal decimalValue:
                    //WriteLine(decimalValue.ToString(), ConsoleColor.Yellow);
                    WriteLine(decimalValue.ToString(), _colorScheme.DecimalColor);
                    break;
                case long longValue:
                    //WriteLine(longValue.ToString(), ConsoleColor.Yellow);
                    WriteLine(longValue.ToString(), _colorScheme.LongColor);
                    break;
                case Enum enumValue:
                    //WriteLine(enumValue.ToString(), ConsoleColor.Magenta);
                    WriteLine(enumValue.ToString(), _colorScheme.EnumColor);
                    break;
                case null:
                    //WriteLine("NULL", ConsoleColor.Red);
                    WriteLine("NULL", _colorScheme.NullColor);
                    break;
                default:
                    //WriteLine(item.ToString(), ConsoleColor.White);
                    WriteLine(item.ToString(), _colorScheme.DefaultColor);
                    break;
            }

        }

        public static void PrintBytes(string name, long bytes)
        {
            var kbytes = bytes / 1024D;

            var mbytes = bytes / (1024D * 1024D);

            Console.Write($"{name}:");
            Write(bytes.ToString(), ConsoleColor.Cyan);
            Write("b | ", ConsoleColor.Gray);
            Write(kbytes.ToString("F"), ConsoleColor.Cyan);
            Write("kb | ", ConsoleColor.Gray);
            Write(mbytes.ToString("F"), ConsoleColor.Cyan);
            WriteLine("mb | ", ConsoleColor.Gray);
        }

        public static TItem GetValue<TItem>(string name)
        {
            while (true)
            {
                Console.Write($"{name}: ");
                var stringItem = Console.ReadLine();
                var itemType = typeof(TItem);

                if (itemType == typeof(int))
                {
                    if (int.TryParse(stringItem, out var intResult))
                        return (TItem)Convert.ChangeType(intResult, typeof(TItem));
                }

                if (itemType == typeof(long))
                {
                    if (long.TryParse(stringItem, out var intResult))
                        return (TItem)Convert.ChangeType(intResult, typeof(TItem));
                }
                if (itemType == typeof(float))
                {
                    if (float.TryParse(stringItem, out var intResult))
                        return (TItem)Convert.ChangeType(intResult, typeof(TItem));
                }
                if (itemType == typeof(double))
                {
                    if (double.TryParse(stringItem, out var intResult))
                        return (TItem)Convert.ChangeType(intResult, typeof(TItem));
                }
                if (itemType == typeof(decimal))
                {
                    if (decimal.TryParse(stringItem, out var intResult))
                        return (TItem)Convert.ChangeType(intResult, typeof(TItem));
                }
                if (itemType == typeof(string))
                    return (TItem)Convert.ChangeType(stringItem, typeof(TItem));

                if (itemType == typeof(Enum))
                {
                      var enumValue = Enum.Parse(typeof(TItem), stringItem, true);
                        return (TItem)Convert.ChangeType(enumValue, typeof(TItem));
                }
                Console.Write("Invalid data, try again.");
                WriteLine($"({typeof(TItem)}).", ConsoleColor.DarkGray);
            }

        }

        public static TItem GetValue<TItem>(string name, TItem defaultValue)
        {
            while (true)
            {
                Console.Write($"{name}[{defaultValue}]: ");
                var stringItem = Console.ReadLine();
                if (string.IsNullOrEmpty(stringItem))
                    return defaultValue;

                var itemType = typeof(TItem);

                if (itemType == typeof(int))
                {
                    if (int.TryParse(stringItem, out var intResult))
                        return (TItem)Convert.ChangeType(intResult, typeof(TItem));
                }

                if (itemType == typeof(long))
                {
                    if (long.TryParse(stringItem, out var intResult))
                        return (TItem)Convert.ChangeType(intResult, typeof(TItem));
                }
                if (itemType == typeof(float))
                {
                    if (float.TryParse(stringItem, out var intResult))
                        return (TItem)Convert.ChangeType(intResult, typeof(TItem));
                }
                if (itemType == typeof(double))
                {
                    if (double.TryParse(stringItem, out var intResult))
                        return (TItem)Convert.ChangeType(intResult, typeof(TItem));
                }
                if (itemType == typeof(decimal))
                {
                    if (decimal.TryParse(stringItem, out var intResult))
                        return (TItem)Convert.ChangeType(intResult, typeof(TItem));
                }
                if (itemType == typeof(string))
                    return (TItem)Convert.ChangeType(stringItem, typeof(TItem));

                if (itemType == typeof(Enum))
                {
                    var enumValue = Enum.Parse(typeof(TItem), stringItem, true);
                    return (TItem)Convert.ChangeType(enumValue, typeof(TItem));
                }


                if (itemType == typeof(string))
                    return (TItem)Convert.ChangeType(stringItem, typeof(TItem));
            }
        }

        public static void PrintMenu(params string[] lines)
        {
            var lineCount = lines.Length;
            for (var i = 0; i < lineCount; i++)
            {
                Write((1 + i).ToString(), ConsoleColor.Cyan);
                Console.WriteLine($". {lines[i]}.");
            }
        }
        #region TODO
        //public static void PrintLog(LogLevel level, string message)
        //{
        //    var logLine = $"[{DateTime.Now:T}] {message}";
        //    ConsoleColor color;
        //    switch (level)
        //    {

        //        case LogLevel.Debug:
        //            color = ConsoleColor.DarkGray;
        //            break;
        //        case LogLevel.Info:
        //            color = ConsoleColor.Cyan;
        //            break;
        //        case LogLevel.Warn:
        //            color = ConsoleColor.Magenta;
        //            break;
        //        case LogLevel.Error:
        //            color = ConsoleColor.Yellow;
        //            break;
        //        case LogLevel.Fatal:
        //            color = ConsoleColor.Red;
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(level), level, null);
        //    }
        //    WriteLine(logLine, color);
        //}
        #endregion
    }
}
