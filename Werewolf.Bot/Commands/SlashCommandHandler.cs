using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Werewolf.Bot.Commands;

public class SlashCommandHandler(IServiceProvider services) : ISlashCommandHandler
{
    public async Task HandleCommandAsync(SocketSlashCommand command)
    {
        await using var scope = services.CreateAsyncScope();
        ISlashCommand? slashCommand = command.CommandName switch
        {
            "ping" => scope.ServiceProvider.GetRequiredService<PingCommand>(),
            "start" => scope.ServiceProvider.GetRequiredService<StartCommand>(),
            // Add more command mappings here
            _ => null
        };

        if (slashCommand != null)
        {
            await slashCommand.ExecuteAsync(command);
        }
        else
        {
            await command.RespondAsync($"Unknown command {command.CommandName}", ephemeral: true);
        }
    }
}
