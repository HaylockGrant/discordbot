using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;
using DSharpPlus.VoiceNext.Codec;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
namespace SpaceCore
{
    class Program
    {
        static DiscordClient discord;
        public static VoiceNextClient voice;
        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[]    args)
        {
            DiscordUser namedUser = null;
            int userIteration = 0;
            Random rnd = new Random();
            Stream imgyus = new MemoryStream(Properties.Resources._68964a1);
            DiscordChannel currentvoicechannel = null;
            Console.WriteLine("Starting server...");
            discord = new DiscordClient(new DiscordConfiguration
            {

                Token = "Secret Token",
                TokenType = TokenType.Bot,
            }
            );
            voice = discord.UseVoiceNext();
            Console.WriteLine("Initilizing Client");
            discord.Ready += async e =>
            {
                Console.WriteLine("Server Ready!");
                await discord.UpdateStatusAsync(new DiscordGame("with your heart"));
            };
            voice.Client.MessageCreated += async e =>
            {
                if (e.Message.Content.StartsWith("-"))
                {
                    String messagesent = e.Message.Content.TrimStart('-');
                    String commandsent;
                    if (messagesent.Contains(' '))
                    {
                        commandsent = messagesent.Remove(messagesent.IndexOf(' ')).Trim().ToLower();
                    }
                    else
                    {
                        commandsent = messagesent.Trim().ToLower();
                    }
                    Console.WriteLine();
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Command Information:");
                    Console.WriteLine(" Sender = " + e.Author.Username);
                    Console.WriteLine(" Message = " + e.Message.Content);
                    Console.WriteLine(" Command sent = " + commandsent);
                    switch (commandsent)
                    {
                        case "compliment":
                            Console.WriteLine(" Name = Compliment");
                            switch (e.Author.Username)
                            {
                                case "SpaceCadetKitty":
                                    await e.Message.RespondAsync("<@" + e.Author.Id + "> You're the bestest person ever!");
                                    break;
                                default:
                                    await e.Message.RespondAsync("<@" + e.Author.Id + "> nice to meet you!");
                                    break;
                            }
                            namedUser = e.Author;
                            userIteration = 3;
                            break;
                        case "ping":
                            Console.WriteLine(" Name = ping");
                            await e.Message.RespondAsync($"Pong!: My ping is {discord.Ping}ms");
                            break;
                        case "join":
                            Console.WriteLine(" Name = join");
                            //TODO implement later
                            break;
                        case "yus":
                            Console.WriteLine(" Name = yus");
                            await e.Message.RespondWithFileAsync(imgyus,"yus.jpg");
                            break;
                        case "help":
                            Console.WriteLine(" Name = help");
                            await e.Message.RespondAsync("```css\n" +
                                "#The-Space-Core-Bot-Commands-are\n" +
                                "[-compliment] The Space Core Bot will pay you a compliment!\n" +
                                "[-ping] The Space Core Bot will tell you its ping\n" +
                                "[-yus] yus\n" +
                                "[-join] New experimental feature that will play bad songs and memes!\n" +
                                "[-help] The Space Core Bot will list off all the commands for you```");
                            break;
                        //TODO add elaberate help command
                        //TODO add hug command
                        //TODO add knock knock command
                        default:
                            Console.WriteLine("Exception = invalid command");
                            break;
                    }
                    Console.WriteLine("------------------------");
                }
            };
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Discord_SocketOpened1()
        {
            throw new NotImplementedException();
        }

        private static Task Discord_SocketOpened()
        {
            throw new NotImplementedException();
        }
    }
}