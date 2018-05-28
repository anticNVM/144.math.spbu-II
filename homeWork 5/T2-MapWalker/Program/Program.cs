using System;
using System.IO;
using Source;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Укажите путь до файла конфигурации.");
                return;
            }

            var pathToConfig = args[0];
            if (new FileInfo(pathToConfig).Extension != ".json")
            {
                Console.WriteLine("Файл конфигурации должен быть в формате json");
                return;
            }

            var game = new Game(pathToConfig);
            game.Start();
        }
    }
}
