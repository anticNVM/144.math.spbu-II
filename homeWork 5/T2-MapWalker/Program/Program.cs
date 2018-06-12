using System;
using System.IO;
using Source;

namespace Program
{
    /// <summary>
    /// Класс, реализующий создание и запуск игры 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в консольную программу
        /// </summary>
        /// <param name="args">Входные параметры (1 - путь до файла конфигурации)</param>
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

            var mainloop = new ArrowPressEventLoop();
            Game game;
            try
            {
                game = new Game(pathToConfig, mainloop);
            }
            catch (Exception e) when (
                e is InvalidNumberOfAvatarsException ||
                e is InvalidNumberOfDestinationsException ||
                e is UnsupportedSymbolException ||
                e is FileNotFoundException ||
                e is DirectoryNotFoundException
            )
            {
                Console.WriteLine(e.Message);
                return;
            }

            mainloop.Register(game);
            try
            {
                game?.Start();
            }
            catch (Exception e) when (
                e is PlatformNotSupportedException
            )
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
