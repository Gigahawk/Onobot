using System.Threading.Tasks;
using Discord.Commands;
using System;
using System.IO;
using System.Linq;
using System.Collections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.WebSocket;
using Discord.Net;

namespace DiscordBot.Modules
{
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        [Command("nuke")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Nuke(int messageCount)
        {
            var messageList = await Context.Channel.GetMessagesAsync(messageCount+1).Flatten();
            await Context.Channel.DeleteMessagesAsync(messageList);
        }

        [Command("purge")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Purge(IGuildUser target, int amount)
        {
            var messageList = await Context.Channel.GetMessagesAsync(100).Flatten();
            var targetMessages = messageList.Where(x => x.Author == target).ToList();
            await Context.Channel.DeleteMessagesAsync(targetMessages);
        }

        [Command("kick")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task Kick(IGuildUser target)
        {
            await ReplyAsync("Bye bye <@" + target.Id +"> :wave:");
            await target.KickAsync();
        }

        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task Ban(IGuildUser target)
        {
            await ReplyAsync("Sayonara <@" + target.Id +"> :wave:");
            await Context.Guild.AddBanAsync(target);
        }
    }
}