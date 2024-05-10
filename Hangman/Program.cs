using System.Text;

namespace Hangman
{
    internal class Program
    {
        
        static List<string> guessedChars = new List<string>();
        static string[] words = new string[] {"Fotball", "Pizza",
            "Gitar", "Strand",
            "Sjokolade", "Romskip",
            "Svømming", "Kamera",
            "Ferie", "Vulkan",
            "Sjokoladekake", "Solbriller",
            "Gullfisk", "Piano",
            "Fotografi", "Papegøye",
            "Fotball", "Sjimpanse",
            "Skyskraper", "Regnbue",
            "Surfing", "Sushi",
            "Fotball", "Skilpadde",
            "Guitar", "Mars",
            "Festival", "Fjellklatring",
            "Fotografi", "Rakett",
            "Strand", "Måne",
            "Kaktus", "Bølge",
            "Basketball", "Slott",
            "Skateboard", "Unicorn",
            "Skole", "Jordbær",
            "Fotball", "Teleskop",
            "Svømming", "Kokosnøtt",
            "Kajakk", "Papegøye",
            "Festival", "Burger",
            "Volleyball", "Dinosaur",
            "Fotball", "Regnbue",
            "Bibliotek", "Saturn",
            "Skateboard", "Donut",
            "Sjokolade", "Måne",
            "Teater", "Papegøye"};

        static string gameWord = "";
        static char recentGuess = '@';
        static string hiddenWord = "";
        static int lives = 10;
        static bool correctAnswer = true;
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomTall = random.Next(0, words.Length);
            gameWord = words[randomTall].ToLower();

            for (int i = 0; i < gameWord.Length; i++)
            {
                hiddenWord += "_";
            }


            Console.WriteLine("Velkommen til Hangman!");
            ShowWord();
        }

        

        static void ShowWord()
        {
            

            while (hiddenWord != gameWord) {
                Console.WriteLine(drawHangman());
                Console.WriteLine($"Gjetta bokstaver:  {guessedLetters()}");
                Console.WriteLine(hiddenWord);
                Console.WriteLine("Skriv ein bokstav for å gjette");
                recentGuess = Convert.ToChar(Console.ReadLine());
                guessedChars.Add(Convert.ToString(recentGuess));
                correctAnswer = false;
                
            for (int i = 0; i < gameWord.Length; i++)
            {
                if (gameWord[i] == recentGuess)
                {
                    StringBuilder sb = new StringBuilder(hiddenWord);
                    sb[i] = recentGuess;
                    hiddenWord = sb.ToString();
                    correctAnswer = true;
                }
            }

            if (!correctAnswer)
            {
                lives -= 1;
            }

            Console.Clear();

            if (lives == 0)
            {
                
                Console.WriteLine($"Du tapte! Ordet var {gameWord}");
                System.Environment.Exit(0);
                }
            } Console.WriteLine("Graturerer, du fant ordet!");
        }

        static string drawHangman()
        {
            string drawnLives = "HP: ";

            for (int i = 0; i < lives; i++)
            {
                drawnLives += "X";
            }
            
            return drawnLives;
        }

        static string guessedLetters()
        {
            string guessedString = "";
            for (int i = 0; i < guessedChars.Count; i++)
            {
                guessedString += guessedChars[i];
            }
            return guessedString;
        }
    }
}
