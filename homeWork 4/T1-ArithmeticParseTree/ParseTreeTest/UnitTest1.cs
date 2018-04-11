using System;
using Xunit;
using ParseTreeSource;

namespace ParseTreeTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var tree = new ParseTree("( + ( * 1 2 ) 2 )");
        }
    }
}
