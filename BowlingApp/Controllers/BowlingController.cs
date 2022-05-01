using BowlingApp.Models;
using BowlingApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Controllers
{
    public class BowlingController
    {
        //Properties
            //BowlingGame Model
        private BowlingGame _bowlingGame;
        private BowlingView _bowlingView;
            //Local
        private int _currentCalculatorThrowIndex; //Rename this
        private Random _rnd;
        private static string _scoreboardFormat; //GUI scoreboard formatting
        private int[] _scoreboardGUIArray; //GUI scoreboard

        //Constructor
        public BowlingController() 
        {
            //Initialization
            _bowlingView = new BowlingView();
            _bowlingGame = new BowlingGame(_bowlingView.Name, _bowlingView.Points, _bowlingView.CurrentPins, _bowlingView.CurrentGUIThrow, _bowlingView.Scoreboard);
            _currentCalculatorThrowIndex = 0;
            _rnd = new Random();
            _scoreboardGUIArray = new int[21];

            //Initialization Method calls
            //Currently breaks some tests
            RunGame();
        }
        //Methods
        
        private void RunGame() //Move this into view if possible
        {
            while (_bowlingView.CurrentGUIThrow < 21)
            {
                _bowlingView.DisplayThrowHint();
                RandomThrow(); //User input bowling throw
                _bowlingView.Points = CalculateCurrentScoreboard; //Sends points to the view
                Print_Scoreboard_Formatted(_scoreboardGUIArray); //Prints scoreboard
                _bowlingView.ShowValues(); //View call to show game values like Name, points & such
                CheckForThirdFrame(); //Checks if the third and final frame will be played
            }
        }
        static void Print_Scoreboard_Formatted(int[] toPrint)
        {
            _scoreboardFormat = "[{0}, {1}] [{2}, {3}] [{4}, {5}] [{6}, {7}] [{8}, {9}] [{10}, {11}] [{12}, {13}] [{14}, {15}]" +
                      " [{16}, {17}] [{18}, {19}, {20}]";
            Console.WriteLine(_scoreboardFormat, toPrint.Cast<object>().ToArray());
        }

        //This system only passes cause it counts consecutive, and ignores the 0 in between strikes
        public int CalculateCurrentScoreboard
        {
            get { 
                var score = 0;
                var frameIndex = 0;
                for (var frame = 0; frame < 10; frame++)
                {
                    if (IsAStrike(frameIndex)) //Strike
                    {
                        score += GetStrikeScore(frameIndex);
                        frameIndex++;
                    }
                    else if (IsASpare(frameIndex)) //Spare
                    {
                        score += GetSpareScore(frameIndex);
                        frameIndex += 2;
                    }
                    else //Standard shot
                    {
                        score += GetStandardScore(frameIndex);
                        frameIndex += 2;
                    }
                }
                return score;
            }
        }

        //Testing methods
        public void Throw(int pins)
        {
            _bowlingView.Scoreboard[_bowlingView.CurrentGUIThrow++] = pins;
        }
        //Game play methods
        public void RandomThrow() //For GUI
        {
            int _throw = _rnd.Next(10, _bowlingView.CurrentPins); //Gets random throw lower than current pins
            _bowlingView.CurrentPins -= _throw; //changes current pins amount after throw
            _bowlingView.Scoreboard[_currentCalculatorThrowIndex] = _throw; //Adds throw score to scoreboard
            _scoreboardGUIArray[_bowlingView.CurrentGUIThrow] = _throw; //Adds throw to GUI scoreboard
            if (_bowlingView.Scoreboard[_currentCalculatorThrowIndex] == 10 && _bowlingView.CurrentGUIThrow >= 18)
            {
                _bowlingView.CurrentGUIThrow++;
                _currentCalculatorThrowIndex++;
                _bowlingView.CurrentPins = 10;
            }
            else if (_bowlingView.Scoreboard[_currentCalculatorThrowIndex] == 10) //Strike
            {
                _bowlingView.CurrentGUIThrow += 2;
                _currentCalculatorThrowIndex++;
                _bowlingView.CurrentPins = 10;
            }
            else if (_bowlingView.CurrentGUIThrow % 2 == 1 && _bowlingView.CurrentGUIThrow <= 19) //Every new frame
            {
                _bowlingView.CurrentGUIThrow++;
                _currentCalculatorThrowIndex++;
                _bowlingView.CurrentPins = 10;
            }
            else
            {
                _bowlingView.CurrentGUIThrow++;
                _currentCalculatorThrowIndex++;
            }

            _bowlingView.DisplayPinsHit(_throw);
        }

        public void CheckForThirdFrame()
        {
            //Checking for the 21st shot
            if (_bowlingView.CurrentGUIThrow == 20 && IsAStrike(_bowlingView.Scoreboard[_bowlingView.CurrentGUIThrow]) != true)
            {
                _bowlingView.CurrentGUIThrow++;
            }
        }

        //Calculation of the score
        private bool IsAStrike(int frameIndex)
        {
            return _bowlingView.Scoreboard[frameIndex] == 10;
        }
        private bool IsASpare(int frameIndex)
        {
            return _bowlingView.Scoreboard[frameIndex] + _bowlingView.Scoreboard[frameIndex + 1] == 10;
        }
        private int GetStrikeScore(int frameIndex)
        {
            return _bowlingView.Scoreboard[frameIndex] + _bowlingView.Scoreboard[frameIndex + 1] + _bowlingView.Scoreboard[frameIndex + 2];
        }
        private int GetSpareScore(int frameIndex)
        {
            return _bowlingView.Scoreboard[frameIndex] + _bowlingView.Scoreboard[frameIndex + 1] + _bowlingView.Scoreboard[frameIndex + 2];
        }
        private int GetStandardScore(int frameIndex)
        {
            return _bowlingView.Scoreboard[frameIndex] + _bowlingView.Scoreboard[frameIndex + 1];
        }        
    }
}
