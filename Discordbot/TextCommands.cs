using System;
using Discord.Commands;
using Discord;

namespace Discordbot
{
    class TextCommands
    {
        private CommandService commands;

        public TextCommands(DiscordClient discord)
        {
            commands = discord.GetService<CommandService>();
            textCommand("hoi", "doei");
            textCommand("ayy", "lmao");
            textCommand("audio", "doet het niet :(");
            textCommand("league?", "nee");
            TTSCommand("tts", "Houd je bek kutkind!");
            TTSCommand("doo d", "doo d doo d doo d doo d doo d doo d doo d doo d doo d doo d doo d doo d doo d doo d doo d doo d doo d doo d doo d ");
        }

        private void textCommand(String input, String output)
        {
            commands.CreateCommand(input).Do(async (e) =>
            {
                await e.Channel.SendMessage(output);
            });
        }

        private void TTSCommand(String input, String output)
        {
            commands.CreateCommand(input).Do(async (e) =>
            {
                await e.Channel.SendTTSMessage(output);
            });
        }
    }
}
