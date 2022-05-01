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
        private Random _rnd;

        //Constructor
        public BowlingController() 
        {
            //Initialization
            _bowlingView = new BowlingView();
            _bowlingGame = new BowlingGame(_bowlingView.Name, _bowlingView.Points, _bowlingView.CurrentPins, 
                _bowlingView.CurrentGUIThrowIndex, _bowlingView.CurrentCalculatorThrowIndex, 
                _bowlingView.ScoreboardGUIArray, _bowlingView.Scoreboard, 
                _bowlingView.ScoreboardFormat);
            //Local
            _rnd = new Random();

            //Initialization Method calls
            RunGame(); //Currently breaks some tests cause of console dependency
        }
        //Methods
        
        private void RunGame() //Move this into view if possible
        {
            while (_bowlingView.CurrentGUIThrowIndex < 21)
            {
                _bowlingView.DisplayThrowHint();
                RandomThrow(); //User input bowling throw
                _bowlingView.Points = CalculateCurrentScoreboard; //Sends points to the view
                Print_Scoreboard_Formatted(_bowlingView.ScoreboardGUIArray); //Prints scoreboard
                _bowlingView.ShowValues(); //View call to show game values like Name, points & such
                CheckForThirdFrame(); //Checks if the third and final frame will be played
            }
        }
        public void Print_Scoreboard_Formatted(int[] toPrint)
        {
            Console.WriteLine(_bowlingView.ScoreboardFormat, toPrint.Cast<object>().ToArray());
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
            _bowlingView.Scoreboard[_bowlingView.CurrentGUIThrowIndex++] = pins;
        }
        //Game play methods
        public void RandomThrow() //For GUI
        {
            int _throw = _rnd.Next(0, _bowlingView.CurrentPins); //Gets random throw lower than current pins
            _bowlingView.CurrentPins -= _throw; //changes current pins amount after throw
            _bowlingView.Scoreboard[_bowlingView.CurrentCalculatorThrowIndex] = _throw; //Adds throw score to scoreboard
            _bowlingView.ScoreboardGUIArray[_bowlingView.CurrentGUIThrowIndex] = _throw; //Adds throw to GUI scoreboard
            if (_bowlingView.Scoreboard[_bowlingView.CurrentCalculatorThrowIndex] == 10 && _bowlingView.CurrentGUIThrowIndex >= 18)
            {
                _bowlingView.CurrentGUIThrowIndex++;
                _bowlingView.CurrentCalculatorThrowIndex++;
                _bowlingView.CurrentPins = 10;
            }
            else if (_bowlingView.Scoreboard[_bowlingView.CurrentCalculatorThrowIndex] == 10) //Strike
            {
                _bowlingView.CurrentGUIThrowIndex += 2;
                _bowlingView.CurrentCalculatorThrowIndex++;
                _bowlingView.CurrentPins = 10;
            }
            else if (_bowlingView.CurrentGUIThrowIndex % 2 == 1 && _bowlingView.CurrentGUIThrowIndex <= 19) //Every new frame
            {
                _bowlingView.CurrentGUIThrowIndex++;
                _bowlingView.CurrentCalculatorThrowIndex++;
                _bowlingView.CurrentPins = 10;
            }
            else
            {
                _bowlingView.CurrentGUIThrowIndex++;
                _bowlingView.CurrentCalculatorThrowIndex++;
            }
            _bowlingView.DisplayPinsHit(_throw);
        }

        public void CheckForThirdFrame()
        {
            //Checking for the 21st shot
            if (_bowlingView.CurrentGUIThrowIndex == 20 && IsAStrike(_bowlingView.Scoreboard[_bowlingView.CurrentGUIThrowIndex]) != true)
            {
                _bowlingView.CurrentGUIThrowIndex++;
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
