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
        private int _currentThrow;
        private int _currentThrowIndex; //Rename this
        private Random _rnd;
        private static string _format;

        //Constructor
        public BowlingController() 
        {
            //Initialization
            _bowlingView = new BowlingView();
            _bowlingGame = new BowlingGame(_bowlingView.Name, _bowlingView.Points, _bowlingView.CurrentPins, _bowlingView.Scoreboard);
            _currentThrow = 0;
            _rnd = new Random();

            //Initialization Method calls
            //Currently breaks some tests
            SetName();
            RunGame();
        }
        //Methods
        private void SetName()
        {
            Console.WriteLine("Enter player name");
            _bowlingView.Name = Console.ReadLine();
            Console.Clear();
        }
        private void RunGame()
        {
            //for (int i = 0; i < 21; i++)
            while (_currentThrow < 21)
            {
                Console.WriteLine("Press enter to shoot");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Player Name: " + _bowlingView.Name);
                RandomThrow();
                _bowlingView.Points = CalculateCurrentScoreboard;
                Print_Scoreboard_Formatted(_bowlingView.Scoreboard);
                _bowlingView.ShowValues();
            }
        }
        static void Print_Scoreboard_Formatted(int[] toPrint)
        {
            _format = "[{0}, {1}] [{2}, {3}] [{4}, {5}] [{6}, {7}] [{8}, {9}] [{10}, {11}] [{12}, {13}] [{14}, {15}]" +
                      " [{16}, {17}] [{18}, {19}, {20}]";
            Console.WriteLine(_format, toPrint.Cast<object>().ToArray());
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
            _bowlingView.Scoreboard[_currentThrow++] = pins;
        }
        //Game play methods
        public void RandomThrow() //For game play
        {
            int _throw = _rnd.Next(0, _bowlingView.CurrentPins); //Gets random throw lower than current pins
            _bowlingView.CurrentPins -= _throw; //changes current pins amount after throw
            _bowlingView.Scoreboard[_currentThrowIndex] = _throw; //Adds throw score to scoreboard
            if (_bowlingView.Scoreboard[_currentThrowIndex] == 10) //Strike
            {
                _currentThrow += 2;
                _currentThrowIndex++;
                _bowlingView.CurrentPins = 10;
            }
            else if (_currentThrow % 2 == 1) //Every new frame
            {
                _currentThrow++;
                _currentThrowIndex++;
                _bowlingView.CurrentPins = 10;
            }
            else
            {
                _currentThrow++;
                _currentThrowIndex++;
            }
            Console.WriteLine("You hit " + _throw + " Pins!");
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
