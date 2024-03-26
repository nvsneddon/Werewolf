using Discord.WebSocket;

namespace Werewolf.Bot.Commands;

public class StartCommand : ISlashCommand
{
    public Task ExecuteAsync(SocketSlashCommand command)
    {
        return command.RespondAsync("Game started!", ephemeral: true);
    }
}