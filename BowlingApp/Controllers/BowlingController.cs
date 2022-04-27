using BowlingApp.Models;
using BowlingApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Controllers
{
    class BowlingController
    {
        private BowlingGame _bowlingGame;
        private Player _player;
        private BowlingView _bowlingView;

        public BowlingController()
        {
            _bowlingView = new BowlingView();
            _bowlingGame = new BowlingGame(_bowlingView.CurrentPins);
            _player = new Player(_bowlingView.Name, _bowlingView.Points);
            _bowlingView.ShowValues();
        }
    }
}
