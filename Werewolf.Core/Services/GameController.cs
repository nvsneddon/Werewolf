using Werewolf.Core.Interfaces;

namespace Werewolf.Core.Services;

public class GameController : IGameController
{
    public Task StartGameAsync()
    {
        return Task.CompletedTask;
    }
}