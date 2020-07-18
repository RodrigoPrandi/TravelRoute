using TravelRouteConsole;
using NUnit.Framework;
using System;

namespace TravelRouteConsoleTest
{
    public class ProgramTest
    {
        [Test]
        public void WhenSendEmptyArgumentThenReturnArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Program.Main(Array.Empty<string>()));

            Assert.That(ex.Message, Is.EqualTo("Please enter a csv file."));
        }

        [Test]
        public void WhenSendMoreThenOneArgumentThenReturnArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => Program.Main(new string[]{"first", "second"}));

            Assert.That(ex.Message, Is.EqualTo("Please enter a csv file."));
        }

        [Test]
        public void WhenSendOnlyOneArgumentThenInitializeProgram()
        {
            Program.Main(new string[] { "first" });

            Assert.Pass();
        }
    }
}