using MyTunesShop.Products;

namespace MyTunesShop
{
    using System;
    using System.Linq;

    public class MyTunesEngineExtension : MyTunesEngine
    {
        protected override void ExecuteRateCommand(string[] commandWords)
        {
            // rate:song;<name>;<rating> 
            int rating;
            if (!int.TryParse(commandWords[3], out rating))
            {
                throw new ArgumentException("Invalid rating");
            }

            var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[2]) as ISong;
            if (song == null)
            {
                this.Printer.PrintLine("The song does not exist in the database.");
                return;
            }
            song.PlaceRating(rating);
            this.Printer.PrintLine("The rating has been added successfully.");
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            base.ExecuteInsertMediaCommand(commandWords);

            switch (commandWords[2])
            {
                case "album":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }
                    // insert:media;album;<title>;<price>;<performer_name>;<genre>;<year>.
                    var album = new Album(commandWords[3], decimal.Parse(commandWords[4]), performer, commandWords[6], int.Parse(commandWords[7]));
                    this.InsertAlbum(album, performer);
                    break;
                default:
                    break;
            }
        }

        private void InsertAlbum(IAlbum album, IPerformer performer)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, performer.Name);
        }

        private void InsertSongToAlbum(ISong song, IAlbum album)
        {
            if (this.media.FirstOrDefault(a => a is IAlbum && a == album) == null)
            {
                throw new ArgumentException("The album does not exist in the database.");
            }
            if (this.media.FirstOrDefault(s => s is ISong && s == song) == null)
            {
                throw new ArgumentException("The song does not exist in the database.");
            }

            album.AddSong(song);
            this.Printer.PrintLine(string.Format("The song {0} has been added to the album {1}.", song.Title, album.Title));
        }

        protected void ExecuteReportRatingCommand(string[] commandWords)
        {
            var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[3]) as ISong;
            if (song == null)
            {
                this.Printer.PrintLine("The song does not exist in the database.");
                return;
            }

            this.Printer.PrintLine(this.GetSongReport(song));
        }


    }
}
