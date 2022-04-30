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
        private int _current_Pins;
        private int[] _scoreboard;

        //Default constructor
        public BowlingGame() 
        {
            Name = "Player";
            Points = 0;
            Current_Pins = 10;
            Scoreboard = new int[21];
        }

        //Overloaded constructor
        public BowlingGame(string name, int points, int current_Pins, int[] scoreboard) 
        {
            Name = name;
            Points = points;
            Current_Pins = current_Pins;
            Scoreboard = scoreboard;
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
        public int Current_Pins
        {
            get => _current_Pins;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Amount of pins cannot be a negative value");
                if (value > 10)
                    throw new ArgumentException("Current pins exceeded maximum amount of = 10");
                _current_Pins = value;
            }
        }
        public int[] Scoreboard { get => _scoreboard; set => _scoreboard = value; }
    }
}
