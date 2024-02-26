using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Werewolf.Bot;

public class SlashCommandHandler(IServiceProvider services)
{
    public async Task HandleCommandAsync(SocketSlashCommand command)
    {
        await using var scope = services.CreateAsyncScope();
        ISlashCommand? slashCommand = command.CommandName switch
        {
            "first-command" => scope.ServiceProvider.GetRequiredService<PingCommand>(),
            // Add more command mappings here
            _ => null
        };

        if (slashCommand != null)
        {
            await slashCommand.ExecuteAsync(command);
        }
        else
        {
            await command.RespondAsync($"Unknown command {command.CommandName}");
        }
    }
}
