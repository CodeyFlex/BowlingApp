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
        public void CantMakeNameTooLong()
        {
            Assert.Throws<ArgumentException>(() => _bowlingGame.Name = "ThisIsAVeryLongNameThatPeopleStruggleToSayAndICriEveritiem");
        }

        [Fact]
        public void CantNullName()
        {
            Assert.Throws<ArgumentException>(() => _bowlingGame.Name = "");
        }

        [Fact]
        public void CanSetCurrentPins()
        {
            _bowlingGame.CurrentPins = 8;
            Assert.Equal(8, _bowlingGame.CurrentPins);
        }

        [Fact]
        public void CantExceedMaxPins()
        {
            Assert.Throws<ArgumentException>(() => _bowlingGame.CurrentPins = 15);
        }

        [Fact]
        public void CanAddScoreToScoreboard()
        {
            _bowlingGame.Scoreboard[15] = 8;
            Assert.Equal(8, _bowlingGame.Scoreboard[15]);
        }

        [Fact]
        public void CantAddOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _bowlingGame.Scoreboard[22] = 15);
        }

        [Fact]
        public void CanChangeCurrentGUIThrowIndex()
        {
            _bowlingGame.CurrentGUIThrowIndex = 12;
            Assert.Equal(12, _bowlingGame.CurrentGUIThrowIndex);
        }

        [Fact]
        public void CanChangeCurrentCalculatorThrowIndex()
        {
            _bowlingGame.CurrentCalculatorThrowIndex = 14;
            Assert.Equal(14, _bowlingGame.CurrentCalculatorThrowIndex);
        }
    }
}
