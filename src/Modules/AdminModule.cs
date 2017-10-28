using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot.Modules
{
    public class AdminModule : ModuleBase<SocketCommandContext>
    {
        [Command("nuke")]
        public Task Ams()
            => ReplyAsync(
                "http://streamable.com/gbqjv");

        [Command("purge")]
        public Task Help()
            => ReplyAsync(
                "Howdy <@{Context.Message.Author.Id}>, currently only the !year, !program, !ams and !youtube commands are supported, bug Namtsua if you want another feature to be added.");

        [Command("kick")]
        public Task Youtube()
            => ReplyAsync(
                //$"Hello, I am a bot called <@{Context.Message.Author.Id}> written in Discord.Net 1.0\n");
                $"Hey <@{Context.Message.Author.Id}>, check out my Youtube channel! https://www.youtube.com/channel/UC8KGT0uZ19f6XJPUwxlvzPQ");
                
      //  [Command("ban")]
        // public Task Help()
        //     => ReplyAsync(
        //         "Howdy <@{Context.Message.Author.Id}>, currently only the !year, !program, !ams and !youtube commands are supported, bug Namtsua if you want another feature to be added.");
    }
}