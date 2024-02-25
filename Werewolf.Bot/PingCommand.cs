using Discord.WebSocket;

namespace Werewolf.Bot;

public class PingCommand : ISlashCommand
{
    public async Task ExecuteAsync(SocketSlashCommand command)
    {
        await command.RespondAsync("Pong!");
    }
}