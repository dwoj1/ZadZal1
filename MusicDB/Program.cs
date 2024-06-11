using MusicDB;
using System;

namespace MusicCollectionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicCollection musicCollection = new MusicCollection();
            string filePath = "db.json";

            if (File.Exists(filePath))
            {
                musicCollection.LoadFromFile(filePath);
            }

            while (true)
            {
                Console.WriteLine("1. Dodaj płytę");
                Console.WriteLine("2. Wyświetl wszystkie płyty");
                Console.WriteLine("3. Wyświetl szczegółowe informacje o płycie");
                Console.WriteLine("4. Wyświetl szczegółowe informacje o utworze");
                Console.WriteLine("5. Zapisz bazę do pliku");
                Console.WriteLine("6. Wczytaj bazę z pliku");
                Console.WriteLine("0. Wyjście");
                Console.Write("Wybierz opcję: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAlbum(musicCollection);
                        break;
                    case "2":
                        DisplayAllAlbums(musicCollection);
                        break;
                    case "3":
                        DisplayAlbumDetails(musicCollection);
                        break;
                    case "4":
                        DisplayTrackDetails(musicCollection);
                        break;
                    case "5":
                        musicCollection.SaveToFile(filePath);
                        Console.WriteLine("Baza danych zapisana do pliku.");
                        break;
                    case "6":
                        musicCollection.LoadFromFile(filePath);
                        Console.WriteLine("Baza danych wczytana z pliku.");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja, spróbuj ponownie.");
                        break;
                }
            }
        }

        static void AddAlbum(MusicCollection musicCollection)
        {
            Console.Write("Podaj tytuł płyty: ");
            string title = Console.ReadLine();
            Console.Write("Podaj typ płyty (CD/DVD): ");
            string type = Console.ReadLine();
            Console.Write("Podaj czas trwania płyty (HH:MM:SS): ");
            TimeSpan duration = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Podaj numer płyty (ID): ");
            int albumId = int.Parse(Console.ReadLine());

            Album album = new Album(title, type, duration, new List<Track>(), new List<Author>(), albumId);

            Console.Write("Podaj liczbę utworów: ");
            int trackCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= trackCount; i++)
            {
                Console.WriteLine($"Utwór {i}:");
                Console.Write("Tytuł utworu: ");
                string trackTitle = Console.ReadLine();
                Console.Write("Czas trwania utworu (HH:MM:SS): ");
                TimeSpan trackDuration = TimeSpan.Parse(Console.ReadLine());
                Console.Write("Kompozytor utworu: ");
                string composer = Console.ReadLine();

                Track track = new Track(trackTitle, trackDuration, new List<Author>(), new Author(composer), i);

                Console.Write("Podaj liczbę wykonawców utworu: ");
                int performerCount = int.Parse(Console.ReadLine());

                for (int j = 1; j <= performerCount; j++)
                {
                    Console.Write($"Wykonawca {j}: ");
                    string performer = Console.ReadLine();
                    track.Performers.Add(new Author(performer));
                }

                album.Tracks.Add(track);
            }

            Console.Write("Podaj liczbę remixów: ");
            int remixCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= remixCount; i++)
            {
                Console.WriteLine($"Remix {i}:");
                Console.Write("Tytuł remixu: ");
                string remixTitle = Console.ReadLine();
                Console.Write("Tytuł oryginalnego utworu: ");
                string trackTitle = Console.ReadLine();
                Console.Write("Czas trwania remixu (HH:MM:SS): ");
                TimeSpan trackDuration = TimeSpan.Parse(Console.ReadLine());
                Console.Write("Autor remixu: ");
                string remixer = Console.ReadLine();
                Console.Write("Kompozytor oryginalnego utworu: ");
                string composer = Console.ReadLine();

                Remix remix = new Remix(trackTitle, trackDuration, new List<Author>(), new Author(composer), i, new Author(remixer), remixTitle);

                Console.Write("Podaj liczbę wykonawców oryginalnego utworu: ");
                int performerCount = int.Parse(Console.ReadLine());

                for (int j = 1; j <= performerCount; j++)
                {
                    Console.Write($"Wykonawca {j}: ");
                    string performer = Console.ReadLine();
                    remix.Performers.Add(new Author(performer));
                }

                album.Remixes.Add(remix);
            }

            musicCollection.AddAlbum(album);
            Console.WriteLine("Płyta dodana do bazy danych.");
        }

        static void DisplayAllAlbums(MusicCollection musicCollection)
        {
            var titles = musicCollection.GetAllAlbumTitles();
            if (titles.Count == 0)
            {
                Console.WriteLine("Brak płyt w bazie danych.");
                return;
            }

            Console.WriteLine("Płyty w bazie danych:");
            foreach (var title in titles)
            {
                Console.WriteLine($"- {title}");
            }
        }

        static void DisplayAlbumDetails(MusicCollection musicCollection)
        {
            Console.Write("Podaj numer płyty (ID): ");
            int albumId = int.Parse(Console.ReadLine());
            var album = musicCollection.GetAlbumById(albumId);

            if (!album.HasValue)
            {
                Console.WriteLine("Nie znaleziono płyty o podanym ID.");
                return;
            }

            if (album.Value.IsDefault())
            {
                Console.WriteLine("Nie znaleziono płyty o podanym ID.");
                return;
            }

            Console.WriteLine($"Tytuł płyty: {album?.Title}");
            Console.WriteLine($"Typ płyty: {album?.Type}");
            Console.WriteLine($"Czas trwania: {album?.Duration}");
            Console.WriteLine("Utwory:");
            foreach (var track in album?.Tracks)
            {
                Console.WriteLine($"{track.TrackNumber}. {track.Title}");
            }
            Console.WriteLine("Remixy:");
            foreach (var remix in album?.Remixes)
            {
                Console.WriteLine($"{remix.TrackNumber}. {remix.RemixTitle}");
            }
        }

        static void DisplayTrackDetails(MusicCollection musicCollection)
        {
            Console.Write("Podaj numer płyty (ID): ");
            int albumId = int.Parse(Console.ReadLine());
            Console.Write("Podaj numer utworu: ");
            int trackNumber = int.Parse(Console.ReadLine());

            var track = musicCollection.GetTrackById(albumId, trackNumber);

            if (track == null)
            {
                Console.WriteLine("Nie znaleziono utworu o podanym numerze.");
                return;
            }

            Console.WriteLine($"Tytuł utworu: {track?.Title}");
            Console.WriteLine($"Czas trwania: {track?.Duration}");
            Console.WriteLine($"Kompozytor: {track?.Composer.Value.Name}");
            Console.WriteLine("Wykonawcy:");
            foreach (var performer in track?.Performers)
            {
                Console.WriteLine($"- {performer.Name}");
            }
        }
    }
}