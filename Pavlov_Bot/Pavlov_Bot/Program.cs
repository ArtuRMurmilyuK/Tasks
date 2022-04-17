using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pavlov_Bot.Keyboard;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Pavlov_Bot
{
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5325291515:AAERyAXGZoQRi5FngozkQgigx-BlCSiPT1Y");

        static void Main()
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, //receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );

            Console.ReadLine();
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(JsonConvert.SerializeObject(exception));
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            List<Sneaker> sneakers = new List<Sneaker>();

            using (SneakersShopDBContext db = new SneakersShopDBContext())
            {
                sneakers = db.Sneakers.ToList();
            }

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

            var message = update.Message;
            var callBack = update.CallbackQuery;
           

            if (callBack != null)
            {
                var messageCall = update.CallbackQuery.Message;
                switch (callBack.Data)
                {
                    case "1":
                        await botClient.SendTextMessageAsync(messageCall.Chat.Id, "тест1", replyToMessageId: messageCall.MessageId);
                        await botClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id); // отсылаем пустое, чтобы убрать "частики" на кнопке
                        return;
                    case "0":
                        await botClient.SendTextMessageAsync(messageCall.Chat.Id, "тест22222", replyToMessageId: messageCall.MessageId);
                        await botClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id); // отсылаем пустое, чтобы убрать "частики" на кнопке
                        return;
                }
            }
                

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                switch (message.Text.ToLower())
                {
                    case "/start":
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Вітаємо у нашому магазині Pavlov Drop",
                            replyMarkup: Keyboard.Keyboards.GetButtons(), cancellationToken: cancellationToken);
                        return;
                    case "переглянути товари":
                        await botClient.SendTextMessageAsync(message.Chat.Id, message.Text,
                            replyMarkup: Keyboard.Keyboards.GetButtonsSneakersName(),
                            cancellationToken: cancellationToken);
                        return;
                    case "інформація про нас":
                        await botClient.SendTextMessageAsync(message.Chat, "Ми неповторні, бо Ми з України",
                            cancellationToken: cancellationToken);
                        return;
                    case "nike":
                        await botClient.SendPhotoAsync(message.Chat, photo: $"{sneakers[0].Img}",
                            cancellationToken: cancellationToken);
                        await botClient.SendTextMessageAsync(message.Chat, $"Назва: {sneakers[0].Name} ",
                            cancellationToken: cancellationToken);
                        await botClient.SendTextMessageAsync(message.Chat, $"Ціна: {sneakers[0].Price}",
                            replyMarkup: Keyboard.Keyboards.GetInlineButton(), cancellationToken: cancellationToken);
                        await botClient.SendTextMessageAsync(message.Chat.Id,
                            "A message with an inline keyboard markup",
                            replyMarkup: Keyboard.Keyboards.GetInlineButton(), cancellationToken: cancellationToken);
                        return;
                    case "1":
                        await botClient.SendTextMessageAsync(message.Chat, "Nike1111",
                            cancellationToken: cancellationToken);
                        return;
                    default:
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть команду",
                            replyMarkup: Keyboard.Keyboards.GetButtons(), cancellationToken: cancellationToken);
                        return;
                }
            }
        }
    }
}