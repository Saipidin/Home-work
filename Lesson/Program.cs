using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите задание для выполнения (1-4) или введите 'q' для выхода:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "q")
            {
                break;
            }

            switch (userInput)
            {
                case "1":
                    ExecuteTask(Code1, "Задайте двумерный массив символов (тип char [,]). Создать строку из символов этого массива.");
                    break;
                case "2":
                    ExecuteTask(Code2, "Задайте строку, содержащую буквы в обоих регистрах. Сформируйте строку, в которой все заглавные буквы заменены на строчные.");
                    break;
                case "3":
                    ExecuteTask(Code3, "Задайте произвольную строку. Выясните, является ли она палиндромом.");
                    break;
                case "4":
                    ExecuteTask(Code4, "Задайте строку, состоящую из слов, разделенных пробелами. Сформировать строку, в которой слова расположены в обратном порядке. В полученной строке слова должны быть также разделены пробелами.");
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Заданий всего 4 или 'q' для выхода.");
                    break;
            }
        }
    }

    static void ExecuteTask(Action<string> task, string taskDescription)
    {
        Console.WriteLine($"Вы выбрали задание: {taskDescription}.\n");
        task("dummy");
        Console.WriteLine("\n--------------------------------\n");
    }

    static void Code1(string dummy)
    {
        char[,] charArray = {
            {'J', 'o', 'y', ' ', ' '},
            {'A', 'n', 'g', 'e', 'r'},
            {'T', 'r', 'u', 's', 't'},
            {'L', 'o', 'v', 'e', ' '}
        };

        string resultString = ConvertCharArrayToString(charArray);

        Console.WriteLine("Исходный массив символов:");
        PrintCharArray(charArray);

        Console.WriteLine("\nРезультирующая строка:");
        Console.WriteLine(resultString);
    }

    static string ConvertCharArrayToString(char[,] charArray)
    {
        string resultString = "";
        for (int i = 0; i < charArray.GetLength(0); i++)
        {
            for (int j = 0; j < charArray.GetLength(1); j++)
            {
                resultString += charArray[i, j] + " ";
            }
        }
        return resultString.Trim();
    }

    static void PrintCharArray(char[,] charArray)
    {
        for (int i = 0; i < charArray.GetLength(0); i++)
        {
            for (int j = 0; j < charArray.GetLength(1); j++)
            {
                Console.Write(charArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Code2(string dummy)
    {
        string originalString = "Как важно быть серьезным!";
        string resultString = ConvertToUpperToLower(originalString);

        Console.WriteLine("Исходная строка: " + originalString);
        Console.WriteLine("Результирующая строка: " + resultString);
    }

    static string ConvertToUpperToLower(string input)
    {
        char[] resultArray = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            resultArray[i] = char.ToLower(input[i]);
        }
        return new string(resultArray);
    }

    static void Code3(string dummy)
    {
        string inputString = "А роза упала на лапу Азора";
        bool isPalindrome = IsPalindrome(inputString);
        Console.WriteLine($"Строка '{inputString}' является палиндромом: {isPalindrome}");
    }

    static bool IsPalindrome(string input)
    {
        input = input.ToLower();
        int left = 0;
        int right = input.Length - 1;

        while (left < right)
        {
            if (!char.IsLetterOrDigit(input[left]))
            {
                left++;
                continue;
            }

            if (!char.IsLetterOrDigit(input[right]))
            {
                right--;
                continue;
            }

            if (input[left] != input[right])
            {
                return false;
            }

            left++;
            right--;
        }
        return true;
    }

    static void Code4(string dummy)
    {
        string inputString = "Загадочная строка с разными словами";
        string reversedString = ReverseWords(inputString);

        Console.WriteLine($"Исходная строка: {inputString}");
        Console.WriteLine($"Результирующая строка: {reversedString}");
    }

    static string ReverseWords(string input)
    {
        string[] words = input.Split(' ');
        Array.Reverse(words);
        return string.Join(" ", words);
    }
}
