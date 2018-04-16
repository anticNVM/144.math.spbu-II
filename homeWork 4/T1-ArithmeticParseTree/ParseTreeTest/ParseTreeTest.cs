using System;
using Xunit;
using ParseTreeSource;

namespace ParseTreeTest
{
    public class ParseTreeTest
    {
        [Fact]
        public void Test1()
        {
            var tree = new ParseTree("( + ( * 1 2 ) 2 )");
            Assert.Equal(4, tree.Evaluate());
            // Assert.Equal("", tree.ToString());
        }
    }
}
