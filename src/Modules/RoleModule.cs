using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Net;

namespace DiscordBot.Modules
{
    public class RoleModule : ModuleBase<SocketCommandContext>
    {
    
        [Command("year")]
        public async Task Year(string year = "")
        {
            if (year.Length == 0)
            {
                await ReplyAsync(
                    $"Sorry {Context.Message.Author.Mention}, you'll need to enter \"!year\" and a number from 1 to 7 corresponding to your standing (or 0 for Alumni)."
                );
                return;
                
            }
            var user = Context.User;
            var guild = Context.Guild;
            await YearAsync((user as IGuildUser), guild, year);
        }
        public Task Year()
           => ReplyAsync(
               $"Hi <@{Context.Message.Author.Id}>, let's assign you a year! What year are you in? \n(Type 0 for Alumni or a number from 1 to 7 corresponding to your standing)");

        [Command("program")]
        public async Task Program(string program = "")
        {
            if (program.Length == 0)
            {
                await ReplyAsync(
                    $"Sorry {Context.Message.Author.Mention}, you'll need to enter \"!program\" and the number corresponding to your program.\n" +
                    "You can choose from the following, simply type the correspond number: " +
                    "\n 1) Arts \n 2) Architecture \n 3) Biopsychology \n 4) Biotechnology \n 5) Computer Science \n 6) Engineering \n 7) Forestry \n 8) Integrated Sciences \n 9) Kinesiology \n 10) LFS \n 11) Music" +
                    "\n 12) Pharmacology \n 13) Pharmacy \n 14) Physics & Astronomy \n 15) Political Science \n 16) Sauder \n 16) Science \n 17) Statistics \n 18) VISA \n 19) My faculty/program isn't listed \n 20) I'm actually from Langara \n 21) I'm actually a UVIC/SFU Spy \n 22) I'm actually a high school student"
                );
                return;
                
            }
            var user = Context.User;
            var guild = Context.Guild;
            await ProgramAsync((user as IGuildUser), guild, program);
        }
        public Task Program()
           => ReplyAsync(
               $"Hi <@{Context.Message.Author.Id}>, let's assign you a Program! What year are you in? \n(Type 0 for Alumni or a number from 1 to 7 corresponding to your standing)");

        [Command("help")]
        public Task Help()
            => ReplyAsync(
                $"Howdy {Context.Message.Author.Mention}, currently only the !year, !program, !ams and !youtube commands are supported, bug Namtsua if you want another feature to be added.");

        [Command("youtube")]
        public Task Youtube()
            => ReplyAsync(
                //$"Hello, I am a bot called <@{Context.Message.Author.Id}> written in Discord.Net 1.0\n");
                $"Hey {Context.Message.Author.Mention}, check out my Youtube channel! https://www.youtube.com/channel/UC8KGT0uZ19f6XJPUwxlvzPQ");
    
        private async Task YearAsync(Discord.IGuildUser user, SocketGuild guild, string year)
        {
            int tag = int.Parse(year);
            string tagName = "Barista";
            switch(tag)
            {
                case 0: tagName = "Alumni"; break;
                case 1: tagName = "First Year"; break;
                case 2: tagName = "Second Year"; break;
                case 3: tagName = "Third Year"; break;
                case 4: tagName = "Fourth Year"; break;
                case 5: tagName = "Fifth Year"; break;
                case 6: tagName = "Sixth Year"; break;
                case 7: tagName = "Seventh Year"; break;
                default: break;
            }   
            string customMessage = findYearMessage(tag);
            await Reply(customMessage);
            var selectedRole = guild.Roles.FirstOrDefault(x => x.Name == tagName);
            await user.AddRoleAsync(selectedRole);
            return;
            
       }   
       private async Task ProgramAsync(Discord.IGuildUser user, SocketGuild guild, string program)
        {
            int tag = int.Parse(program);
            string tagName = "Barista";
            switch(tag)
            {
                case 1: tagName = "Arts"; break;
                case 2: tagName = "Architecture"; break;
                case 3: tagName = "Biopsychology"; break;
                case 4: tagName = "Biotechnology"; break;
                case 5: tagName = "Computer Science"; break;
                case 6: tagName = "Engineering"; break;
                case 7: tagName = "Forestry"; break;
                case 8: tagName = "Integrated Sciences"; break;
                case 9: tagName = "Kinesiology"; break;
                case 10: tagName = "LFS"; break;
                case 11: tagName = "Music"; break;
                case 12: tagName = "Pharmacology"; break;
                case 13: tagName = "Pharmacy"; break;
                case 14: tagName = "Physics & Astronomy"; break;
                case 15: tagName = "Political Science"; break;
                case 16: tagName = "Sauder"; break;
                case 17: tagName = "Science"; break;
                case 18: tagName = "Statistics"; break;
                case 19: tagName = "VISA"; break;
                case 20: tagName = "Langara Student"; break;
                case 21: tagName = "UVIC/SFU Spy"; break;
                case 22: tagName = "High School Student"; break;
                default: break;
            }   
            string customMessage = findProgramMessage(tag);
            await Reply(customMessage);
            var selectedRole = guild.Roles.FirstOrDefault(x => x.Name == tagName);
            await user.AddRoleAsync(selectedRole);
            return;
            
       }   

