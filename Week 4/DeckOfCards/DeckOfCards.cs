// DeckOfCards.cs
// DeckOfCards class represents a deck of playing cards.
using System;

public class DeckOfCards
{
    private Card[] deck; // array of Card objects
    private int currentCard; // index of next Card to be dealt
    public const int NUMBER_OF_CARDS = 52; // constant number of Cards
    private Random randomNumbers; // random number generator

    private Card[] handOfCards;
    private int[] faceCounters;
    private int[] suitCounters;

    private enum GameStats { PAIR = 2, TWO_PAIR, }

    // constructor fills deck of Cards
    public DeckOfCards()
    {
        handOfCards = new Card[5];
        faceCounters = new int[Card.faces.Length];
        suitCounters = new int[Card.suits.Length];

        deck = new Card[NUMBER_OF_CARDS]; // create array of Card objects
        currentCard = 0; // set currentCard so deck[ 0 ] is dealt first  
        randomNumbers = new Random(); // create random number generator
    
       // populate deck with Card objects
        for ( int count = 0; count < deck.Length; count++ )
           deck[ count ] =
              new Card( count % 13, count / 13 );
    } 
    
    // shuffle deck of Cards with one-pass algorithm
    public void Shuffle()
    {
        // after shuffling, dealing should start at deck[ 0 ] again
        currentCard = 0; // reinitialize currentCard
        
        // for each Card, pick another random Card and swap them
        for ( int first = 0; first < deck.Length; first++ )
        {
           // select a random number between 0 and 51 
           int second = randomNumbers.Next( NUMBER_OF_CARDS );
        
           // swap current Card with randomly selected Card
           Card temp = deck[ first ];
           deck[ first ] = deck[ second ];
           deck[ second ] = temp;
        } // end for
    } 
    
    // deal one Card
    public Card? DealCard()
    {
        // determine whether Cards remain to be dealt
        if ( currentCard < deck.Length )
           return deck[ currentCard++ ]; // return current Card in array
        else
           return null; // indicate that all Cards were dealt
    } 

    public void DealHand()
    {
        for (int i = 0; i < faceCounters.Length; i++)
        {
            faceCounters[i] = 0;
        }
        for (int i = 0; i < suitCounters.Length; i++)
        {
            suitCounters[i] = 0;
        }
        for (int i = 0; i < handOfCards.Length; i++)
        {
            handOfCards[i] = DealCard();
        }

        ComputeCounters();
    }

    private void ComputeCounters()
    {
        for (int i = 0; i < handOfCards.Length; i++)
        {
            if (handOfCards[i] != null)
            {
                faceCounters[handOfCards[i].Face]++;
                suitCounters[handOfCards[i].Suit]++;
            }
        }
    }

    public bool HasPair()
    {
        for (int i = 0; i < faceCounters.Length; i++)
        {
            if (faceCounters[i] == (int)GameStats.PAIR) return true;
        }

        return false;
    }

    public bool Has2Plus2Suits()
    {
        bool hasFirstTwo = false;
        for (int i = 0; i < faceCounters.Length; i++)
        {
            if (faceCounters[i] == (int)GameStats.PAIR && hasFirstTwo) return true;
            else
            {
                hasFirstTwo = true;
            }
        }

        return false;
    }

    public string PrintHandOfCards()
    {
        string result = "";
        for (int i = 0; i < handOfCards.Length; i++)
        {
            result += handOfCards[i]?.ToString() + "KUR";
        }
        return string.Join(", ", result.Split("KUR").Where(x => x.Length > 0));
    }
}
