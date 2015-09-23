namespace ReaperInvasion.UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public sealed class AssetLoader
    {
        private static AssetLoader instance;
        private readonly Dictionary<AssetType, ImageSource> images;

        private AssetLoader()
        {
            images = new Dictionary<AssetType, ImageSource>();
        }

        public static AssetLoader Instance
        {
            get { return instance ?? (instance = new AssetLoader()); }
        }

        public Image GetImage(AssetType type)
        {
            return new Image()
            {
                Source =  this.LoadImage(type) 
            };
        }

        private ImageSource LoadImage(AssetType type)
        {
            if (images.ContainsKey(type))
            {
                return images[type];
            }
            
            string path = string.Empty;

            switch (type)
            {
                case AssetType.Reaper:
                    path = AssetPaths.ReaperImage;
                    break;
                default: 
                    throw new ArgumentException("Unsupported asset type.");
            }

            var src = new Uri(path, UriKind.Relative);
            var bitmap = BitmapFrame.Create(src);

            images.Add(type, bitmap);
            return bitmap;
        }
    }
}
