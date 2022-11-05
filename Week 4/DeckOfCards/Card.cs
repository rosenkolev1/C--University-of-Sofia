// Card.cs
// Card class represents a playing card.
public class Card
{
    public static readonly string[] faces = { "Ace", "Deuce", "Three", "Four", "Five", "Six",
         "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
    public static readonly string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    
    private int face; // face of card ("Ace", "Deuce", ...)
    private int suit; // suit of card ("Hearts", "Diamonds", ...)
    
    // two-parameter constructor initializes card's face and suit
    public Card( int cardFace, int cardSuit )
    {
       face = cardFace; // initialize face of card
       suit = cardSuit; // initialize suit of card
    } // end two-parameter Card constructor

    public int Face { 
        get => this.face;
        set 
        {
            if (value >= 0 && value < faces.Length) this.face = value;
            else throw new ArgumentOutOfRangeException("Invalid face value");
        } 
    }

    public int Suit
    {
        get => this.suit;
        set
        {
            if (value >= 0 && value < suits.Length) this.suit = value;
            else throw new ArgumentOutOfRangeException("Invalid suit value");
        }
    }



    // return string representation of Card
    public override string ToString()
    {
       return faces[face] + " of " + suits[suit];
    } // end method ToString
} // end class Card

