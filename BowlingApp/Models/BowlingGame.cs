using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Models
{
    public class BowlingGame
    {
        //Properties
        private string _name;
        private int _points;
        private int _currentPins;
        private int _currentGuiThrowIndex;
        private int _currentCalculatorThrowIndex;
        private int[] _scoreboardGUIArray; //GUI scoreboard
        private int[] _scoreboard;

        //Default constructor
        public BowlingGame() 
        {
            Name = "Player";
            Points = 0;
            CurrentPins = 11;
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
        public int Points { get; set; }
        public int CurrentPins
        {
            get => _currentPins;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Amount of pins cannot be a negative value");
                if (value > 11)
                    throw new ArgumentException("Current pins exceeded maximum amount of = 11");
                _currentPins = value;
            }
        }
        public int CurrentGUIThrowIndex { get; set; }
        public int CurrentCalculatorThrowIndex { get; set; }
        public int[] ScoreboardGUIArray { get; set; }
        public int[] Scoreboard { get; set; }
        public string ScoreboardFormat { get; set; }
    }
}
