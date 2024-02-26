using Discord.WebSocket;
using Werewolf.Bot.Commands;

namespace Werewolf.Bot;

public class PingCommand : ISlashCommand
{
    public async Task ExecuteAsync(SocketSlashCommand command)
    {
        await command.RespondAsync("Pong!");
    }
}