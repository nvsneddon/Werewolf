using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Werewolf.Bot;

public class SlashCommandHandler
{
    private readonly IServiceProvider _services;

    public SlashCommandHandler(IServiceProvider services)
    {
        _services = services;
    }

    public async Task HandleCommandAsync(SocketSlashCommand command)
    {
        ISlashCommand? slashCommand = command.CommandName switch
        {
            "first-command" => _services.GetRequiredService<PingCommand>(),
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
