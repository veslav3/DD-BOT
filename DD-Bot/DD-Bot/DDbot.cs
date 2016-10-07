using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DD_Bot
{
    class DDbot
    {
        DiscordClient discord;
        CommandService commands;

        public DDbot()
        {
            discord = new DiscordClient(clientLogger =>
            {
                clientLogger.LogLevel = LogSeverity.Info;
                clientLogger.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();
            RegisterImageCommand();

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjM0MDIwNDcwNzQyMTg4MDMz.Ctl8GA.IwmjhBOdLGhN1MjqKFiMAxI0Hhg", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private void RegisterImageCommand()
        {
            commands.CreateCommand("fu")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("images/middlefinger.jpg");
                });
        }
    }
}
