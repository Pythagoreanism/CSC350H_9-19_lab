using System;
using Cards2;


namespace _9_19_lab {
    class Player {
        // Attributes
        private string name;
        private List<Card> hand;

        // Methods
        public void deal(Card newCard) { hand.Add(newCard); }
        public Card removeCard(Card cardToRemove) { // To delete, must insert the card index in `hand`
            Card temp = cardToRemove;
            hand.Remove(cardToRemove); 
            return temp;
        }
        public int cardsLeft() { return hand.Count; }
        public bool isHandEmpty() { return hand.Count == 0; }
        public void printHand() {
            Console.WriteLine($"{name}'s hand:");
            foreach (Card card in hand) {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
        }
        public void sortHand() {
            for (int i = 0; i < hand.Count - 1; i++) {
                int min = i;

                for (int j = i + 1; j < hand.Count; j++) {
                    if (hand[min].Rank > hand[j].Rank) {
                        min = j;
                    }
                }

                Card temp = hand[i];
                hand[i] = hand[min];
                hand[min] = temp;
            }
        }

        // Properties
        public string Name { set { name = value; } }
        public List<Card> Hand { get { return hand; } }

        // Constructors
        public Player() {
            name = "John Doe";
            hand = new List<Card>();
        }
        public Player(string n) {
            name = n;
            hand = new List<Card>();
        }

        // Overrides
        public override string ToString() {
            if (hand.Count == 1) {
                return $"{name} has {hand.Count} card";
            }
            else {
                return $"{name} has {hand.Count} cards";
            }
        }
    }


    class Program {
        // TODO: Insert function to initialize game
        public static void Main(string[] args) {
            Deck deck = new Deck();
            Player player1 = new Player("Jason P");

            player1.deal(deck.TakeTopCard());
            Console.WriteLine(player1);

            Card temp = player1.removeCard(player1.Hand[0]);
            Console.WriteLine(player1);
            Console.WriteLine($"Card taken: {temp.Suit} of {temp.Rank}");

            for (uint i = 0; i < 13; i++) {
                player1.deal(deck.TakeTopCard());
            }
            
            Console.WriteLine("Before sort");
            player1.printHand();
            player1.sortHand();
            Console.WriteLine("\nAfter sort with one suit");
            player1.printHand();

            Player player2 = new Player("John");
            for (uint i = 0; i < 14; i++) { 
                player2.deal(deck.TakeTopCard());
            }

            Console.WriteLine("\nBefore sort:\n");
            player2.printHand();
            player2.sortHand();
            Console.WriteLine("\nAfter sort:\n");
            player2.printHand();
        }
    }
}
