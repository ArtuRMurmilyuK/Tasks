using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace Pavlov_Bot
{
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5325291515:AAERyAXGZoQRi5FngozkQgigx-BlCSiPT1Y");
        private static int i = 0;
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
                if (i < 0)
                {
                    i = 0;
                }
                if (i < sneakers.Count && i >= 0)
                {
                    switch (callBack.Data)
                    {
                        case "інформація":
                            await botClient.SendTextMessageAsync(messageCall.Chat.Id, $"{sneakers[i].Name} \n{sneakers[i].Price} \n{sneakers[i].Season}");
                            await botClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id); // отсылаем пустое, чтобы убрать "частики" на кнопке
                            return;
                        case "наступне":
                            if (i < sneakers.Count - 1)
                            {
                                i++;
                                await botClient.SendPhotoAsync(messageCall.Chat.Id, $"{sneakers[i].Img}", replyMarkup: Keyboard.Keyboards.GetInlineButton());
                                await botClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id); // отсылаем пустое, чтобы убрать "частики" на кнопке
                                return;
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(messageCall.Chat.Id, "Це був останій товар.", replyMarkup: Keyboard.Keyboards.GetButtons());
                                await botClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);
                                return;
                            }
                    }
                }
                else
                {
                    await botClient.SendTextMessageAsync(messageCall.Chat.Id, "Це був останій товар.", replyMarkup: Keyboard.Keyboards.GetButtons());
                    await botClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);
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
                        await botClient.SendTextMessageAsync(message.Chat, "Вибирай", replyMarkup: Keyboard.Keyboards.GetButtonsSneakersNike(),
                            cancellationToken: cancellationToken);
                        return;
                    case "adidas":
                        await botClient.SendTextMessageAsync(message.Chat, "Вибирай", replyMarkup: Keyboard.Keyboards.GetButtonsSneakersAdidas(),
                            cancellationToken: cancellationToken);
                        return;
                    case "force":
                        sneakers = sneakers.Where(x => x.Name == "Force").ToList();
                        await botClient.SendPhotoAsync(message.Chat, $"{sneakers[0].Img}", replyMarkup: Keyboard.Keyboards.GetInlineButton(),
                            cancellationToken: cancellationToken);
                        return;
                    case "dunk":
                        sneakers = sneakers.Where(x => x.Name == "Dunk").ToList();
                        await botClient.SendPhotoAsync(message.Chat, $"{sneakers[0].Img}", replyMarkup: Keyboard.Keyboards.GetInlineButton(),
                            cancellationToken: cancellationToken);
                        return;
                    case "iniki":
                        sneakers = sneakers.Where(x => x.Name == "Iniki").ToList();
                        await botClient.SendPhotoAsync(message.Chat, $"{sneakers[0].Img}", replyMarkup: Keyboard.Keyboards.GetInlineButton(),
                            cancellationToken: cancellationToken);
                        return;
                    case "yeezy 350":
                        sneakers = sneakers.Where(x => x.Name == "Yeezy 350").ToList();
                        await botClient.SendPhotoAsync(message.Chat, $"{sneakers[0].Img}", replyMarkup: Keyboard.Keyboards.GetInlineButton(),
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