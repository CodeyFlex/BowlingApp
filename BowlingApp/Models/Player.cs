using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Models
{
    class Player
    {
        private string _name;
        private int _points;

        public Player() //Default constructor
        {
            Name = "Player";
            Points = 0;
        }

        public Player(string name, int points) //Overloaded constructor
        {
            Name = name;
            Points = points;
        }

        public string Name { get => _name; 
            set {
                if (value.Length <= 0)
                    throw new ArgumentException("Name is empty");
                if (value.Length > 20)
                    throw new ArgumentException("Name needs to be less than 20 characters long");
                _name = value; 
            } 
        }
        public int Points { get => _points; set => _points = value; }
    }
}
