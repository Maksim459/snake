class Figure
{
    public void Game(int one, int two, int oone, int otwo, int score, List<int> listone, List<int> listtwo)
    {
        //переменные
        int size = 11;
        //создаем массив
        string[,] field = new string[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                field[j, i] = "*";
            }
        }
        for (int i = 0; i <= score; i++)
        {
            field[listone.ElementAt(i), listtwo.ElementAt(i)] = "m";
        }
        field[oone, otwo] = "@";
        //вывод
        Console.WriteLine("используйте  WASD для управления\nиспользуйте E для выхода");
        Console.WriteLine($"Счет: {score}");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(field[j, i]);
            }
            Console.WriteLine();
        }
    }
    public void GameControl()
    {
        Console.WriteLine("используйте  WASD для управления\nиспользуйте E для выхода");
        //переменные
        int one = 5;
        int two = 5;
        int objone = 5;
        int objtwo = 5;
        int score = 0;
        List<int> listone = new List<int>();
        List<int> listtwo = new List<int>();
    Flag:

        Figure figure = new Figure();
        ConsoleKeyInfo position = Console.ReadKey();
        Console.Clear();
    FlagP:
        if (one == objone && two == objtwo)
        {
            Random random = new Random();
            objone = random.Next(10);
            objtwo = random.Next(10);
        }
        if (score == 15)
        {
            goto FlagFinal;
        }
        var myKey = position.Key;
        var x = ConsoleKey.I;
    //цикл управления
    FlagKey:
        switch (myKey)
        {
            case ConsoleKey.W:
                if (two > 0)
                {
                    two--;
                }
                else
                {
                    two = 10;
                }
                x = ConsoleKey.W;
                break;
            case ConsoleKey.A:
                if (one > 0)
                {
                    one--;
                }
                else
                {
                    one = 10;
                }
                x = ConsoleKey.A;
                break;
            case ConsoleKey.S:
                if (two < 10)
                {
                    two++;
                }
                else
                {
                    two = 0;
                }
                x = ConsoleKey.S;
                break;
            case ConsoleKey.D:
                if (one < 10)
                {
                    one++;
                }
                else
                {
                    one = 0;
                }
                x = ConsoleKey.D;
                break;
            case ConsoleKey.E:
                Console.Clear();
                goto FlagFinal;
            default:
                Console.WriteLine("вы ввели не тот символ,попробуйте снова");
                goto Flag;
        }

        for (int i = 0; i <= score; i++)
        {
            listone.Insert(0, one);
            listtwo.Insert(0, two);
            int indexToCheck = score+1;
            if (indexToCheck >= 0 && indexToCheck < listone.Count)
            {
                if (listone[indexToCheck] != 0)
                {
                    listone.RemoveAt(indexToCheck);
                    listtwo.RemoveAt(indexToCheck);
                }
            }
        }
        figure.Game(one, two, objone, objtwo, score,listone,listtwo);
        if (one == objone && two == objtwo)
        {
            Console.Clear();
            score++;
            goto FlagP;
        }
        DateTime startTimew = DateTime.Now.AddSeconds(0);
        while (DateTime.Now - startTimew < TimeSpan.FromSeconds(1))
        {
            if (Console.KeyAvailable)
            {
                position = Console.ReadKey();
                if (position.Key == x)
                {
                    Task.Delay(1000).Wait();
                    break;
                }
                else
                {
                    Console.Clear();
                    goto FlagP;
                }
            }
        }
        Console.Clear();
        goto FlagKey;
    FlagFinal:
        Console.WriteLine("\nспасибо за игру\nнажмите Enter чтобы выйти");
        Console.ReadLine();

    }
}
internal class Program
{
    private static void Main()
    {
        Figure figure = new Figure();
        figure.GameControl();
    }
}