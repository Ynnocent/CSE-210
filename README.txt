bool win = false;

        do{
                Console.WriteLine("Guess a number from 1 through 13: ");
                string s = Console.ReadLine();

                int i = int.Parse(s);

                if (i > winNum) {
                    Console.WriteLine("The number is too high. Guess lower. ");
                }

                else if (i < winNum) {
                    Console.WriteLine("The number is too low, guess higher. ");

                } else if (i == winNum) {
                    Console.WriteLine("You guessed it");
                    win = true;
                }
        } while (win==false);