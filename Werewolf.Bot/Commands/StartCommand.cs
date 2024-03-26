using Discord;
using Discord.WebSocket;
using Werewolf.Core.Interfaces;

namespace Werewolf.Bot.Commands;

public class StartCommand(IGameService gameService) : ISlashCommand
{
    public async Task ExecuteAsync(SocketSlashCommand command)
    {
        // var players = command.
        // await gameService.StartGameAsync();
        await command.RespondAsync("Game started!", ephemeral: true);
    }
}