using MusicPlaylist;

Playlist playlist = new();
bool running = true;

Console.WriteLine("=== MUSIC PLAYLIST MANAGER ===");

while (running)
{
    Console.WriteLine("\n===== MAIN MENU =====");
    Console.WriteLine("1. Add Song");
    Console.WriteLine("2. List Songs");
    Console.WriteLine("3. Select Song by Index");
    Console.WriteLine("4. Show Total Duration");
    Console.WriteLine("5. Demonstrate Record Equality and With");
    Console.WriteLine("6. Quit");
    Console.Write("Choose an option (1-6): ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Song title: ");
            string title = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Artist: ");
            string artist = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Duration in seconds: ");

            if (!int.TryParse(Console.ReadLine(), out int duration))
            {
                Console.WriteLine("Invalid duration.");
                break;
            }

            try
            {
                Song song = new(title, artist, duration);
                playlist.Add(song);
                Console.WriteLine("Song added successfully!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            break;

        case "2":
            Console.WriteLine("\n=== YOUR PLAYLIST ===");

            if (playlist.Count == 0)
            {
                Console.WriteLine("Playlist is empty.");
                break;
            }

            for (int i = 0; i < playlist.Count; i++)
            {
                Song song = playlist[i];

                Console.WriteLine(
                    $"{i + 1}. {song.Title} - {song.Artist} " +
                    $"({song.DurationSeconds} seconds)");
            }
            break;

        case "3":
            if (playlist.Count == 0)
            {
                Console.WriteLine("Playlist is empty.");
                break;
            }

            Console.Write($"Select song number (1-{playlist.Count}): ");

            if (int.TryParse(Console.ReadLine(), out int number)
                && number >= 1
                && number <= playlist.Count)
            {
                Song selected = playlist[number - 1];

                Console.WriteLine(
                    $"Selected: {selected.Title} by {selected.Artist}");
            }
            else
            {
                Console.WriteLine("Invalid song number.");
            }
            break;

        case "4":
            int total = playlist.TotalDuration;

            Console.WriteLine(
                $"Total Duration: {total / 60} min {total % 60} sec");
            break;

        case "5":
            if (playlist.Count == 0)
            {
                Console.WriteLine("Add a song first.");
                break;
            }

            // Two different record instances with identical values.
            Song original = playlist[0];

            Song identical = new(
                original.Title,
                original.Artist,
                original.DurationSeconds);

            Console.WriteLine("\n=== RECORD VALUE EQUALITY ===");
            Console.WriteLine($"Original == Identical: {original == identical}");

            // Create a copy with one modified property.
            Song modified = original with
            {
                Title = original.Title + " (Remix)"
            };

            Console.WriteLine("\n=== WITH EXPRESSION ===");
            Console.WriteLine($"Original: {original.Title}");
            Console.WriteLine($"Modified: {modified.Title}");
            Console.WriteLine($"Original == Modified: {original == modified}");
            break;

        case "6":
            running = false;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option. Choose 1-6.");
            break;
    }
}

