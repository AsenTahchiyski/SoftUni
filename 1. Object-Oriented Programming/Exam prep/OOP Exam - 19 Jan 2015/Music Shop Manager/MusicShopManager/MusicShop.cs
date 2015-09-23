using System.Linq;

namespace MusicShop
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using MusicShopManager.Interfaces;

    public class MusicShop : IMusicShop
    {
        private string name;
        private List<IArticle> articles; 

        protected internal MusicShop(string name)
        {
            this.Name = name;
            this.articles = new List<IArticle>();
        }
        
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterRequired, "name"));
                }
                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get { return this.articles; }
        }

        public void AddArticle(IArticle article)
        {
            this.articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("===== {0} =====", this.Name));
            if (this.Articles.Count == 0)
            {
                output.AppendLine("The shop is empty. Come back soon.");
                return output.ToString();
            }

            IList<IArticle> microphones = this.Articles
                .Where(a => a is IMicrophone)
                .OrderBy(a => a.Make)
                .ThenBy(a => a.Model)
                .ToList();
            if (microphones.Count > 0)
            {
                output.AppendLine("----- Microphones -----");
                foreach (var microphone in microphones)
                {
                    output.AppendLine(microphone.ToString());
                }
            }

            IList<IArticle> drums = this.Articles
                .Where(a => a is IDrums)
                .OrderBy(a => a.Make)
                .ThenBy(a => a.Model)
                .ToList();
            if (drums.Count > 0)
            {
                output.AppendLine("----- Drums -----");
                foreach (var drum in drums)
                {
                    output.AppendLine(drum.ToString());
                }
            }

            IList<IArticle> electricGuitars = this.Articles
                .Where(a => a is IElectricGuitar)
                .OrderBy(a => a.Make)
                .ThenBy(a => a.Model)
                .ToList();
            if (electricGuitars.Count > 0)
            {
                output.AppendLine("----- Electric guitars -----");
                foreach (var electricGuitar in electricGuitars)
                {
                    output.AppendLine(electricGuitar.ToString());
                }
            }
            
            IList<IArticle> acousticGuitars = this.Articles
                .Where(a => a is IAcousticGuitar)
                .OrderBy(a => a.Make)
                .ThenBy(a => a.Model)
                .ToList();
            if (acousticGuitars.Count > 0)
            {
                output.AppendLine("----- Acoustic guitars -----");
                foreach (var acousticGuitar in acousticGuitars)
                {
                    output.AppendLine(acousticGuitar.ToString());
                }
            }
            
            IList<IArticle> bassGuitars = this.Articles
                .Where(a => a is IBassGuitar)
                .OrderBy(a => a.Make)
                .ThenBy(a => a.Model)
                .ToList();
            if (bassGuitars.Count > 0)
            {
                output.AppendLine("----- Bass guitars -----");
                foreach (var bassGuitar in bassGuitars)
                {
                    output.AppendLine(bassGuitar.ToString());
                }
            }
            
            return output.ToString().TrimEnd();
        }
    }
}
