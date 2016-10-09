using System;
using System.Linq;
using Discord;
using Discord.Commands;
using Discord.Audio;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace Discordbot
{
    class DDbot
    {
        DiscordClient discord;
        CommandService commands;

        public DDbot()
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

            commands.CreateCommand("audio").Do(async (a) =>
            {
                Console.WriteLine("audio werkt!");
                try
                {
                    var voiceChannel = discord.FindServers("SQUAD").FirstOrDefault().VoiceChannels.ToArray(); // Finds the first VoiceChannel on the server 'Music Bot Server'

                    var _vClient = await discord.GetService<AudioService>() // We use GetService to find the AudioService that we installed earlier. In previous versions, this was equivelent to _client.Audio()
                            .Join(voiceChannel[1]); // 1 = team 1, 2 = team 3, 3 = team 2 en 0 = General
                    var channelCount = discord.GetService<AudioService>().Config.Channels; // Get the number of AudioChannels our AudioService has been configured to use.
                    var OutFormat = new WaveFormat(48000, 16, channelCount); // Create a new Output Format, using the spec that Discord will accept, and with the number of channels that our client supports.
                    using (var MP3Reader = new Mp3FileReader("/DD-Bot/Discordbot/sounds/johncena.mp3")) // Create a new Disposable MP3FileReader, to read audio from the filePath parameter
                    using (var resampler = new MediaFoundationResampler(MP3Reader, OutFormat)) // Create a Disposable Resampler, which will convert the read MP3 data to PCM, using our Output Format
                    {
                        resampler.ResamplerQuality = 60; // Set the quality of the resampler to 60, the highest quality
                        int blockSize = OutFormat.AverageBytesPerSecond / 50; // Establish the size of our AudioBuffer
                        byte[] buffer = new byte[blockSize];
                        int byteCount;

                        while ((byteCount = resampler.Read(buffer, 0, blockSize)) > 0) // Read audio into our buffer, and keep a loop open while data is present
                        {
                            if (byteCount < blockSize)
                            {
                                // Incomplete Frame
                                for (int i = byteCount; i < blockSize; i++)
                                    buffer[i] = 0;
                            }
                            _vClient.Send(buffer, 0, blockSize); // Send the buffer to Discord
                        }
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });

            TextCommands textcommands = new TextCommands(discord);
            ImageCommands imagecommands = new ImageCommands(discord);

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjM0MDIwNDcwNzQyMTg4MDMz.Ctuw1Q.NXGEgLfYfjX41ZPwQipSLCg73IU", TokenType.Bot);
            });           
        }
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

