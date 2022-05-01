using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BowlingApp.Controllers;

namespace BowlingAppTests.ControllerTests
{
    public class BowlingControllerTests
    {
        private readonly BowlingController _bowlingController;

        public BowlingControllerTests()
        {
            _bowlingController = new BowlingController(false);
        }

        [Fact]
        public void CanThrowGutterGame()
        {
            ThrowMany(0, 20);
            Assert.Equal(0, _bowlingController.CalculateCurrentScoreboard);
        }
        [Fact]
        public void CanThrowAllOnes()
        {
            ThrowMany(1, 20);
            Assert.Equal(20, _bowlingController.CalculateCurrentScoreboard);
        }
        [Fact]
        public void CanThrowSpare()
        {
            _bowlingController.Throw(5);
            _bowlingController.Throw(5);
            _bowlingController.Throw(3);
            ThrowMany(0, 17);
            Assert.Equal(16, _bowlingController.CalculateCurrentScoreboard);
        }
        [Fact]
        public void CanThrowStrike()
        {
            _bowlingController.Throw(10);
            _bowlingController.Throw(3);
            _bowlingController.Throw(4);
            ThrowMany(0, 16);
            Assert.Equal(24, _bowlingController.CalculateCurrentScoreboard);
        }

        [Fact]
        public void CanThrowPerfectGame()
        {
            ThrowMany(10, 12);
            Assert.Equal(300, _bowlingController.CalculateCurrentScoreboard);
        }

        private void ThrowMany(int pins, int throws)
        {
            for (var i = 0; i < throws; i++)
            {
                _bowlingController.Throw(pins);
            }
        }
    }
}
