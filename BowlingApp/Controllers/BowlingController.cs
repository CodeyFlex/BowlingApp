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
        public bool _runGUI;

        //Constructor
        public BowlingController(bool runGUI) 
        {
            //Local
            _rnd = new Random();
            _runGUI = true;
            _runGUI = runGUI;

            //Initialization
            _bowlingView = new BowlingView(runGUI);
            _bowlingGame = new BowlingGame(_bowlingView.Name, _bowlingView.Points, _bowlingView.CurrentPins, 
                _bowlingView.CurrentGUIThrowIndex, _bowlingView.CurrentCalculatorThrowIndex, 
                _bowlingView.ScoreboardGUIArray, _bowlingView.Scoreboard, 
                _bowlingView.ScoreboardFormat);
            

            //Initialization Method calls
            if (_runGUI)
            {
                RunGame();
            }
            
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
            DeductThrowFromCurrentPins(_throw); //changes current pins amount after throw
            UpdateScoreboard(_throw); //Adds throw score to scoreboard
            UpdateGUIScoreboard(_throw); //Adds throw to GUI scoreboard
            if (IsAStrike(_bowlingView.Scoreboard[_bowlingView.CurrentCalculatorThrowIndex]) && _bowlingView.CurrentGUIThrowIndex >= 18) //Strike at final frames
            {
                _bowlingView.CurrentGUIThrowIndex++;
                _bowlingView.CurrentCalculatorThrowIndex++;
                _bowlingView.CurrentPins = 11;
            }
            else if (IsAStrike(_bowlingView.Scoreboard[_bowlingView.CurrentCalculatorThrowIndex])) //Strike
            {
                _bowlingView.CurrentGUIThrowIndex += 2;
                _bowlingView.CurrentCalculatorThrowIndex++;
                _bowlingView.CurrentPins = 11;
            }
            else if (IsANewFrame(_bowlingView.CurrentGUIThrowIndex) && _bowlingView.CurrentGUIThrowIndex <= 19) //Every new frame
            {
                _bowlingView.CurrentGUIThrowIndex++;
                _bowlingView.CurrentCalculatorThrowIndex++;
                _bowlingView.CurrentPins = 11;
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
            if (_bowlingView.CurrentGUIThrowIndex == 20 && !IsAStrike(_bowlingView.Scoreboard[_bowlingView.CurrentGUIThrowIndex]))
            {
                _bowlingView.CurrentGUIThrowIndex++;
            }
        }
        

        //Running of game
        private int DeductThrowFromCurrentPins(int _throw)
        {
            return _bowlingView.CurrentPins -= _throw;
        }
        private int UpdateScoreboard(int _throw)
        {
            return _bowlingView.Scoreboard[_bowlingView.CurrentCalculatorThrowIndex] = _throw;
        }
        private int UpdateGUIScoreboard(int _throw)
        {
            return _bowlingView.ScoreboardGUIArray[_bowlingView.CurrentGUIThrowIndex] = _throw;
        }
        private bool IsANewFrame(int frameIndex)
        {
            return frameIndex % 2 == 1;
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
