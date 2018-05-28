using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Source;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Укажите путь до директории.");
                return;
            }

            var pathToConfig = args[0];
            if (new FileInfo(pathToConfig).Extension != ".json")
            {
                Console.WriteLine("Укажите путь до файла .json");
            }

            var game = new Game(pathToConfig);
            game.Start();
        }
    }
}
