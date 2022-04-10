using System;

namespace InheritanceAndPolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Weapon = new Knife();
            player.Weapon = new Ak47();
            player.Weapon = new Sniper();

            player.Weapon.Attack();

            player.Weapon = new DesertEagle();
            player.Weapon.Attack();

            Cooker cooker = new Cooker();
            Kofte kofte = new Kofte();
            Kurufasulye kurufasulye = new Kurufasulye();

            cooker.Cook(kofte);
            cooker.Cook(kurufasulye);
        }
    }
}
