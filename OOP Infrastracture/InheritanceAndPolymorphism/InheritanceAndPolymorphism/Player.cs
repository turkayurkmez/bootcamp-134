using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
   public class Player
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public int RunSpeed { get; set; }

        public Weapon Weapon { get; set; }
    }
}
