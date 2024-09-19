using System;
using Cards2;

namespace _9_19_lab {
    class Player {
        private string name;
        private List<Card> cardList;

        public void addCard(Card newCard) {
            cardList.Add(newCard);
        }
        public void printCards() {
            Console.WriteLine($"{name}:");
            foreach (Card card in cardList) {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
        }

        public Player() {
            name = "John Doe";
            cardList = new List<Card>();
        }
        public Player(string n) {
            name = n;
            cardList = new List<Card>();
        }
    }

    class Program {
        public static void Main(string[] args)
        {
            // loop while there's more input
            string input = Console.ReadLine();
            while (input != "q") {

                // Add your code between this comment
                // and the comment below. You can of
                // course add more space between the
                // comments as needed

                // declare a deck variables and create a deck object
                // DON'T SHUFFLE THE DECK

                Deck deck = new Deck();
                Player p1 = new Player();
                Player p2 = new Player("Jason");
                Player p3 = new Player("Lana");
                Player p4 = new Player("Marva");

                // deal 2 cards each to 4 players (deal properly, dealing
                // the first card to each player before dealing the
                // second card to each player)

                Card card1 = deck.TakeTopCard();
                p1.addCard(card1);
                
                Card card2 = deck.TakeTopCard();
                p2.addCard(card2);

                Card card3 = deck.TakeTopCard();
                p3.addCard(card3);

                Card card4 = deck.TakeTopCard();
                p4.addCard(card4);

                Card card5 = deck.TakeTopCard();
                p1.addCard(card5);

                Card card6 = deck.TakeTopCard();
                p2.addCard(card6);

                Card card7 = deck.TakeTopCard();
                p3.addCard(card7);

                Card card8 = deck.TakeTopCard();
                p4.addCard(card8);

                // deal 1 more card to players 2 and 3

                Card card9 = deck.TakeTopCard();
                p2.addCard(card9);

                Card card10 = deck.TakeTopCard();
                p3.addCard(card10);

                // flip all the cards over

                card1.FlipOver();
                card2.FlipOver();
                card3.FlipOver();
                card4.FlipOver();
                card5.FlipOver();
                card6.FlipOver();
                card7.FlipOver();
                card8.FlipOver();
                card9.FlipOver();
                card10.FlipOver();

                // print the cards for player 1
                p1.printCards();

                // print the cards for player 2
                p2.printCards();

                // print the cards for player 3
                p3.printCards();

                // print the cards for player 4
                p4.printCards();

                // Don't add or modify any code below
                // this comment */
                input = Console.ReadLine();
            }
        }
    }
}

//input[0] != 'q'