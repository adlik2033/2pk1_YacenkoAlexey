namespace PZ_01 
{
    internal class Program  
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число a: "); // Выводим на экран приглашение ввести число а
            double a = double.Parse(Console.ReadLine()); // Вводим переменную а (тип double)

            Console.WriteLine("Введите число b: "); // Выводим на экран приглашение ввести число b
            double b = double.Parse(Console.ReadLine()); // Вводим переменную b (тип double)

            Console.WriteLine("Введите число c: ");  // Выводим на экран приглашение ввести число c
            double c = double.Parse(Console.ReadLine()); // Вводим переменную с (тип double)

            double result1, result2, result3, result4, result5; // Вводим переменные (тип double) для решения примера по частям
           

            result1 =  a + 3 * Math.Abs(a - b) + Math.Pow(a, 2);
            // Выполняем первое действие - получаем результат с числителя дроби
            // Math.Abs - модуль числа
            // Math.Pow - квадрат числа

            result2 = Math.Abs(a - b) * c + Math.Pow(a, 2);
            // Выполняем второе действие - получаем результат со знаменателя дроби

            result3 = result1 / result2;
            // Выполняем третье действие - получаем результат деления числителя на знаменатель

            result4 = 1.0 / 4.0 * Math.Cos(a) * result3;
            // Выполняем четвертое действие
            // Дробь 1/4 переводим в вещественный тип и получаем 1.0/4.0

            result5 = 5 * Math.Atan(a) - result4;
            // Выполняем пятое пятое последнее действие
            // Math.Atan - арктангенс числа

            Console.WriteLine($"Ответ: {result5}  "); 
            // Выводим ответ на экран
        }
    }
}