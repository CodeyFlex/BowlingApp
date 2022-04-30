using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Models
{
    public class Frame
    {
        public List<int> Throws { get; private set; }

        public Frame(List<int> throws)
        {
            if (throws == null || throws.Count() < 1 || throws.Count() > 3) { 
                throw new ArgumentException("Frames must consist of 1 to 3 throws", "throws");
            }

            if (throws.Any(bowlingThrow => bowlingThrow > 10)) { 
                throw new ArgumentException("A single throw cannot contain more 10 pins");
            }

            this.Throws = throws;
        }

        public bool IsSpare()
        {
            return this.Throws.Take(2).Sum() == 10;
        }

        public bool IsStrike()
        {
            return this.Throws.First() == 10;
        }

    }
}
