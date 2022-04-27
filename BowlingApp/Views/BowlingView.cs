using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Views
{
    class BowlingView
    {
        private string _name;
        private int _points;
        private int _currentPins;

        public BowlingView()
        {
            Name = "Player";
            Points = 10;
            CurrentPins = 10;
            GetValues();
        }

        public string Name { get => _name; set => _name = value; }
        public int Points { get => _points; set => _points = value; }
        public int CurrentPins { get => _currentPins; set => _currentPins = value; }

        private void GetValues()
        {
            Console.WriteLine("Press enter to shoot"); //placeholder
            Console.ReadLine();
            //CurrentPins = int.Parse(Console.ReadLine());
        }

        public void ShowValues()
        {
            Console.WriteLine("Current Pins: " + CurrentPins);
        }
    }
}
