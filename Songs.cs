
namespace MusicPlaylist;

// Represents a song using init-only properties.
// Records provide value equality automatically.
public record Song(
    string Title,
    string Artist,
    int DurationSeconds
);
