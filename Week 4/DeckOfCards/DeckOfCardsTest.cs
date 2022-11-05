// DeckOfCardsTest.cs
// Card shuffling and dealing application.
using System;

public class DeckOfCardsTest
{
    // execute application
    public static void Main(string[] args)
    {
        DeckOfCards myDeckOfCards = new DeckOfCards();
        myDeckOfCards.Shuffle(); // place Cards in random order

        // display all 52 Cards in the order in which they are dealt
        for (int i = 0; i < (int)Math.Ceiling(DeckOfCards.NUMBER_OF_CARDS / 5.0); i++)
        {
            myDeckOfCards.DealHand();

            Console.WriteLine($"{myDeckOfCards.PrintHandOfCards()}");
            Console.WriteLine($"Has 2 faces: {(myDeckOfCards.HasPair() ? "TRUE" : "FALSE")}");

            if ((i + 1) % 4 == 0)
                Console.WriteLine();
        }
    }
}

