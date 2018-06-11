namespace ParseTreeSource
{
    using System;
    using MapOfOperations = System.Collections.Generic.Dictionary<string, System.Func<int, int, int>>;

    public class TableOfOperations
    {
        /// <summary>
        /// Словарь допустимых арифметических операций
        /// </summary>
        public MapOfOperations Operations { get; }

        public TableOfOperations()
        {
            Operations = new MapOfOperations {
                {"+", (x, y) => x + y},
                {"-", (x, y) => x - y},
                {"*", (x, y) => x * y},
                {"/", (x, y) => x / y},
            };
        }

        public Func<int, int, int> this[string op]
        {
            get => Operations[op];
        }
    }
}