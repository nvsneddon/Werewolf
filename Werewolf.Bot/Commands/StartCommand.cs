using Discord;
using Discord.WebSocket;
using Werewolf.Core.Interfaces;
using Werewolf.Core.Models.DataTransferObjects;

namespace Werewolf.Bot.Commands;

public class StartCommand(IGameService gameService, DiscordSocketClient client) : ISlashCommand
{
    public async Task ExecuteAsync(SocketSlashCommand command)
    {
        IGuild? guild = client.GetGuild(command.GuildId ?? 0L);
        if (guild == null)
        {
            await command.RespondAsync("Guild not found", ephemeral: true);
            return;
        }

        var users = await guild.GetUsersAsync();
        var playingRole = guild.Roles.FirstOrDefault(x => x.Name == "Playing");
        var playingUsers =
            from user in users
            where user.RoleIds.Contains(playingRole.Id)
            select new PlayerDto
            {
                Id = user.Id
            };
        var players = playingUsers.ToList();
        // Use defer async to acknowledge the command and then delay for two seconds and then change the message to success
        await command.DeferAsync(ephemeral: true);
        await Task.Delay(TimeSpan.FromSeconds(5));
        await gameService.StartGameAsync(players);
        await command.ModifyOriginalResponseAsync(x =>
            x.Content = $"Game started with players {String.Join(',', players.Select(x => x.Id))}");

        // await command.RespondAsync($"Game started with players {String.Join(',', players.Select(x => x.Id))}", ephemeral: true);
    }
}