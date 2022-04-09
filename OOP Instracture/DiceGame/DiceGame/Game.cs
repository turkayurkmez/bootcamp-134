using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
   public class Game
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        public Game()
        {
            PlayerOne = new Player();
            PlayerTwo = new Player();

        }



        public void PlayAndTurn()
        {
           
            PlayerOne.Play();
            PlayerTwo.Play();



        }

        public void ShowWinner()
        {
            if (PlayerOne.Score > PlayerTwo.Score)
            {
                Console.WriteLine($"{PlayerOne.Name}, toplam {PlayerOne.Score} ile kazandı");
            }
            else if (PlayerOne.Score < PlayerTwo.Score)
            {
                Console.WriteLine($"{PlayerTwo.Name}, toplam {PlayerTwo.Score} ile kazandı");
            }
            else
            {
                Console.WriteLine("Her iki oyuncunun puanı aynı");
            }
        }
    }
}
