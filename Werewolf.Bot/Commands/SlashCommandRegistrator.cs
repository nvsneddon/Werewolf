using Discord;
using Discord.WebSocket;

namespace Werewolf.Bot.Commands;

public class SlashCommandRegistrator(DiscordSocketClient client) : ISlashCommandRegistrator
{
    private readonly ApplicationCommandProperties[] _applicationCommandProperties =
    [
        new SlashCommandBuilder()
            .WithName("ping")
            .WithDescription("Replies with pong!")
            .Build(),
        new SlashCommandBuilder()
            .WithName("start")
            .WithDescription("Starts a game of Werewolf")
            .Build(),
        new SlashCommandBuilder()
            .WithName("test")
            .WithDescription("Test command")
            .Build()
    ];

    public async Task RegisterSlashCommandsAsync()
    {
        using var guild = client.GetGuild(681696629224505376);
        await guild.BulkOverwriteApplicationCommandAsync(_applicationCommandProperties);
    }
}