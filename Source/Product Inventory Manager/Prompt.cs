using System;
namespace Product_Inventory_Manager
{
    public static class Prompt
    {
        public static bool ReadBool(string promptWithoutQuestionMark)
        {
            Console.WriteLine();

            while (true)
            {
                Console.Write($"{promptWithoutQuestionMark} [y/n]? ");
                char key = char.ToLowerInvariant(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (key == 'y')
                    return true;
                else if (key == 'n')
                    return false;
            }
        }

        public static void ReadDecimal(string prompt, Action<decimal> setValueAction)
        {
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine($"{prompt}");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal result))
                {
                    try
                    {
                        setValueAction(result);
                        return;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid decimal value.");
                }
            }
        }

        public static void ReadString(string prompt, Action<string> setValueAction)
        {
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine($"{prompt}");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    try
                    {
                        setValueAction(input);
                        return;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid string value.");
                }
            }
        }

        public static void ReadInt(string prompt, Action<int> setvalueAction)
        {
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine($"{prompt}");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    try
                    {
                        setvalueAction(result);
                        return;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid int value.");
                }
            }
        }
    }
}
