using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessorCLI
{
    class Program
    {
        private static readonly Dictionary<char, int> LetterToNumber = new Dictionary<char, int>
        {
            {'A', 0},
            {'B', 1}, {'C', 1}, {'D', 1},
            {'E', 2},
            {'F', 3}, {'G', 3}, {'H', 3},
            {'I', 4},
            {'J', 5}, {'K', 5}, {'L', 5}, {'M', 5}, {'N', 5},
            {'O', 6},
            {'P', 7}, {'Q', 7}, {'R', 7}, {'S', 7}, {'T', 7},
            {'U', 8},
            {'V', 9}, {'W', 9}, {'X', 9}, {'Y', 9}, {'Z', 9},

            {'a', 9},
            {'b', 8}, {'c', 8}, {'d', 8},
            {'e', 7},
            {'f', 6}, {'g', 6}, {'h', 6},
            {'i', 5},
            {'j', 4}, {'k', 4}, {'l', 4}, {'m', 4}, {'n', 4},
            {'o', 3},
            {'p', 2}, {'q', 2}, {'r', 2}, {'s', 2}, {'t', 2},
            {'u', 1},
            {'v', 0}, {'w', 0}, {'x', 0}, {'y', 0}, {'z', 0},
            {' ', 0}
        };

        private static readonly Dictionary<int, char> NumberToLetter = new Dictionary<int, char>
        {
            {0, 'A'},
            {1, 'B'},
            {2, 'E'},
            {3, 'F'},
            {4, 'I'},
            {5, 'J'},
            {6, 'O'},
            {7, 'P'},
            {8, 'U'},
            {9, 'V'}
        };

        static void Main(string[] args)
        {
            Console.Clear();
            ShowWelcome();
            
            bool running = true;
            while (running)
            {
                ShowMenu();
                var choice = GetUserChoice();
                
                switch (choice)
                {
                    case 1:
                        ProcessTextMenu();
                        break;
                    case 2:
                        ViewDictionaryMapping();
                        break;
                    case 3:
                        ShowAbout();
                        break;
                    case 4:
                        running = false;
                        ShowExitMessage();
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid! Silakan pilih 1-4.");
                        break;
                }
                
                if (running)
                {
                    Console.WriteLine("\nTekan Enter untuk melanjutkan...");
                    Console.ReadLine();
                }
            }
        }

        static void ShowWelcome()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    TEXT PROCESSOR CLI                        ║");
            Console.WriteLine("║                  Text-to-Number Converter                    ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                         MAIN MENU                            ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1. Process Text to Numbers                                  ║");
            Console.WriteLine("║     Convert your text through the 5-step algorithm           ║");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║  2. View Dictionary Mapping                                  ║");
            Console.WriteLine("║     Explore character-to-number mappings                     ║");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║  3. About Program                                            ║");
            Console.WriteLine("║     Learn about the algorithm and features                   ║");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║  4. Exit                                                     ║");
            Console.WriteLine("║     Close the application                                    ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        static int GetUserChoice()
        {
            while (true)
            {
                Console.Write("Pilih menu (1-4): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 4)
                {
                    return choice;
                }
                Console.WriteLine("Input tidak valid! Masukkan angka 1-4.");
            }
        }

        static void ProcessTextMenu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   PROCESS TEXT TO NUMBERS                    ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            Console.Write("Masukkan kalimat: ");
            string input = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(input))
            {
                Console.WriteLine("\n" + new string('=', 65));
                Console.WriteLine("PROCESSING RESULTS");
                Console.WriteLine(new string('=', 65));
                ProcessText(input);
                Console.WriteLine(new string('=', 65));
            }
            else
            {
                Console.WriteLine("Input tidak boleh kosong!");
            }
        }

        static void ViewDictionaryMapping()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    DICTIONARY MAPPING                        ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            Console.WriteLine("CHARACTER TO NUMBER MAPPING:");
            Console.WriteLine(new string('-', 65));
            
            // Uppercase letters
            Console.WriteLine("UPPERCASE LETTERS:");
            var uppercaseLetters = LetterToNumber.Where(kvp => char.IsUpper(kvp.Key)).OrderBy(kvp => kvp.Key);
            foreach (var group in uppercaseLetters.GroupBy(kvp => kvp.Value))
            {
                var letters = string.Join(", ", group.Select(kvp => kvp.Key));
                Console.WriteLine($"   {group.Key} ← {letters}");
            }
            
            Console.WriteLine();
            
            // Lowercase letters
            Console.WriteLine("LOWERCASE LETTERS:");
            var lowercaseLetters = LetterToNumber.Where(kvp => char.IsLower(kvp.Key)).OrderBy(kvp => kvp.Key);
            foreach (var group in lowercaseLetters.GroupBy(kvp => kvp.Value).OrderByDescending(g => g.Key))
            {
                var letters = string.Join(", ", group.Select(kvp => kvp.Key));
                Console.WriteLine($"   {group.Key} ← {letters}");
            }
            
            Console.WriteLine();
            Console.WriteLine("NUMBER TO LETTER CONVERSION:");
            Console.WriteLine(new string('-', 30));
            foreach (var kvp in NumberToLetter.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"   {kvp.Key} → {kvp.Value}");
            }
            
            Console.WriteLine();
            Console.WriteLine("SPECIAL CHARACTERS:");
            Console.WriteLine($"   Space (' ') → 0");
        }

        static void ShowAbout()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      ABOUT PROGRAM                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            
            Console.WriteLine("ALGORITHM OVERVIEW:");
            Console.WriteLine("This program implements a 5-step text processing algorithm:");
            Console.WriteLine();
            
            Console.WriteLine("STEP 1: Text to Numbers Conversion");
            Console.WriteLine("Convert each character in input text to corresponding number");
            Console.WriteLine("using predefined character-to-number mapping.");
            Console.WriteLine();
            
            Console.WriteLine("STEP 2: Alternating Sum Calculation");
            Console.WriteLine("Perform alternating addition and subtraction:");
            Console.WriteLine("First + Second - Third + Fourth - Fifth + ...");
            Console.WriteLine();
            
            Console.WriteLine("STEP 3: Number to Letters Sequence");
            Console.WriteLine("Build a sequence that sums up to the result from step 2,");
            Console.WriteLine("then convert numbers back to letters.");
            Console.WriteLine();
            
            Console.WriteLine("STEP 4: Sequence Refinement");
            Console.WriteLine("Apply alternating sum to the letter sequence from step 3,");
            Console.WriteLine("then replace the last 2 elements with refined sequence.");
            Console.WriteLine();
            
            Console.WriteLine("STEP 5: Final Number Generation");
            Console.WriteLine("Convert refined letters to final numbers where:");
            Console.WriteLine("- Even numbers become odd (n + 1)");
            Console.WriteLine("- Odd numbers stay the same");
            Console.WriteLine();
            
            Console.WriteLine("TECHNICAL FEATURES:");
            Console.WriteLine("Case-sensitive character mapping");
            Console.WriteLine("Robust error handling");
            Console.WriteLine("Interactive CLI interface");
            Console.WriteLine("Step-by-step processing visualization");
            Console.WriteLine();
            
            Console.WriteLine("DEVELOPED WITH:");
            Console.WriteLine("C# .NET 6.0+");
            Console.WriteLine("Cross-platform compatibility");
            Console.WriteLine("LINQ for efficient data processing");
            Console.WriteLine();
        }

        static void ShowExitMessage()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("║            Thank you for using this program                  ║");
            Console.WriteLine("║                                                              ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Core processing functions remain the same...
        
        static List<int> TextToNumbers(string text)
        {
            return text.Select(ch => LetterToNumber.ContainsKey(ch) ? LetterToNumber[ch] : 0).ToList();
        }

        static (string Expression, int Result) AlternateSumWithSteps(List<int> numbers)
        {
            if (numbers.Count == 0)
                return ("", 0);

            var expression = new StringBuilder(numbers[0].ToString());
            int result = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if (i % 2 == 1)
                {
                    expression.Append($" + {numbers[i]}");
                    result += numbers[i];
                }
                else
                {
                    expression.Append($" - {numbers[i]}");
                    result -= numbers[i];
                }
            }

            return (expression.ToString(), result);
        }

        static List<int> BuildSequenceForSum(int target)
        {
            target = Math.Abs(target);
            if (target == 0)
                return new List<int> { 0 };

            var seq = new List<int>();
            int sum = 0;
            int digit = 0;

            while (sum < target)
            {
                if (sum + digit <= target)
                {
                    seq.Add(digit);
                    sum += digit;
                    digit = (digit + 1) % 10;
                }
                else
                {
                    digit = (digit + 1) % 10;
                }
            }

            return seq;
        }

        static List<char> NumberToLetters(int num)
        {
            var seqNumbers = BuildSequenceForSum(num);
            return seqNumbers.Select(n => NumberToLetter[n]).ToList();
        }

        static List<char> RefineSequence(List<char> seqLetters)
        {
            var nums = seqLetters.Select(ch => LetterToNumber.ContainsKey(ch) ? LetterToNumber[ch] : 0).ToList();
            var (_, result) = AlternateSumWithSteps(nums);
            var newSeq = NumberToLetters(result);

            var replacement = newSeq.Skip(1).Take(2).ToList();

            var refined = new List<char>(seqLetters);
            
            if (refined.Count >= 2)
            {
                refined.RemoveRange(refined.Count - 2, 2);
            }
            refined.AddRange(replacement);

            return refined;
        }

        static string LettersToFinalNumbers(List<char> seqLetters)
        {
            return string.Join(" ", seqLetters.Select(ch =>
            {
                int n = LetterToNumber.ContainsKey(ch) ? LetterToNumber[ch] : 0;
                return n % 2 == 0 ? n + 1 : n;
            }));
        }

        static void ProcessText(string input)
        {
            Console.WriteLine($"dotINPUT: {input}");
            Console.WriteLine();

            var nums = TextToNumbers(input);
            Console.WriteLine($"1️STEP 1 - Text to Numbers:");
            Console.WriteLine($"{string.Join(" ", nums)}");
            Console.WriteLine();

            var (expression, result) = AlternateSumWithSteps(nums);
            Console.WriteLine($"2️STEP 2 - Alternating Sum:");
            Console.WriteLine($"{expression} = {result}");
            Console.WriteLine();

            var letters = NumberToLetters(result);
            Console.WriteLine($"3️STEP 3 - Number to Letters:");
            Console.WriteLine($"{string.Join(" ", letters)}");
            Console.WriteLine();

            var refined = RefineSequence(letters);
            Console.WriteLine($"4️STEP 4 - Refined Sequence:");
            Console.WriteLine($"{string.Join(" ", refined)}");
            Console.WriteLine();

            var finalNums = LettersToFinalNumbers(refined);
            Console.WriteLine($"5️STEP 5 - Final Numbers:");
            Console.WriteLine($"{finalNums}");
            Console.WriteLine();
            Console.WriteLine($"FINAL RESULT: {finalNums}");
        }
    }
}