using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Source;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // if (args.Length == 0)
            // {
            //     Console.WriteLine("Укажите путь до директории");
            //     return;
            // }

            // var files = Directory.GetFiles(args[0]);
            // var pathToConfig = files.First(file => new FileInfo(file).Extension == ".json");
            // var pathToMap = files.First(file => new FileInfo(file).Extension == ".txt");

            // string preConfig = File.ReadAllText(pathToConfig);
            // StreamReader preMap = new StreamReader(pathToMap);

            // var game = new Game(pathToConfig, pathToMap);

            new Kek();
        }
    }

    public class Kek
    {
        public Kek()
        {
            string dirname = @"../Resources/ExampleMap/";

            //Directory.GetFiles(dirname).ToList().ForEach(str => System.Console.WriteLine(new FileInfo(str).Extension));
            //Directory.GetFiles(dirname).ToList().ForEach(str )

            var strConfig = Directory.GetFiles(dirname).First(file => (new FileInfo(file)).Extension == ".json");
            var conf = JsonConvert.DeserializeObject<MapConfig>(File.ReadAllText(strConfig));
            System.Console.WriteLine(conf.Keywords["wall"]);
        }
    }
}
