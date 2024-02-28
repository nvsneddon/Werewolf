using Discord.WebSocket;

namespace Werewolf.Bot.Commands;

public interface ISlashCommandHandler
{
    public Task HandleCommandAsync(SocketSlashCommand command);
}