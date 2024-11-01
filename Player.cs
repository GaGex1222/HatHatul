using System;
using System.Collections.Generic;
using System.Linq;


namespace PlayerClass
{
    public class Player
    {
        Random random = new Random();
        private string name;
        private List<int> cards = new List<int>();
        private static string topCard;

        public string Name {  get { return name; } }
        public static string TopCard { get { return topCard; } set { topCard = value; } }

        public static void clearConsole()
        {
            Console.Clear();
            Console.WriteLine("Top Card: " + TopCard);
        }

        public Player(string name)
        {
            cards.Add(random.Next(1, 11));
            cards.Add(random.Next(1, 11));
            cards.Add(random.Next(1, 11));
            cards.Add(random.Next(1, 11));
            this.name = name;
        }



        public void showPlayerLeftAndRightCards()
        {
            Console.WriteLine($"{name}, " + "Here are your left and right Cards\n" + $"1. {cards[0]} 2. ? 3. ? 4. {cards[3]}");
        }
        
        public void Draw()
        {
            clearConsole();
            int randomCard = random.Next(1, 11);
            Console.WriteLine(name + $", You have drawn the card {randomCard}");
            Console.WriteLine("Would you like to 'replace' it with on of your current cards or 'drop' it to be the top card?");
            string choice = Console.ReadLine().ToLower();
            clearConsole();
            if (choice == "replace")
            {
                Replace(randomCard);
            }
        }

        public void Replace(int card)
        {

            clearConsole();
            Console.WriteLine("Select the card index in hand you want to replace (1-4)");
            int cardToReplaceIndex = Convert.ToInt32(Console.ReadLine());
            int cardToReplace = cards[cardToReplaceIndex - 1];
            cardToReplace = card; // replacing the card in the players deck
            TopCard = cardToReplace.ToString(); // setting the top card to be the thrown card from the player's deck
        }

        public void Reveal()
        {
            Console.WriteLine("Reveal cards!");
        }
            
    }
}
