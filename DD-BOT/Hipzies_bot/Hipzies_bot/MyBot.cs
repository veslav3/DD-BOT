using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Audio;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace Hipzies_bot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingAudio(x =>
            {
                x.Mode = AudioMode.Outgoing;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            textCommands();
            imageCommands();
           // soundCommands();
           //Dit is dus het geluid dat niet werkt

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjM0MjczOTg4ODIwNDY3NzEz.CtprSQ.0SWcjtRInmdCnnoN49S5j4OCGuc", TokenType.Bot);
            });

        }
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private void textCommands()
        {
            commands.CreateCommand("hoi")
                    .Do(async (e) =>
                    {
                       await e.Channel.SendMessage("doei");
                    });
            commands.CreateCommand("ayy")
                    .Do(async (e) =>
                    {
                       await e.Channel.SendMessage("lmao");
                    });
            commands.CreateCommand("audio")
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("doet het niet :(");
                    });
            commands.CreateCommand("league?")
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("nee");
                    });
            commands.CreateCommand("tts")
                    .Do(async (e) =>
                    {
                        await e.Channel.SendTTSMessage("Hallo ik ben tekst naar spraak");
                    });

        }

private void imageCommands()
        {
            commands.CreateCommand("rarepepe")
                   .Do(async (e) =>
                   {
                       await e.Channel.SendFile("images/rarepepe.gif");
                   });
            commands.CreateCommand("rarepeppe")
                    .Do(async (e) =>
       {
           await e.Channel.SendFile("images/rarepeppe.jpg");
       });
            commands.CreateCommand("jemoeder")
.Do(async (e) =>
{
await e.Channel.SendFile("images/zeekoe.jpg");
});
            commands.CreateCommand("fu")
   .Do(async (e) =>
   {
       await e.Channel.SendFile("images/middlefinger.jpg");
   });
            commands.CreateCommand("teemo")
.Do(async (e) =>
{
await e.Channel.SendFile("images/teemo.jpg");
});
            commands.CreateCommand("eenhoorn")
.Do(async (e) =>
{
await e.Channel.SendFile("images/eenhoorn.jpg");
});
        }

        private void soundCommands()
        {
                 commands.CreateCommand("join")
                .Do(async (e) =>
                {
                    var voiceChannel = discord.FindServers("iscordtesting").FirstOrDefault().VoiceChannels.FirstOrDefault(); // Finds the first VoiceChannel on the server
                    var _vClient = await discord.GetService<AudioService>()
                       .Join(voiceChannel);
                });

/*
            commands.CreateCommand("johncena")
                   .Do(async (e) =>
                   {
                       await e.Channel.SendFile("sounds/johncena.mp3");
                   });
            commands.CreateCommand("airhorn")
       .Do(async (e) =>
       {
           await e.Channel.SendFile("sounds/AIRHORN.wav");
       });*/
        }
    }
    }

