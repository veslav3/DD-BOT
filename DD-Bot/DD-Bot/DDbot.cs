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

        public DDbot()
        {
            discord = new DiscordClient(clientLogger =>
            {
                clientLogger.LogLevel = LogSeverity.Info;
                clientLogger.LogHandler = Log;
            });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjM0MDIwNDcwNzQyMTg4MDMz.Ctl8GA.IwmjhBOdLGhN1MjqKFiMAxI0Hhg");
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
