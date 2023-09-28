public class main
{
    static void Main()
    {
        var filetext = File.ReadAllLines("videogames.csv");
        Console.Write(filetext);

        var games = new List<VideoGame>();

        foreach (string line in filetext)
        {
            // Split the line into parts and create a VideoGame object
            string[] parts = line.Split(',');
            if (parts.Length >= 4)
            {
                var game = new VideoGame
                {
                    Title = parts[0],
                    Genre = parts[3],
                    Platform = parts[1],
                    Publisher = parts[4]
                };
                games.Add(game);
            }
        }

        games.Sort();
        

/* STACK  ---------------------------------------------------------------------------------------------------------------------------- */

        // Create a stack to store all the game information
        Stack<VideoGame> gameStack = new Stack<VideoGame>();

        foreach (var game in games)
        {
            // Push each game onto the stack
            gameStack.Push(game);
        }

        // Pop and print game information from the stack
        while (gameStack.Count > 0)
        {
            var game = gameStack.Pop();
            Console.WriteLine($"Title: {game.Title}, Genre: {game.Genre}, Platform: {game.Platform}, Publisher: {game.Publisher}");
        }

        //Displaying single output in a stack with LINQ
        var genreToDisplay = "Action";
        var gameWithGenre = gameStack.FirstOrDefault(game => game.Genre == genreToDisplay);

        if (gameWithGenre != null)
        {
            Console.WriteLine($"Game with Genre '{genreToDisplay}':");
            Console.WriteLine($"Title: {gameWithGenre.Title}, Genre: {gameWithGenre.Genre}, Platform: {gameWithGenre.Platform}, Publisher: {gameWithGenre.Publisher}");
        }
        else
        {
            Console.WriteLine($"No game found with Genre '{genreToDisplay}' in the stack.");
        }




/* QUEUE ------------------------------------------------------------------------------------------------------------------------*/
       
        // Create a Queue to store all the game information
        Queue<VideoGame> gameQueue = new Queue<VideoGame>();

        foreach (var game in games)
        {
            // Enqueue each game to the queue
            gameQueue.Enqueue(game);
        }

        // Dequeue and print game information from the queue
        while (gameQueue.Count > 0)
        {
            var game = gameQueue.Dequeue();
            Console.WriteLine($"Title: {game.Title}, Genre: {game.Genre}, Platform: {game.Platform}, Publisher: {game.Publisher}");
        }

        //Displaying single output in a queue with LINQ
        var requestedGame = "Fortnite";
        var matchingGames = games.Where(game => game.Title == requestedGame).ToList();

        if (matchingGames.Count > 0)
        {
            Console.WriteLine($"Player requested: {requestedGame}");
            foreach (var game in matchingGames)
            {
                Console.WriteLine($"Title: {game.Title}, Genre: {game.Genre}, Platform: {game.Platform}, Publisher: {game.Publisher}");
            }
        }
        else
        {
            Console.WriteLine($"Game not found: {requestedGame}");
        }



/* DICTIONARY ---------------------------------------------------------------------------------------------------------------------*/

        // Create a dictionary to store game information
        //this dictionary shows the title, publisher, and then all the available platforms for that game, sorted in order by title
        Dictionary<string, VideoGameInfo> gameDictionary = new Dictionary<string, VideoGameInfo>();
        foreach (var game in games)
        {
            // Check if the game title already exists in the dictionary
            if (gameDictionary.ContainsKey(game.Title))
            {
                // If it exists, add the platform to the list of platforms
                gameDictionary[game.Title].Platforms.Add(game.Platform);
            }
            else
            {
                // If it doesn't exist, create a new entry in the dictionary
                gameDictionary[game.Title] = new VideoGameInfo
                {
                    Publisher = game.Publisher,
                    Platforms = new List<string> { game.Platform }
                };
            }
        }
        // Print the game information from the dictionary
        foreach (var kvp in gameDictionary)
        {
            Console.WriteLine($"Title: {kvp.Key}, Publisher: {kvp.Value.Publisher}, Platforms: {string.Join(", ", kvp.Value.Platforms)}");
        }


        //Displaying single output in a Dictionary with LINQ
        var titleToSearch = "Minecraft";
        var gameInfo = gameDictionary.FirstOrDefault(kvp => kvp.Key == titleToSearch);

        if (!string.IsNullOrEmpty(gameInfo.Key))
        {
            Console.WriteLine($"Game with Title '{titleToSearch}':");
            Console.WriteLine($"Title: {gameInfo.Key}, Publisher: {gameInfo.Value.Publisher}, Platforms: {string.Join(", ", gameInfo.Value.Platforms)}");
        }
        else
        {
            Console.WriteLine($"No game found with Title '{titleToSearch}' in the dictionary.");
        }

 
/* EXAMPLES: QUEUE-------------------------------------------------------------------------------------------------------------------*/
        
       // Simulate player requests (you can replace these with actual player requests)
        Queue<string> playerGameRequests = new Queue<string>(); // Renamed to playerGameRequests
        playerGameRequests.Enqueue("The Legend of Zelda");
        playerGameRequests.Enqueue("Minecraft");
        playerGameRequests.Enqueue("Fortnite");

        // Process and display game requests in the order they were made
        while (playerGameRequests.Count > 0)
        {
            var playerRequestedGame = playerGameRequests.Dequeue(); // Use a different variable name
            var matchingGamesForRequest = games.Where(game => game.Title == playerRequestedGame).ToList(); // Use a different variable name

            if (matchingGamesForRequest.Count > 0)
            {
                Console.WriteLine($"Player requested: {playerRequestedGame}");
                foreach (var game in matchingGamesForRequest)
                {
                    Console.WriteLine($"Title: {game.Title}, Genre: {game.Genre}, Platform: {game.Platform}, Publisher: {game.Publisher}");
                }
            }
            else
            {
                Console.WriteLine($"Game not found: {playerRequestedGame}");
            }
        }



/* EXAMPLES: STACK -----------------------------------------------------------------------------------------------------------------*/

        // Create a Stack to represent the gameplay session history
        Stack<string> gameplaySessionHistory = new Stack<string>();

        // Simulate gameplay sessions (you can replace these with actual gameplay sessions)
        gameplaySessionHistory.Push("Session 1: The Legend of Zelda");
        gameplaySessionHistory.Push("Session 2: Minecraft");
        gameplaySessionHistory.Push("Session 3: Fortnite");

        // Simulate the player wanting to revisit the previous gameplay session
        if (gameplaySessionHistory.Count > 1)
        {
            // Pop the current session to go back to the previous session
            gameplaySessionHistory.Pop();

            // Get the previous session and display it
            string previousSession = gameplaySessionHistory.Peek();
            Console.WriteLine($"Revisiting previous session: {previousSession}");
        }
        else
        {
            Console.WriteLine("Cannot go back further; no previous gameplay sessions.");
        }



/* EXAMPLES: DICTIONARY--------------------------------------------------------------------------------------------------------------*/

        // Create a Dictionary to represent the game library catalog
        Dictionary<int, VideoGame> gameLibraryCatalog = new Dictionary<int, VideoGame>();

        // Populate the game library catalog with game information
        int catalogNumber = 1;
        foreach (var game in games)
        {
            gameLibraryCatalog[catalogNumber++] = game;
        }

        // Ask the user to enter a catalog number to search for a game
        Console.Write("Enter a catalog number to search for a game: ");
        if (int.TryParse(Console.ReadLine(), out int catalogNumberToSearch))
        {
            if (gameLibraryCatalog.ContainsKey(catalogNumberToSearch))
            {
                var game = gameLibraryCatalog[catalogNumberToSearch];
                Console.WriteLine($"Game Catalog Number: {catalogNumberToSearch}");
                Console.WriteLine($"Title: {game.Title}, Genre: {game.Genre}, Platform: {game.Platform}, Publisher: {game.Publisher}");
            }
            else
            {
                Console.WriteLine($"Game with catalog number {catalogNumberToSearch} not found in the library catalog.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid catalog number.");
        }


    }
}
