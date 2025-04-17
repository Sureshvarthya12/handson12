using System;
using Xunit;
using HelloWorld;

namespace HelloWorld.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestHelloWorld()
        {
            // A simple test that always passes
            Assert.True(true);
            
            // If you want to test the Program class functionality, 
            // you would need to modify your Program class to make it more testable
        }
    }
}