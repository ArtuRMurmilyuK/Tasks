using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TorrentBot;
using static TorrentBot.Keyboards;

var botClient = new TelegramBotClient("6030647103:AAE1tsj6JipdgFxjYzeODdf9bw4k9dwSVLo");

using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

//if (fileName.EndsWith(".torrent"))
{
    Console.WriteLine("File has .torrent extension");
}
async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    switch (update.Message.Text)
    {
        case "/start":
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, $"🛠⚙ Welcome to QbitTorren Bot 🛠⚙");
            await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "How can I help you?",
                replyMarkup: Keyboards.MainMenuKeyboard(),
                cancellationToken: cancellationToken);
            break;
        case "Info":
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, $"With my help you can download torrent files directly to your device");
            break;
        case "Send File":
            await botClient.SendTextMessageAsync(
                 chatId: update.Message.Chat.Id,
                 text: "Upload your file here",
                 replyMarkup: new ReplyKeyboardRemove(),
                 cancellationToken: cancellationToken);
            
            break;
    }

    if(update.Message.Type == Telegram.Bot.Types.Enums.MessageType.Document)
    {
        if (update.Message.Document.FileName.EndsWith(".torrent"))
        {
            // получаем информацию о файле
            var file = await botClient.GetFileAsync(update.Message.Document.FileId);

            // сохраняем файл в определенную папку
            string filePath = Path.Combine("C:\\Users\\Murmi\\Documents\\", update.Message.Document.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await botClient.DownloadFileAsync(file.FilePath, fileStream);
            }

            // отвечаем пользователю
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, $"File {update.Message.Document.FileName} has been saved");
        }
        else
        {
            // отвечаем о неверном формате файла
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, $"File has .torrent extension");
        }
    }

}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}