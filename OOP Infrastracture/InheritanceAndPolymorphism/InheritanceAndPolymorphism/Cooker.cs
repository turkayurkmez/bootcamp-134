using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
   public class Cooker
    {
        public void Cook(Food food)
        {
            food.Cook();
        }
    }

    public class Food
    {
        public List<string> Ingredients { get; set; }
        public int Duration { get; set; }
        public void Cook()
        {
            Console.WriteLine("Yemek pişiyor....");
        }
    }

    public class VegetableFood: Food
    {

    }

    public class Meat: Food
    {

    }
    public class Kurufasulye: VegetableFood
    {

    }

    public class Kofte: Meat
    {

    }

    

}
