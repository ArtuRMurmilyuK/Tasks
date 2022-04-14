using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Pavlov_Bot
{
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5325291515:AAERyAXGZoQRi5FngozkQgigx-BlCSiPT1Y");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Вітаємо у нашому магазині Pavlov Drop");
                    await botClient.SendTextMessageAsync(message.Chat.Id, message.Text, replyMarkup: GetButtons());
                    return;
                }

                switch (message.Text.ToLower())
                {
                    case "переглянути товари":
                        await botClient.SendTextMessageAsync(message.Chat.Id, message.Text, replyMarkup: GetButtonsSneakersName());
                        break;
                    case "інформація про нас":
                        await botClient.SendTextMessageAsync(message.Chat, "Ми неповторні, бо Ми з України");
                        break;
                    case "nike":
                        await botClient.SendTextMessageAsync(message.Chat, "Nike");
                        break;
                    default:
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть команду", replyMarkup: GetButtons());
                        break;
                }
            }
        }

        private static IReplyMarkup GetButtons()
        {
            var Keyboard = new List<List<KeyboardButton>>
            {
                new List<KeyboardButton>
                {
                    new KeyboardButton("Переглянути товари"),
                    new KeyboardButton("Інформація про нас")
                }
                //new List<KeyboardButton>
                //{
                //    new KeyboardButton("💭"),
                //    new KeyboardButton("Інформація про нас")
                //}
            };
           return new ReplyKeyboardMarkup(Keyboard);
        }
        private static IReplyMarkup GetButtonsSneakersName()
        {
            var Keyboard = new List<List<KeyboardButton>>
            {
                new List<KeyboardButton>
                {
                    new KeyboardButton("Nike"),
                    new KeyboardButton("Adidas")
                }
                //new List<KeyboardButton>
                //{
                //    new KeyboardButton("💭"),
                //    new KeyboardButton("Інформація про нас")
                //}
            };
            return new ReplyKeyboardMarkup(Keyboard);
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}
