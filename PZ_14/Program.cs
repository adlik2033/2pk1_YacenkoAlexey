using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string filePath = "file.txt";
        // file.txt - тестовый текстовый фаил, который находится в директории проекта. Там есть и пустые строки, и строки с текстом,
        // и строки чисто с вопросом, и пробел с вопросом... все случаи. Проверяем работоспособность программы.

        // Открываем файл для чтения
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            // Создаем объект StreamReader для чтения текста из файла
            using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;

                // Читаем содержимое файла построчно
                while ((line = reader.ReadLine()) != null)
                {
                    // Проверяем, оканчивается ли строка вопросительным или восклицательным знаком
                    if (line.TrimEnd().EndsWith("?") || line.TrimEnd().EndsWith("!"))
                    {
                        // Выводим строку на консоль
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}