using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
   public class Dice
    {
        public int Number { get; set; }
        public void ThrowDice()
        {
            Number = new Random().Next(1, 7);
        }
    }
}
