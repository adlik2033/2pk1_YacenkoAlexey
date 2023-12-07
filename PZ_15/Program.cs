using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите название каталога. Каталог files.");
        string directoryPath = Console.ReadLine();

        // files - тестовый каталог для проверки работы программы, в ней находится самая маленькая папка f2, 
        // средняя f3 с одним файлом и большая f1 с множеством. Все файлы весят 1 КБ.

        if (Directory.Exists(directoryPath))
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            DirectoryInfo[] subdirectories = directoryInfo.GetDirectories();

            // Сортируем подкаталоги по размеру в порядке убывания
            var sortedSubdirectories = subdirectories.OrderByDescending(d => d.EnumerateFiles("*", SearchOption.AllDirectories).Sum(f => f.Length));

            // Выводим имена подкаталогов в порядке убывания по размеру
            foreach (var subdirectory in sortedSubdirectories)
            {
                Console.WriteLine(subdirectory.Name);
            }
        }
        else
        {
            Console.WriteLine("Указанный каталог не существует.");
        }
    }
}