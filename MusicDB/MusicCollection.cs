using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MusicCollectionManager
{
    public class MusicCollection
    {
        private List<Album> albums;

        public MusicCollection()
        {
            albums = new List<Album>();
        }

        public void AddAlbum(Album album)
        {
            albums.Add(album);
        }

        public List<string> GetAllAlbumTitles()
        {
            return albums.Select(a => a.Title).ToList();
        }

        public Album? GetAlbumById(int albumId)
        {
            return albums.FirstOrDefault(a => a.AlbumId == albumId);
        }

        public Track? GetTrackById(int albumId, int trackNumber)
        {
            var album = GetAlbumById(albumId);
            var tracks = album?.Tracks ?? Enumerable.Empty<Track>();
            return tracks.FirstOrDefault(t => t.TrackNumber == trackNumber);
        }

        public void SaveToFile(string filePath)
        {
            var json = JsonSerializer.Serialize(albums, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                albums = JsonSerializer.Deserialize<List<Album>>(json);
            }
            else
            {
                Console.WriteLine("Nie znaleziono pliku");
            }
        }
    }
}
