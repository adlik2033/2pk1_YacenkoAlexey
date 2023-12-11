
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp8
{
    internal class Program
    {
        static int mapSize = 25; //размер карты
        static char[,] map = new char[mapSize, mapSize]; //карта
        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;
        static byte enemies = 5; //количество врагов
        static byte buffs = 5; //количество усилений
        static int health = 5;  // количество аптечек   
        static int playerhealt = 50;
        static int playerbuff = 10;
        static int enemyhbuff = 5;
        static int enemyhealt = 30;
        static int count = 30;
        static int newcount = 0;
        static int playerminus = 0;
        static int killenemy = 5;
        static int CenterX = 0;
        static int CenterY = 0;
        static int x = 0;
        static int y = 0;





        static void Main(string[] args)
        {
            Console.Title = "PLAY 2.0";
            StartGame();
            WinORLose();

        }

        static void PrintCenteredText(string text, int y)
        {
            int CenterX = Console.WindowWidth / 2 - text.Length / 2;
            Console.SetCursorPosition(CenterX, y);
            Console.WriteLine(text);

        }

        static void Last(string text)
        {
            Console.WriteLine("Журнал последних действий: " + text);

        }

        static void Exit()
        {
            Environment.Exit(0);

        }

        static void WinORLose()
        {
            if (playerhealt <= 0)
            {
                Console.Clear();
                PrintCenteredText("Вы проиграли. В следующий раз повезет! ", CenterY + 3);
                PrintCenteredText($"Количество шагов в общем: {newcount} ", CenterY + 5);
                PrintCenteredText("Нажмите Enter чтобы выйти", CenterY + 7);

                ConsoleKeyInfo KeyInfo;
                do
                {
                    KeyInfo = Console.ReadKey();
                }
                while (KeyInfo.Key != ConsoleKey.Enter);

                Console.Clear();
                Exit();


            }
            if (playerhealt > 0 && killenemy == 0)
            {
                Console.Clear();
                PrintCenteredText("Поздравляем! Вы победили.", CenterY + 3);
                PrintCenteredText($"Количество шагов в общем: {newcount} ", CenterY + 5);
                PrintCenteredText("Нажмите Enter чтобы выйти", CenterY + 7);

                ConsoleKeyInfo KeyInfo;
                do
                {
                    KeyInfo = Console.ReadKey();
                }
                while (KeyInfo.Key != ConsoleKey.Enter);

                Console.Clear();

                Exit();
            }
        }

        static void PostSaveGame()
        {
            PrintCenteredText("yИгра сохранена.", CenterY + 3);
            PrintCenteredText("Нажмите Enter чтобы выйти", CenterY + 5);

            ConsoleKeyInfo KeyInfo;
            do
            {
                KeyInfo = Console.ReadKey();
            }
            while (KeyInfo.Key != ConsoleKey.Enter);

            Console.Clear();

            Exit();

        }
        static void StartGame()
        {
            PrintCenteredText("Добро пожаловать в нашу игру!", CenterY);
            PrintCenteredText("Меню действий: ", CenterY + 1);
            PrintCenteredText("1 - начать новую игру", CenterY + 2);
            PrintCenteredText("2 - открыть сохраненную игру", CenterY + 3);
            PrintCenteredText("Обратите внимание!", CenterY + 4);
            PrintCenteredText("Чтобы сохранить игру - нажмите ESC", CenterY + 5);

            PrintCenteredText(" ____    _          _     __   __", CenterY + 8);
            PrintCenteredText(" |  _ \\  | |        / \\    \\ \\ / /", CenterY + 9);
            PrintCenteredText(" | |_) | | |       / _ \\    \\ V / ", CenterY + 10);
            PrintCenteredText(" |  __/  | |___   / ___ \\    | |  ", CenterY + 11);
            PrintCenteredText(" |_|     |_____| /_/   \\_\\   |_|  ", CenterY + 12);



            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    GenerationMap();
                    Move();
                    UpdateMap();
                    break;
                case ConsoleKey.D2:
                    Loadgame();
                    Move();
                    UpdateMap();
                    break;
                case ConsoleKey.D3:
                default:
                    Console.WriteLine("Неверное нажатие клавиши! ");
                    Console.WriteLine("Попробуйте еще раз");
                    return;
            }





            static void SaveGame()
            {
                string path = "save.txt";
                using StreamWriter writer = new StreamWriter(path);
                {
                    writer.WriteLine($"playerX = {playerX}");
                    writer.WriteLine($"playerY = {playerY}");
                    writer.WriteLine($"playerhealt = {playerhealt}");
                    writer.WriteLine($"playerbuff = {playerbuff}");
                    writer.WriteLine($"count = {count}");
                    writer.WriteLine($"newcount = {newcount}");
                    writer.WriteLine($"enemybuff = {enemyhbuff}");
                    writer.WriteLine($"enemyhealt = {enemyhealt}");
                    writer.WriteLine($"killenemy = {killenemy}");

                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            writer.Write(map[i, j]);
                        }
                        writer.WriteLine();
                    }
                }

            }

            static void Loadgame() // Загрузка
            {
                string path = "save.txt"; // Путь

                if (File.Exists(path)) // Если существует
                {
                    string[] lines = File.ReadAllLines(path); // Передача файлов с документа в игру

                    if (lines.Length >= mapSize)
                    {
                        if (int.TryParse(lines[0].Split('=')[1], out int loadedPlayerX) &&
                        int.TryParse(lines[1].Split('=')[1], out int loadedPlayerY) &&
                        int.TryParse(lines[2].Split('=')[1], out int loadedplayerhealt) &&
                        int.TryParse(lines[3].Split('=')[1], out int loadedplayerbuff) &&
                        int.TryParse(lines[4].Split('=')[1], out int loadedcount) &&
                        int.TryParse(lines[5].Split('=')[1], out int loadednewcount) &&
                        int.TryParse(lines[6].Split('=')[1], out int loadedenemyhbuff) &&
                        int.TryParse(lines[7].Split('=')[1], out int loadedenemyhealt) &&
                        int.TryParse(lines[7].Split('=')[1], out int loadedkillenemy))
                        {
                            playerX = loadedPlayerX;
                            playerY = loadedPlayerY;
                            playerhealt = loadedplayerhealt;
                            playerbuff = loadedplayerbuff;
                            count = loadedcount;
                            newcount = loadednewcount;
                            enemyhbuff = loadedenemyhbuff;
                            enemyhealt = loadedenemyhealt;
                            killenemy = loadedkillenemy;

                            for (int i = 0; i < mapSize; i++)
                            {
                                for (int j = 0; j < mapSize; j++)
                                {
                                    map[i, j] = '_';
                                }
                            }

                            for (int i = 0; i < mapSize; i++)
                            {
                                for (int j = 0; j < mapSize; j++)
                                {
                                    map[i, j] = lines[i + 9][j];
                                }
                            }

                            map[playerX, playerY] = 'P';

                            Console.Clear();
                            UpdateMap(); //Вывод на консоль
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка чтения файла сохранения.");
                    }
                }
                else
                {
                    Console.WriteLine("Файл сохранения не найден.");
                }
            }

            /// <summary>
            /// генерация карты с расставлением врагов, аптечек, баффов
            /// </summary>
            static void GenerationMap()
            {
                Random random = new Random();
                //создание пустой карты
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (j == 23)
                        {
                            Console.SetCursorPosition(0, 0);
                        }
                        else
                        {
                            map[i, j] = '_';
                        }
                    }
                }

                map[playerY, playerX] = 'P'; // в середину карты ставится игрок

                //временные координаты для проверки занятости ячейки
                int x;
                int y;
                //добавление врагов
                while (enemies > 0)
                {
                    x = random.Next(0, mapSize);
                    y = random.Next(0, mapSize);

                    //если ячейка пуста  - туда добавляется враг
                    if (map[x, y] == '_')
                    {
                        map[x, y] = 'E';
                        enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                    }
                }
                //добавление баффов
                while (buffs > 0)
                {
                    x = random.Next(0, mapSize);
                    y = random.Next(0, mapSize);

                    if (map[x, y] == '_')
                    {
                        map[x, y] = 'B';
                        buffs--;
                    }
                }
                //добавление аптечек
                while (health > 0)
                {
                    x = random.Next(0, mapSize);
                    y = random.Next(0, mapSize);

                    if (map[x, y] == '_')
                    {
                        map[x, y] = 'H';
                        health--;
                    }
                }

                UpdateMap(); //отображение заполненной карты на консоли

            }

            static void BuffUp()
            {

                if (map[playerX, playerY] == 'B')
                {
                    playerbuff *= 2;
                    if (playerbuff > 20)
                    {
                        playerbuff = 20;
                        Last($"Время действия баффа продлено." + "                                                                         ");
                        count = 0;
                        map[playerX, playerY] = '_';
                    }
                    else
                    {
                        count = 0;
                        Last($"Ваша сила умножена на 2." + "                                                                         ");
                        map[playerX, playerY] = '_';
                    }

                }

            }

            static void BuffDown()
            {
                if (count == 20)
                {
                    playerbuff /= 2;
                    count = 0;
                    Last($"Вы прошли 20 шагов с баффом. Бафф обнулен" + "                                                                         ");
                    map[playerX, playerY] = '_';
                }
            }

            static void AidUp()
            {
                if (map[playerX, playerY] == 'H')
                {
                    playerhealt = 50;
                    Last($"Вы подняли аптечку!" + "                                                                         ");
                    map[playerX, playerY] = '_';
                }
            }


            static void Fight()
            {
                if (map[playerX, playerY] == 'E')
                {
                    for (int i = 0; i < 3; i++) // Перебор символов анимации
                    {
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('?');
                        Thread.Sleep(60);
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('/');
                        Thread.Sleep(60);
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('#');
                        Thread.Sleep(60);
                    }
                    Console.Write('_');

                    while (enemyhealt > 0)
                    {
                        enemyhealt = enemyhealt - playerbuff;
                        playerhealt -= 5;
                        playerminus += 5;
                        
                    }
                    PrintCenteredText($"Сражения: Бой с врагом. Вы потеряли {playerminus} здоровья!", CenterY + 4);
                    map[playerX, playerY] = '_';
                    killenemy--;

                    enemyhealt = 30;
                    playerminus = 0;
                }
                if (playerhealt <= 0)
                {
                    Console.Clear();
                    PrintCenteredText("Вы проиграли бой. Здоровье: 0", CenterY + 3);
                    PrintCenteredText("Игра окончена", CenterY + 4);
                    Console.SetCursorPosition(CenterX, CenterY + 1);
                    PrintCenteredText("Нажмите Enter чтобы выйти", CenterY + 6);

                    ConsoleKeyInfo keyInfo;
                    do
                    {
                        keyInfo = Console.ReadKey();
                    } while (keyInfo.Key != ConsoleKey.Enter);

                    Exit(); // Выход 
                }

            }





            static void UpdateMap()  // Заполненная карта на консоли
            {
                Console.Clear();
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        switch (map[i, j]) // Окраска элементов
                        {
                            case 'E':
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 'B':
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 'H':
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }

                        Console.Write(map[i, j]);
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
            }


            /// <summary>
            /// перемещение персонажа
            /// </summary>
            static void Move()
            {
                //предыдущие координаты игрока
                int playerOldY;
                int playerOldX;

                while (true)
                {
                    playerOldX = playerX;
                    playerOldY = playerY;

                    //смена координат в зависимости от нажатия клавиш
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.UpArrow:
                            Thread.Sleep(500); // сон
                            playerX--;
                            count++;
                            newcount++;
                            break;
                        case ConsoleKey.DownArrow:
                            Thread.Sleep(500); // сон
                            playerX++;
                            count++;
                            newcount++;
                            break;
                        case ConsoleKey.LeftArrow:
                            Thread.Sleep(500); // сон
                            playerY--;
                            count++;
                            newcount++;
                            break;
                        case ConsoleKey.RightArrow:
                            Thread.Sleep(500); // сон
                            playerY++;
                            count++;
                            newcount++;
                            break;
                        case ConsoleKey.Escape:
                            SaveGame();
                            Console.Clear();
                            PostSaveGame();
                            break;

                    }

                    if (playerX < 0) playerX = 0;
                    if (playerX >= mapSize) playerX = mapSize - 1;
                    if (playerY < 0) playerY = 0;
                    if (playerY >= mapSize) playerY = mapSize - 1;

                    Console.CursorVisible = false; //скрытный курсов


                    //предыдущее положение игрока затирается
                    map[playerOldY, playerOldX] = '_';
                    Console.SetCursorPosition(playerOldY, playerOldX);
                    Console.Write('_');


                    //обновленное положение игрока
                    map[playerY, playerX] = 'P';
                    Console.SetCursorPosition(playerY, playerX);
                    Console.Write('P');
                    Console.ForegroundColor = ConsoleColor.Magenta; // Путь за игроком
                    Console.SetCursorPosition(0, mapSize);


                    Console.SetCursorPosition(0, 25);
                    Console.WriteLine($"Здоровье: {playerhealt}, Сила: {playerbuff}, Шагов: {newcount}");


                    // механики 
                    AidUp();
                    Fight();
                    BuffUp();
                    BuffDown();
                    WinORLose();
                    SaveGame();

                }
            }



        }
    }
}