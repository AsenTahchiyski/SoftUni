namespace HomeworkMain
{
	using System;
	using System.Xml;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Threading;
	using System.Xml.Linq;
	using System.Xml.XPath;

	class Program
	{
		static void Main()
		{
			var doc = new XmlDocument();
			doc.Load("../../../catalog.xml");
			XmlNode root = doc.DocumentElement;

			// Problem 2.	DOM Parser: Extract Album Names
//			foreach (XmlNode artist in root.ChildNodes)
//			{
//				foreach (XmlNode album in artist.ChildNodes)
//				{
//					Console.WriteLine("Album Title: {0}", album.Attributes["title"].InnerText);
//				}
//			}

			// Problem 3.	DOM Parser: Extract All Artists Alphabetically.
			// Write a program that extracts all artists in alphabetical order from catalog.xml.
			// Use the DOM parser. Keep the artists in a SortedSet<string> to avoid duplicates and to
			// keep the artist in alphabetical order.
//			var allArtists = root.ChildNodes;
//			var result = new SortedSet<string>();
//			foreach (XmlNode artist in allArtists)
//			{
//				result.Add(artist.Attributes["name"].InnerText);
//			}
//
//			foreach (var artistName in result)
//			{
//				Console.WriteLine(artistName);
//			}

			// Problem 4.	DOM Parser: Extract Artists and Number of Albums. Write a program that extracts
			// all different artists, which are found in the catalog.xml. For each artist print the number
			// of albums in the catalogue. Use the DOM parser and a Dictionary<string, int> (use the artist
			// name as key and the number of albums as value in the dictionary).
//			var allArtists = root.ChildNodes;
//			var artistAlbums = new Dictionary<string, int>();
//			foreach (XmlNode artist in allArtists)
//			{
//				var artistName = artist.Attributes["name"].InnerText;
//				if (!artistAlbums.ContainsKey(artistName))
//				{
//					artistAlbums.Add(artistName, 0);
//				}
//				foreach (XmlNode album in artist.ChildNodes)
//				{
//					artistAlbums[artistName]++;
//				}
//			}
//
//			foreach (var entry in artistAlbums)
//			{
//				Console.WriteLine("{0} - {1} albums", entry.Key, entry.Value);
//			}

			// Problem 5.	XPath: Extract Artists and Number of Albums
			// Implement the previous using XPath.
//			var xmlDoc = XDocument.Load("../../../catalog.xml");
//			var albumsArtists = new Dictionary<string, int>();
//			foreach (var artist in xmlDoc.Descendants("artist"))
//			{
//				var artistName = artist.Attribute("name").Value;
//				if (!albumsArtists.ContainsKey(artistName))
//				{
//					albumsArtists.Add(artistName, 0);
//				}
//
//				foreach (var album in artist.Descendants("album"))
//				{
////					var albumName = album.Attribute("title").Value;
//					albumsArtists[artistName]++;
//				}
//			}
//
//			foreach (var artist in albumsArtists)
//			{
//				Console.WriteLine("{0} - {1} albums", artist.Key, artist.Value);
//			}

			// Problem 6.	DOM Parser: Delete Albums. Using the DOM parser write a
			// program to delete from catalog.xml all albums having price > 20.
			// Save the result in a new file cheap-albums-catalog.xml.
//			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
//			var xmlDoc = XDocument.Load("../../catalog.xml");
//			var cheapAlbums = new XDocument();
//			var albums = new XElement("music");
//			cheapAlbums.Add(albums);
//
//			foreach (var artist in xmlDoc.Descendants("artist"))
//			{
//				var currentArtist = new XElement("artist",
//					new XAttribute("name", artist.Attribute("name").Value));
//				foreach (var album in artist.Descendants("album"))
//				{
//					var price = album.Attribute("price");
//					if (price != null)
//					{
//						if (double.Parse(price.Value) < 20)
//						{
//							currentArtist.Add(album);
//						}
//					}
//				}
//
//				albums.Add(currentArtist);
//			}
//
//			cheapAlbums.Save(@"../../cheap-albums.xml");
//			Console.WriteLine("Done.");

			// Problem 7.	DOM Parser and XPath: Old Albums. Write a program, which extract
			// from the file catalog.xml the titles and prices for all albums, published 5 years
			// ago or earlier. Use XPath query.
//			var xmlDoc = XDocument.Load("../../catalog.xml");
//			var allAlbums = xmlDoc.XPathSelectElements("music/artist/album");
//			var targetDate = DateTime.Now.AddYears(-10);
//
//			foreach (var album in allAlbums)
//			{
//				var albumReleaseDate = DateTime.Parse(album.Attribute("published").Value);
//				if (albumReleaseDate <= targetDate)
//				{
//					Console.WriteLine("Album: {0} released in {1:dd/MM/yyyy} (Price: ${2})",
//						album.Attribute("title").Value,
//						DateTime.Parse(album.Attribute("published").Value),
//						album.Attribute("price").Value);
//				}
//			}

			// Problem 8.	LINQ to XML: Old Albums. Write a program, which extract from the file
			// catalog.xml the titles and prices for all albums, published 5 years ago or earlier.
			// Use XDocument and LINQ to XML query.
//			var xmlDoc = XDocument.Load("../../catalog.xml");
//			var targetDate = DateTime.Now.AddYears(-10);
//			var oldAlbums = xmlDoc.Descendants("album")
//				.Where(b => DateTime.Parse(b.Attribute("published").Value) < targetDate)
//				.Select(b => new
//				{
//					Title = b.Attribute("title").Value,
//					Price = b.Attribute("price").Value
//				});
//
//			foreach (var album in oldAlbums)
//			{
//				Console.WriteLine("Album Title: {0} (${1})", album.Title, album.Price);
//			}

			// Problem 9.	* XmlWriter: Directory Contents as XML. Write a program to traverse given
			// directory and write to a XML file its contents together with all subdirectories and files.
			// Use tags <file> and <dir> with attributes. For the generation of the XML document use the
			// class XmlWriter.
			var dirToScan = new DirectoryInfo("../../../");
			var outputDoc = new XDocument();
			var dirStructure = TraverseDir(dirToScan);
			Console.WriteLine(dirStructure);
			dirStructure.Save("../../../dir-structure.xml");
		}

		private static XElement TraverseDir(DirectoryInfo currentDir)
		{
			var result = new XElement("dir", new XAttribute("name", currentDir.Name));
			foreach (var file in currentDir.GetFiles())
			{
				result.Add(new XElement("file", new XAttribute("name", file.Name)));
			}

			foreach (var directory in currentDir.GetDirectories())
			{
				var dirElement = new XElement("dir", new XAttribute("name", directory.Name));
				foreach (var file in directory.GetFiles())
				{
					dirElement.Add(new XElement("file", new XAttribute("name", file.Name)));
				}

				result.Add(TraverseDir(directory));
			}

			return result;
		}
	}
}