       private Task Reply(string message)
            => 
                ReplyAsync(message);

        private string findYearMessage(int year)
        {
            string customMessage = "";
            switch(year)
            {
                case 0: customMessage = "What are you doing here? Just kidding, anyone UBC-related is welcome."; break;
                case 1: customMessage = "Welcome to UBC! I hope you are enjoying your first year."; break;
                case 2: customMessage = "Thanks. How about them late registration dates, eh?"; break;
                case 3: customMessage = "Thanks. Congratulations on surviving your first two years!"; break;
                case 4: customMessage = "Thanks. I hope you're enjoying those sweet early registration dates."; break;
                case 5: customMessage = "Thanks. I hope your half decade at UBC has been great!"; break;
                case 6: customMessage = "Thanks. Going for the long haul, eh?"; break;
                case 7: customMessage = "Thanks. I see you can't get enough of UBC, but you can't stay forever!"; break;
                default: break;
            }
            return customMessage;
        }
         private string findProgramMessage(int program)
        {
            string customMessage = "";
            switch(program)
            {
                case 1: customMessage = "Arts, eh? Tired of writing essays yet?"; break;
                case 2: customMessage = "Architecture, eh? Planning on becoming the next Indiana Jones?"; break;
                case 3: customMessage = "Biopsychology, eh? That's oddly specific."; break;
                case 4: customMessage = "Biotechnology, eh? Enjoy your trips to BCIT."; break;
                case 5: customMessage = "Computer Science, eh? Remember to trust the natural recursion!"; break;
                case 6: customMessage = "Engineering, eh? We get it. You think your program is hard."; break;
                case 7: customMessage = "Forestry, eh? Stop dressing like you're about to go on a camping trip."; break;
                case 8: customMessage = "Integrated Sciences, eh? You already know what I'm going to say."; break;
                case 9: customMessage = "Kinesiology, eh? I'm down for some massages anytime."; break;
                case 10: customMessage = "LFS, eh? Is that actually a faculty?"; break;
                case 11: customMessage = "Music, eh? Are you the type to play Wonderwall at a house party?"; break;
                case 12: customMessage = "Pharmacology, eh? Did you mean to pursue Pharmacy? Mistakes happen."; break;
                case 13: customMessage = "Pharmacy, eh? If you need anyone to test some hallucinogenics, let me know!"; break;
                case 14: customMessage = "Physics & Astronomy, eh? Have you gotten tired of Hennings yet?"; break;
                case 15: customMessage = "Political Science, eh? Is this just a stepping stone towards law school?"; break;
                case 16: customMessage = "Sauder, eh? Don't even talk to me about your startup proposal."; break;
                case 17: customMessage = "Science, eh? Sorry there's no pre-med option!"; break;
                case 18: customMessage = "Statistics, eh? Don't lie, you've probably taken more Computer Science courses than Statistics ones."; break;
                case 19: customMessage = "VISA, eh? Feel free to paint me whenever!"; break;
                case 20: customMessage = "Langara Student, eh? One of these days, you won't get off the 49 at Cambie."; break;
                case 21: customMessage = "UVIC/SFU Spy, eh? It takes guts to confess this, I'll let you live."; break;
                case 22: customMessage = "High School Student, eh? Feel free to ask questions, don't expect fantastic answers."; break;
                default: break;
            }
            return customMessage;
        }
    }
}