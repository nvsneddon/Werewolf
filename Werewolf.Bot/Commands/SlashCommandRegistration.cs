using Discord;

namespace Werewolf.Bot.Commands;

public class SlashCommandRegistration(IDiscordClient client) : ISlashCommandRegistrator
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
        var guild = await client.GetGuildAsync(681696629224505376);
        await guild.BulkOverwriteApplicationCommandsAsync(_applicationCommandProperties);
    }
}