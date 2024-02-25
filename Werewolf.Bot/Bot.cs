using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Werewolf.Bot;

public class Bot(DiscordSocketClient client, SlashCommandHandler slashCommandHandler)
{

    public async Task RunAsync()
    {
        // Event subscriptions, command registration, etc.
        client.Log += Log;
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
