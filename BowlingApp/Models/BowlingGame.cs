using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Models
{
    class BowlingGame
    {
        private int _current_Pins;

        public BowlingGame() //Default constructor
        {
            Current_Pins = 10;
        }

        public BowlingGame(int current_Pins) //Overloaded constructor
        {
            Current_Pins = current_Pins;
        }

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
    }
}
