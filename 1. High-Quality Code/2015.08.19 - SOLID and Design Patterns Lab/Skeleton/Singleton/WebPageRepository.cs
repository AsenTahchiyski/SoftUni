namespace WebScraper
{
    using System.Collections.Generic;

    public class WebPageRepository
    {
        private readonly Queue<string> addresses;
        private static WebPageRepository _instance;
        private static readonly object SyncLock = new object();

        private WebPageRepository()
        {
            this.addresses = new Queue<string>();
            this.Seed();
        }

        public static WebPageRepository Instance()
        {
            if (_instance == null)
            {
                lock (SyncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new WebPageRepository();
                    }
                }
            }

            return _instance;
        }

        public bool IsEmpty
        {
            get
            {
                return this.addresses.Count == 0;
            }
        }

        public void Add(string address)
        {
            this.addresses.Enqueue(address);
        }

        public string Remove()
        {
            return this.addresses.Dequeue();
        }

        private void Seed()
        {
            this.addresses.Enqueue("https://softuni.bg/");
            this.addresses.Enqueue("http://stackoverflow.com/");
            this.addresses.Enqueue("https://www.youtube.com/");
            this.addresses.Enqueue("https://www.google.bg/");
        }
    }
}
