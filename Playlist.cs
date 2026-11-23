namespace MusicPlaylist;

public class Playlist
{
    // Encapsulation: songs are stored in a private list.
    private readonly List<Song> _songs = new();

    // Returns the number of songs.
    public int Count => _songs.Count;

    // Computes the total duration of all songs.
    public int TotalDuration =>
        _songs.Sum(song => song.DurationSeconds);

    // Indexer: allows accessing songs using playlist[index].
    public Song this[int index] => _songs[index];

    // Adds a song after validating its information.
    public void Add(Song song)
    {
        if (song is null)
            throw new ArgumentNullException(nameof(song));

        if (string.IsNullOrWhiteSpace(song.Title) ||
            string.IsNullOrWhiteSpace(song.Artist))
            throw new ArgumentException("Title and artist are required.");

        if (song.DurationSeconds <= 0)
            throw new ArgumentException("Duration must be positive.");

        _songs.Add(song);
    }
}
