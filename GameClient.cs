
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GameStore.Client.Models;

namespace GameStore.Client;

public static class GameClient
{
private static readonly List<Game> games = new()
    {
        new Game()
        {
            Id = 1,
            Name = "Maximum Carnage",
            Genre = "Co-op Melee",
            Price = 7.99M,
            ReleaseDate = new DateTime(1993, 08, 04)

            
        },

        new Game()
        {
                Id = 2,
                Name = "Mortal Kombat 1",
                Genre = "Fighting",
                Price = 49.99M,
                ReleaseDate = new DateTime(2023, 05, 18)
        },

        new Game()
        {
            Id = 3,
            Name = "Madden 2024",
            Genre = "Sports",
            Price = 49.99M,
            ReleaseDate = new DateTime(2024, 01 ,25)
        }
    };

    public static Game[] GetGames()
    {
        return games.ToArray();
    }

    public static void AddGame(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public static Game GetGame(int id)
    {
        return games.Find(game => game.Id == id) ?? throw new Exception("Could not find game");
    }

    public static void UpdateGame(Game updatedGame)
    {
        Game existingGame = GetGame(updatedGame.Id);
        existingGame.Name = updatedGame.Name;
        existingGame.Genre = updatedGame.Genre;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public static void DeleteGame(int id)
    {
        Game game = GetGame(id);
        games.Remove(game);
    }
}