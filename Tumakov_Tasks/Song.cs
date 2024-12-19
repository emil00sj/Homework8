namespace Tumakov_Tasks
{
    public class Song
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Song Previous { get; set; }
        public Song()
        {
            Name = "axwer";
            Author = "axwer";
            Previous = null;
        }
        public Song(string name, string author, Song previous = null)
        {
            Name = name;
            Author = author;
            Previous = previous;
        }
        public string GetTitle()
        {
            return $"{Name} автор: {Author}";
        }
        public override string ToString()
        {
            return GetTitle();
        }
        public override bool Equals(object obj)
        {
            return obj is Song otherSong && Name == otherSong.Name && Author == otherSong.Author;
        }
    }
}
