using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BowlingApp.Views;

namespace BowlingAppTests.ViewsTests
{
    public class BowlingViewTests
    {
        private readonly BowlingView _bowlingView;

        public BowlingViewTests()
        {
            _bowlingView = new BowlingView(false);
        }

        [Fact]
        public void CanSetName()
        {
            _bowlingView.Name = "Bobby";
            Assert.Equal("Bobby", _bowlingView.Name);
        }

        [Fact]
        public void CanSetPoints()
        {
            _bowlingView.Points = 300;
            Assert.Equal(300, _bowlingView.Points);
        }

        [Fact]
        public void CanSetCurrentPins()
        {
            _bowlingView.CurrentPins = 8;
            Assert.Equal(8, _bowlingView.CurrentPins);
        }

        [Fact]
        public void CanSetCurrentGUIThrowIndex()
        {
            _bowlingView.CurrentGUIThrowIndex = 4;
            Assert.Equal(4, _bowlingView.CurrentGUIThrowIndex);
        }

        [Fact]
        public void CanSetCurrentCalculatorThrowIndex()
        {
            _bowlingView.CurrentCalculatorThrowIndex = 6;
            Assert.Equal(6, _bowlingView.CurrentCalculatorThrowIndex);
        }

        [Fact]
        public void CanAddScoreToGUIScoreboard()
        {
            _bowlingView.ScoreboardGUIArray[15] = 8;
            Assert.Equal(8, _bowlingView.ScoreboardGUIArray[15]);
        }

        [Fact]
        public void CanFormatScoreboard()
        {
            int[] testArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 };
            string scores = string.Format(_bowlingView.ScoreboardFormat, testArray.Cast<object>().ToArray());
            Assert.Equal("[1, 2] [3, 4] [5, 6] [7, 8] [9, 10] [1, 2] [3, 4] [5, 6] [7, 8] [9, 10, 1]", scores);
        }
    }
}
