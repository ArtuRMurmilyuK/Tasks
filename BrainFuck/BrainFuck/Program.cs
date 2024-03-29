﻿using BrainFuck;
using BrainFuck.Keyboards;
using BrainFuck.Models;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

var botClient = new TelegramBotClient("5679188326:AAGkojAKf1zWyozMZ9_RWkbncMI3y1vOnh8");
var users = new List<Users>();
using var cts = new CancellationTokenSource();

Console.WriteLine("Запущен бот " + botClient.GetMeAsync().Result.FirstName);

//reading from db
using (ApplicationContext db = new ApplicationContext())
{
    users = db.Users.ToList();
}

var cancellationToken = cts.Token;

var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { }, //receive all update types
};
botClient.StartReceiving(
    HandleUpdateAsync,
    HandleErrorAsync,
    receiverOptions,
    cancellationToken
);

Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    Console.WriteLine(JsonConvert.SerializeObject(exception));
    return Task.CompletedTask;
}

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    ControlUser userController = new ControlUser();
    var message = update.Message;
    var callBack = update.CallbackQuery;

    if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
    {
        switch (message.Text.ToLower())
        {
            case "/start":
                if(message.Text.ToLower() != null)
                {
                    if(message.Chat.Username == null)
                    {
                        userController.CreateUserWithOutUsername(message.Chat.FirstName, message.Chat.Id);
                    }
                    else
                    {
                        userController.CreateUser(message.Chat.FirstName, message.Chat.Username, message.Chat.Id);
                    }
                   
                }
                await botClient.SendTextMessageAsync(message.Chat.Id, "Вітаємо у Brain Fuck😁🥴",
                    replyMarkup: Keyboards.GetButtonsCommands(), cancellationToken: cancellationToken);
                return;
            case "информация":
                await botClient.SendTextMessageAsync(message.Chat, "Достану напоминать!)",
                    cancellationToken: cancellationToken);
                return;
            case "дать задание!":
                //TODO: a method that accepts a user and a task
                await botClient.SendTextMessageAsync(message.Chat, "В разработке",
                    cancellationToken: cancellationToken);
                return;
            case "список задач":
                //TODO: reading from the database of tasks that are assigned to you
                await botClient.SendTextMessageAsync(message.Chat, "В разработке",
                    cancellationToken: cancellationToken);
                return;
            case "донат":
                //TODO: Card
                await botClient.SendTextMessageAsync(message.Chat, "В разработке",
                    cancellationToken: cancellationToken);
                return;
            default:
                await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть команду",
                    replyMarkup: Keyboards.GetButtonsCommands(), cancellationToken: cancellationToken);
                return;
        }
    }
}
Console.ReadLine();