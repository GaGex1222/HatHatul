using System;
using HatHatulGame;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using GameSquad;
using System.Xml.Linq;

namespace HatHatulGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string addPlayerChoice;
            List<Player> playerList = new List<Player>();
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
                bool retryAction = false;
                do
                {
                    Player.clearConsole();
                    Console.WriteLine($"Its {player.Name} Turn!, what will you do, 'draw', 'reveal' or 'top card'?" );
                    actionChoice = Console.ReadLine().ToLower();
                    Console.WriteLine($"{player.Name} have chosen {actionChoice}");
                    if(actionChoice == "draw")
                    {
                        int randomCard = player.Draw();
                        string replaceOrDrop;
                        do
                        {
                            Console.WriteLine(player.Name + $", You have drawn the card {randomCard}");
                            Console.WriteLine("Would you like to 'replace' it with on of your current cards or 'drop' it to be the top card?");
                            replaceOrDrop = Console.ReadLine().ToLower();
                            Player.clearConsole();
                        } while ( replaceOrDrop != "drop" && replaceOrDrop != "replace");
                        if (replaceOrDrop == "replace")
                        {
                            player.Replace(randomCard);
                        }
                        else if (replaceOrDrop == "drop")
                        {
                            player.Drop(randomCard);
                        }
                    } else if (actionChoice == "reveal")
                    {
                        player.Reveal();
                    } else if (actionChoice == "top card")
                    {
                        if(Player.TopCard != null)
                        {
                            player.Replace(int.Parse(Player.TopCard));
                        } else
                        {
                            Player.clearConsole();
                            Console.WriteLine("There is no top card at the moment!");
                            Console.ReadLine();
                            retryAction = true;
                        }
                    } else
                    {
                        retryAction = true;
                    }

                } while(retryAction);
            }
        }
    }
}
