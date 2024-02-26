using Discord.WebSocket;

namespace Werewolf.Bot.Commands;

public interface ISlashCommand
{
    public Task ExecuteAsync(SocketSlashCommand command);
}