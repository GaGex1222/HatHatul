using System;
using HatHatul;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HatHatulGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string addPlayerChoice;
            List<Player> playerList = new List<Player>();
            Console.WriteLine("Players counht: " + playerList.Count);
            Console.WriteLine("Welcome to HatHatul Written in C#!, Press any key to play!");
            Console.ReadLine();
            do
            {
                Console.Clear();
                Console.WriteLine("Add A Player?");
                addPlayerChoice = Console.ReadLine().ToLower();
                if (addPlayerChoice == "yes")
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the player name: ");
                    string playerName = Console.ReadLine();
                    Player player = new Player(playerName);
                    playerList.Add(player);
                    Console.WriteLine($"{playerName} has been added.");

                }
            } while(addPlayerChoice != "no");

            foreach (Player player in playerList)
            {
                Console.Clear();
                player.showPlayerLeftAndRightCards();
                Console.ReadLine();
            }


            foreach (Player player in playerList)
            {
                string actionChoice;
                do
                {
                    Player.clearConsole();
                    Console.WriteLine($"Its {player.Name} Turn!, what will you do, Draw OR Reveal?" );
                    actionChoice = Console.ReadLine().ToLower();
                    Console.WriteLine($"{player.Name} have chosen {actionChoice}");
                    if(actionChoice == "draw")
                    {
                        player.Draw();
                    } else if (actionChoice == "reveal")
                    {
                        player.Reveal();
                    }

                } while(actionChoice != "draw" && actionChoice != "reveal");
            }
        }
    }
}
