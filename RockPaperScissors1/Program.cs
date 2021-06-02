using System;

namespace RockPaperScissors1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            int continueGameInt;
            bool succesfulConversion = false;
            bool successConversion = false;
            int playerChoiceInt;
            Console.WriteLine("\n\tWelcome to Rock-Paper-Scissors!\n \nPlease enter your name.");
            string playerName = Console.ReadLine();

            //loop to continue playing
            do{
                int i=0;

                //for loop used to play 3 rounds
                for(i=0;i<3;i++){
                    Console.WriteLine($"\n{playerName} please make a choice!");

                    do{
                        Console.WriteLine("1, Rock\n2, Paper\n3, Scissors");
                        string playerChoice = Console.ReadLine();

                        //create a int variable to catch the converted choice.
                        
                        succesfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);
                        //check if the user inputed a number but the number is out of bounds.
                        if(playerChoiceInt > 3 || playerChoiceInt < 1){
                            Console.WriteLine($"{playerName} you inputted {playerChoiceInt}. That is not a valid choice.");
                        }
                        else if(!succesfulConversion){
                            Console.WriteLine($"{playerName} you inputted {playerChoice}. That is not a valid choice.");
                        } 

                    } while (!succesfulConversion || (playerChoiceInt < 1 || playerChoiceInt > 3));
                    
                    //you can omit the {} if the body of the statment is only 1 line
                    // if(succesfulConversion == true)Console.WriteLine($"the conversion returned {succesfulConversion} and the player chose {playerChoiceInt}");
                    // else Console.WriteLine($"the conversion returned {succesfulConversion} and the player chose {playerChoiceInt}");

                    //get a random number generator object
                    Random rand = new Random();
                    //get a random number 1, 2, or 3
                    int computerChoice = rand.Next(1, Enum.GetNames(typeof(RpsChoice)).Length+1);

                    //print the choices
                    Console.WriteLine($"\n{playerName} chose {(RpsChoice)playerChoiceInt}!");
                    Console.WriteLine($"The computer chose {(RpsChoice)computerChoice}!");

                    if(playerChoiceInt == 1 && computerChoice == 2)Console.WriteLine("Computer Wins!");
                    else if(playerChoiceInt == 2 && computerChoice == 3)Console.WriteLine("Computer Wins!");
                    else if(playerChoiceInt == 3 && computerChoice == 1)Console.WriteLine("Computer Wins!");
                    else if(playerChoiceInt == computerChoice)Console.WriteLine("Tie Game!");
                    else Console.WriteLine($"{playerName} Wins!!");
                }

                //you can get typeDef the number to the equicalent RpsChoice Enum.
                // Console.WriteLine((RpsChoice)playerChoiceInt);
                // Console.WriteLine((RpsChoice)computerChoice);

                /*

                1. implement a loop to play again if the player chooses to
                2. get the players name to print out the winners
                3. implement the code to play 3 rounds

                */

                Console.WriteLine("\nEnter\n1 to Play Again\n0 to Exit");
                string continueGame = Console.ReadLine();
                successConversion = Int32.TryParse(continueGame, out continueGameInt);

                //check if the user inputed a number but the number is out of bounds. loops until within bounds
                while(!successConversion || (continueGameInt > 1 || continueGameInt < 0)){
                    Console.Write($"\n{playerName} you entered an incorrect value.\nPlease try again.\n");
                    continueGame = Console.ReadLine();
                    successConversion = Int32.TryParse(continueGame, out continueGameInt);
                }

            } while (continueGameInt == 1);
            Console.WriteLine("\nThank you for playing!\n ");
        }
    }
}
