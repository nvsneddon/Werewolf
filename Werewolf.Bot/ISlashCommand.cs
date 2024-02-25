using Discord.WebSocket;

namespace Werewolf.Bot;

public interface ISlashCommand
{
    public Task ExecuteAsync(SocketSlashCommand command);
}