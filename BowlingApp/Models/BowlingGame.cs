using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Models
{
    class BowlingGame
    {
        //Properties
        private string _name;
        private int _points;
        private int _currentPins;
        private int _currentGuiThrowIndex;
        private int _currentCalculatorThrowIndex;
        private int[] _scoreboardGUIArray; //GUI scoreboard
        private int[] _scoreboard;
        private string _scoreboardFormat; //GUI scoreboard formatting

        //Default constructor
        public BowlingGame() 
        {
            Name = "Player";
            Points = 0;
            CurrentPins = 10;
            CurrentGUIThrowIndex = 0;
            CurrentCalculatorThrowIndex = 0;
            ScoreboardGUIArray = new int[21];
            Scoreboard = new int[21];
            ScoreboardFormat = "[{0}, {1}] [{2}, {3}] [{4}, {5}] [{6}, {7}] [{8}, {9}] [{10}, {11}] [{12}, {13}] [{14}, {15}]" +
                               " [{16}, {17}] [{18}, {19}, {20}]";
        }

        //Overloaded constructor
        public BowlingGame(string name, int points, int currentPins, int currentGuiThrowIndex, 
            int currentCalculatorThrowIndex, int[] scoreboardGUIArray, int[] scoreboard, string scoreboardFormat) 
        {
            Name = name;
            Points = points;
            CurrentPins = currentPins;
            CurrentGUIThrowIndex = currentGuiThrowIndex;
            CurrentCalculatorThrowIndex = currentCalculatorThrowIndex;
            ScoreboardGUIArray = scoreboardGUIArray;
            Scoreboard = scoreboard;
            ScoreboardFormat = scoreboardFormat;
        }

        //Getters & Setters
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length <= 0)
                    throw new ArgumentException("Name is empty");
                if (value.Length > 20)
                    throw new ArgumentException("Name needs to be less than 20 characters long");
                _name = value;
            }
        }
        public int Points { get => _points; set => _points = value; }
        public int CurrentPins
        {
            get => _currentPins;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Amount of pins cannot be a negative value");
                if (value > 10)
                    throw new ArgumentException("Current pins exceeded maximum amount of = 10");
                _currentPins = value;
            }
        }
        public int CurrentGUIThrowIndex { get => _currentGuiThrowIndex; set => _currentGuiThrowIndex = value; }
        public int CurrentCalculatorThrowIndex { get => _currentCalculatorThrowIndex; set => _currentCalculatorThrowIndex = value; }
        public int[] ScoreboardGUIArray { get => _scoreboardGUIArray; set => _scoreboardGUIArray = value; }
        public int[] Scoreboard { get => _scoreboard; set => _scoreboard = value; }
        public string ScoreboardFormat { get => _scoreboardFormat; set => _scoreboardFormat = value; }
    }
}
