using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Views
{
    class BowlingView
    {
        //Properties
        private string _name;
        private int _points;
        private int _currentPins;
        private int _currentGuiThrow;
        private int[] _scoreboard;

        //Default Constructor
        public BowlingView() 
        {
            Name = "Player";
            Points = 0;
            CurrentPins = 10;
            _currentGuiThrow = 0;
            _scoreboard = new int[21];
            SetName();
            //GetValues();
        }

        //Getters & Setters
        public string Name { get => _name; set => _name = value; }
        public int Points { get => _points; set => _points = value; }
        public int CurrentPins { get => _currentPins; set => _currentPins = value; }
        public int CurrentGUIThrow { get => _currentGuiThrow; set => _currentGuiThrow = value; }
        public int[] Scoreboard { get => _scoreboard; set => _scoreboard = value; }


        //Methods
        private void GetValues()
        {
            //Not implemented
        }

        public void ShowValues()
        {
            Console.WriteLine("Player Name: " + Name);
            Console.WriteLine("Current Pins: " + CurrentPins);
            Console.WriteLine("Points: " + Points);
            Console.WriteLine("Current Throw: " + CurrentGUIThrow);
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
