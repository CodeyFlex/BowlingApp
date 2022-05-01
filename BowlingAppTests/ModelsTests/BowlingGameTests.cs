using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BowlingApp.Models;

namespace BowlingAppTests.ModelsTests
{
    public class BowlingGameTests
    {
        private readonly BowlingGame _bowlingGame;

        public BowlingGameTests()
        {
            _bowlingGame = new BowlingGame();
        }

        [Fact]
        public void CanSetName()
        {
            _bowlingGame.Name = "Tommy";
            Assert.Equal("Tommy", _bowlingGame.Name);
        }

        [Fact]
        public void CantNullName()
        {
            Assert.Throws<ArgumentException>(() => _bowlingGame.Name = "");
        }
    }
}
