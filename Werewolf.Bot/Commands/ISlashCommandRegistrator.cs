using System.Net.Sockets;
using Discord.WebSocket;

namespace Werewolf.Bot.Commands;

public interface ISlashCommandRegistrator
{
    public Task RegisterSlashCommandsAsync();
}