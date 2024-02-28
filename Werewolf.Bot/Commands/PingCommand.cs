using Discord.WebSocket;

namespace Werewolf.Bot.Commands;

public class PingCommand : ISlashCommand
{
    public async Task ExecuteAsync(SocketSlashCommand command)
    {
        await command.RespondAsync("Pong!", ephemeral: true);
    }
}