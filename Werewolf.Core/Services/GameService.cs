using Werewolf.Core.Interfaces;

namespace Werewolf.Core.Services;

public class GameService : IGameService
{
    public Task StartGameAsync()
    {
        return Task.CompletedTask;
    }
}