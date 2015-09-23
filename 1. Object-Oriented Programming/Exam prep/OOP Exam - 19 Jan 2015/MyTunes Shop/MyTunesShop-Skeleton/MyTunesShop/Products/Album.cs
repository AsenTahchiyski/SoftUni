using System.Text;

namespace MyTunesShop.Products
{
    using System.Collections.Generic;

    public class Album : Media, IAlbum
    {
        private List<ISong> songs;
        
        public Album(string title, decimal price, IPerformer performer, string genre, int year)
            : base(title, price)
        {
            this.Performer = performer;
            this.songs = new List<ISong>();
            this.Genre = genre;
            this.Year = year;
        }

        public IList<ISong> Songs
        {
            get { return this.songs; }
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("{0} ({1}) by {2}", this.Title, this.Year, this.Performer.Name));
            output.AppendLine(string.Format("Genre: {0}, Price:${1:F2}", this.Genre, this.Price));
            output.AppendLine(string.Format("Supplies: {0}, Sold: {1}"));
            output.AppendLine(string.Format("{0}", this.Songs.Count > 0 ? "Songs:" : "No Songs"));
            if (this.Songs.Count > 0)
            {
                foreach (var song in this.Songs)
                {
                    output.AppendLine(string.Format("{0} ({1})", song.Title, song.Duration));
                }
            }
            return output.ToString();
        }
    }
}
