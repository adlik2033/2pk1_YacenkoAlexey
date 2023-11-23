using System;

namespace PZ_09;

class Program
{
    static void Main()
    {
        Console.WriteLine("Подсчитайте количество слов в тексте и выведите все слова текста в порядке убывания. ");
        Console.WriteLine("Обратите ВНИМАНИЕ! Данная программа предусматривает постановку знака препинания в конце приложения. ");
        Console.WriteLine("Иначе будут возникать ошибки!");


        // Данная программа предусматривает постановку знака препинания в конце приложения. Иначе будут возникать ошибки!
        // По правилам в конце любого предложения нужен стоять знак препинания, я и решил оставить так, это будет правильнее.
        // Но без знака препинания программа не считает последнее слово


        Console.WriteLine("Введите текст:");
        //Вводим нужный текст
        string text = Console.ReadLine();
        int wordCount = 0;

        char[] separators = { ' ', '.', ',', '!', '?' };
        int[] counts = new int[1000];
        string[] words = new string[1000];

        // Подсчет количества слов и их сохранение в массив
        int index = 0;
        int wordStartIndex = -1;

        foreach (char c in text)
        {
            if (Array.IndexOf(separators, c) != -1)
            {
                if (wordStartIndex != -1)
                {
                    string word = text.Substring(wordStartIndex, index - wordStartIndex);
                    wordCount++;

                    // Поиск слова в массиве
                    bool found = false;
                    for (int i = 0; i < wordCount; i++)
                    {
                        if (string.Equals(word, words[i], StringComparison.OrdinalIgnoreCase))
                        {
                            counts[i]++;
                            found = true;
                            break;
                        }
                    }

                    // Если слово не найдено, добавляем его в массив
                    if (!found)
                    {
                        words[wordCount - 1] = word;
                        counts[wordCount - 1] = 1;
                    }
                }

                wordStartIndex = -1;
            }
            else if (wordStartIndex == -1)
            {
                wordStartIndex = index;
            }

            index++;
        }

        // Вывод слов в порядке убывания
        for (int i = 0; i < wordCount; i++)
        {
            int maxIndex = 0;
            int maxValue = -1;

            // Поиск слова с максимальным количеством
            for (int j = 0; j < wordCount; j++)
            {
                if (counts[j] > maxValue)
                {
                    maxIndex = j;
                    maxValue = counts[j];
                }
            }

            // Вывод слова и его количество
            Console.WriteLine("{0}: {1}", words[maxIndex], counts[maxIndex]);

            // Установка количества для данного слова в минимальное значение,
            // чтобы оно не было выбрано в следующей итерации
            counts[maxIndex] = -1;
        }

        // Вывод общего количества слов
        Console.WriteLine("Общее количество слов: {0}", wordCount);
    }
}