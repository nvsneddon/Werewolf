using Discord;
using Discord.WebSocket;
using Werewolf.Bot.Commands;

namespace Werewolf.Bot;

public class Bot(
    DiscordSocketClient client,
    ISlashCommandHandler slashCommandHandler,
    ISlashCommandRegistrator slashCommandRegistrator)
{
    public async Task RunAsync()
    {
        // Event subscriptions, command registration, etc.
        client.Log += Log;
        client.Ready += () =>
        {
            slashCommandRegistrator.RegisterSlashCommandsAsync();
            return Task.CompletedTask;
        };
        client.SlashCommandExecuted += slashCommandHandler.HandleCommandAsync;

        var token = Environment.GetEnvironmentVariable("TOKEN") ?? throw new Exception("Token not found");

        await client.LoginAsync(TokenType.Bot, token);
        await client.StartAsync();
        await Task.Delay(-1);
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}