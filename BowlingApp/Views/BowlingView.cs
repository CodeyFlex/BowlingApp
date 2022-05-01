using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Views
{
    public class BowlingView
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
        //Local
        public bool _runGUI;

        //Default Constructor
        public BowlingView(bool runGUI) 
        {
            //Local
            _runGUI = true;
            _runGUI = runGUI;

            //View variables
            Name = "Player";
            Points = 0;
            CurrentPins = 10;
            CurrentGUIThrowIndex = 0;
            CurrentCalculatorThrowIndex = 0;
            ScoreboardGUIArray = new int[21];
            Scoreboard = new int[21];
            ScoreboardFormat = "[{0}, {1}] [{2}, {3}] [{4}, {5}] [{6}, {7}] [{8}, {9}] [{10}, {11}] [{12}, {13}] [{14}, {15}]" +
                               " [{16}, {17}] [{18}, {19}, {20}]";

            if (_runGUI)
            {
                SetName();
            }
            
        }

        //Getters & Setters
        public string Name { get => _name; set => _name = value; }
        public int Points { get => _points; set => _points = value; }
        public int CurrentPins { get => _currentPins; set => _currentPins = value; }
        public int CurrentGUIThrowIndex { get => _currentGuiThrowIndex; set => _currentGuiThrowIndex = value; }
        public int CurrentCalculatorThrowIndex { get => _currentCalculatorThrowIndex; set => _currentCalculatorThrowIndex = value; }
        public int[] Scoreboard { get => _scoreboard; set => _scoreboard = value; }
        public int[] ScoreboardGUIArray { get => _scoreboardGUIArray; set => _scoreboardGUIArray = value; }
        public string ScoreboardFormat { get => _scoreboardFormat; set => _scoreboardFormat = value; }

        //Methods
        public void ShowValues()
        {
            Console.WriteLine("Player Name: " + Name);
            Console.WriteLine("Current Pins: " + CurrentPins);
            Console.WriteLine("Points: " + Points);
            Console.WriteLine("Current Throw: " + CurrentGUIThrowIndex);
        }
        public void DisplayPinsHit(int pins)
        {
            Console.WriteLine("You hit " + pins + " Pins!");
        }

        public void DisplayThrowHint()
        {
            Console.WriteLine("Press enter to shoot");
            Console.ReadLine();
            Console.Clear();
        }
        private void SetName()
        {
            Console.WriteLine("Enter player name");
            Name = Console.ReadLine();
            Console.Clear();
        }
    }
}
