using System;
using Cards2;


namespace _9_19_lab {
    class Player {
        // Attributes
        private string name;
        private List<Card> hand;

        // Methods
        /// <summary>
        /// Deals card from a deck, adds card to player's hand
        /// </summary>
        /// <param name="newCard">Card to add to player's hand</param>
        public void deal(Card newCard) { 
            bool duplicate = false;

            int i = 0;
            while (!duplicate && i < hand.Count) { // Checks for duplicate
                if (hand[i].Rank == newCard.Rank && hand[i].Suit == newCard.Suit) {
                    duplicate = true;
                }
                i++;
            }
            
            if (duplicate) {
                Console.WriteLine("Cannot add the same card to hand!");
            }
            else {
                hand.Add(newCard);
            }
        }
        // Can't handle case of empty hand (list) without an exception handler due to non-void return type
        /// <summary>
        /// Removes card from player's hand
        /// </summary>
        /// <param name="cardToRemove">The card to remove, takes in index of card in hand</param>
        /// <returns>The card that is being removed. Can be assigned to a card to hold it</returns>
        /// <exception cref="ArgumentOutOfRangeException">Invalid index or list is empty</exception>
        public Card removeCard(Card cardToRemove) { // To delete, must insert the card index in `hand`
            if (hand.Contains(cardToRemove)) {
                hand.Remove(cardToRemove);

                return cardToRemove;
            }
            if (hand.Count == 0) {
                throw new ArgumentOutOfRangeException();
            }
            else {
                throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// The number of cards left in the player's hand
        /// </summary>
        /// <returns>An integer of cards left</returns>
        public int cardsLeft() { return hand.Count; }
        /// <summary>
        /// If the player's hand is empty. No cards left
        /// </summary>
        /// <returns>True if hand is empty. False if hand is not empty</returns>
        public bool isHandEmpty() { return hand.Count == 0; }
        /// <summary>
        /// Prints the player's name and their cards' rank and suit that's in their hand
        /// </summary>
        public void printHand() {
            if (hand.Count == 0) {
                Console.WriteLine($"{name}'s hand is empty");
            }
            else {
                Console.WriteLine($"{name}'s hand:");
                foreach (Card card in hand) {
                    Console.WriteLine($"{card.Rank} of {card.Suit}");
                }
            }
        }
        /// <summary>
        /// Sorts the cards in player's hand by rank then suits.
        /// </summary>
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
        /// <summary>
        /// Default constructor for Player
        /// </summary>
        public Player() {
            name = "John Doe";
            hand = new List<Card>();
        }
        /// <summary>
        /// Overload constructor for Player
        /// </summary>
        /// <param name="n">Name of player</param>
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
            
            // Test Case 1: Initialize
            Console.WriteLine("TEST CASE 1\n");
            Player player1 = new Player("Jason");
            Player player2 = new Player("Lana");
            Player player3 = new Player("Prof. Tang");

            Console.WriteLine(player1);
            Console.WriteLine(player2);
            Console.WriteLine(player3);

            // Test Case 2: Add Card to player
            Console.WriteLine("\nTEST CASE 2\n");
            player1.deal(deck.TakeTopCard());
            Console.WriteLine(player1);
            player1.printHand();

            // Test Case 3: Remove card from player
            Console.WriteLine("\nTEST CASE 3\n");
            Card card = player1.removeCard(player1.Hand[0]);
            Console.WriteLine($"Card removed: {card.Rank} of {card.Suit}");
            player1.printHand();

            // Test Case 4: Card count
            Console.WriteLine("\nTEST CASE 4\n");
            Console.WriteLine($"Count: {player1.cardsLeft()}");

            // Test Case 5: Card location validation
            Console.WriteLine("\nTEST CASE 5\n");
            try {
                Card card2 = player1.removeCard(player1.Hand[50]);
            }
            catch (ArgumentOutOfRangeException e) {
                Console.WriteLine(e.Message);
            }

            // Test Case 6: Test Empty Hand Deck
            Console.WriteLine("\nTEST CASE 6\n");
            try {
                Card card2 = player1.removeCard(player1.Hand[0]);
            }
            catch (ArgumentOutOfRangeException e) {
                Console.WriteLine(e.Message);
            }

            // Test Case 7: Display Cards
            Console.WriteLine("\nTEST CASE 7\n");
            player1.deal(deck.TakeTopCard());
            player1.printHand();
            player2.printHand();
            player3.printHand();

            // Test Case 8: Sorting by Card Value
            Console.WriteLine("\nTEST CASE 8\n");
            for (uint i = 0; i < 5; i++) {
                player2.deal(deck.TakeTopCard());
            }
            player2.sortHand(); // For one suit
            player2.printHand();

            for (uint i = 0; i < 14; i++) {
                player3.deal(deck.TakeTopCard());
            }
            player3.sortHand(); // For two suits
            player3.printHand();

            // Test Case 9: Multiple deals
            Console.WriteLine("\nTEST CASE 9\n");
            for (uint i = 0; i < 6; i++) {
                player1.deal(deck.TakeTopCard());
                player2.deal(deck.TakeTopCard());
                player3.deal(deck.TakeTopCard());
            }
            player1.printHand();
            player2.printHand();
            player3.printHand();

            // Test Case 10: Duplicate cards
            Console.WriteLine("\nTEST CASE 10\n");
            Player player4 = new Player();
            Deck deck2 = new Deck();
            Deck deck3 = new Deck();
            player4.deal(deck2.TakeTopCard()); // Takes King of Spades
            player4.deal(deck3.TakeTopCard()); // Takes King of Spades
            player4.printHand();

            // Test Case 11: Remove non-existent card
            Console.WriteLine("\nTEST CASE 11\n");
            Console.WriteLine("Refer to Test Case 5");

        }
    }
}
