// Author: Ynno Plucena
// Date : 5/13/22

using System;

namespace HighLow {
    
    class Player {
        Cards card = new Cards();
        int points = 300;
        string guess = "";
        string retry = "y";
        public void Guess() {
            while (guess.ToLower() != "l" && guess.ToLower() !="h") {
                Console.Write("Higher or Lower[H/L]: ");
                guess = Console.ReadLine();
                if (guess.ToLower() !="l" && guess.ToLower() !="h") {
                    Console.WriteLine($"\"{guess}\" is not a valid response.");
                }
            }
        }
        bool GuessTest(Cards card) {
            if ((card.getCardOld() <= card.getCardNumber()) && (guess.ToLower()=="h")) {
                guess = "";
                return true;
            }
            else if ((card.getCardOld() >= card.getCardNumber()) && (guess.ToLower()=="l")) {
                guess = "";
                return true;
            }
            else {
                guess = "";
                return false;
            }
        }
        public void ChangePoints(Cards card) {
            if (GuessTest(card)) {
                points += 100;
            }
            else {
                points -= 75;
            }
        }
        public int GetPoints() {
            return points;
        }
        public bool KeepPlaying() {
            Console.WriteLine("Do you wish to keep playing[Y/N]: ");
            retry = Console.ReadLine();
            if (retry.ToLower() == "y") {
                return true;
            }
            else {
                Console.WriteLine("Thank you for playing!:D");
                return false;
            }
        }
        public string GetRetry() {
            return retry;
        }
    }

    class Cards {
        Random rnd = new Random();
        int cardNumber = 0;

        int cardOld = 0;
        public void newCard() {
            cardOld = cardNumber;
            cardNumber = rnd.Next(1,13);
        }

        public void displayCard() {
            Console.WriteLine($"The card is: {cardNumber}");
        }

        public void DisplayNext() {
           Console.WriteLine($"The next card was: {cardNumber}"); 
        }
        public int getCardNumber() {
            return cardNumber;
        }
        public int getCardOld() {
            return cardOld;
        }
    }
    
    class Program {

        static void Main() {
            Player a = new Player();
            Cards c = new Cards();
            c.newCard();
            while (a.GetPoints() !=0 && a.GetRetry().ToLower() == "y") {
                c.displayCard();
                c.newCard();
                // Console.WriteLine($"Old Card: {c.getCardOld()}\nNew Card: {c.getCardNumber()}");
                a.Guess();
                c.DisplayNext();
                a.ChangePoints(c);
                Console.WriteLine(a.GetPoints());
                if (a.GetPoints() > 0) {
                    a.KeepPlaying();
                }
            }
            if (a.GetPoints() <=0) {
                Console.WriteLine("You are out of points, You Lost");
            }
        }
    }
}