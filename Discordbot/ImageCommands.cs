using System;
using Discord;
using Discord.Commands;

namespace Discordbot
{
    class ImageCommands
    {
        private CommandService commands;

        public ImageCommands(DiscordClient discord)
        {
            this.commands = discord.GetService<CommandService>();
            imageCommand("fu", "images/middlefinger.jpg");
            imageCommand("rarepepe", "images/rarepepe.gif");
            imageCommand("rarepeppe", "images/rarepeppe.jpg");
            imageCommand("jemoeder", "images/zeekoe.jpg");
            imageCommand("teemo", "images/teemo.jpg");
            imageCommand("eenhoorn", "images/eenhoorn.jpg");
        }

        public void imageCommand(String input, String file)
        {
            commands.CreateCommand(input).Do(async (e) =>
            {
                await e.Channel.SendFile(file);
            });
        }
    }
}