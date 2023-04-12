using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var botClient = new TelegramBotClient("Token");

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

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Message.Type == Telegram.Bot.Types.Enums.MessageType.Document)
    {
        // получаем информацию о файле
        var file = await botClient.GetFileAsync(update.Message.Document.FileId);

        // сохраняем файл в определенную папку
        string filePath = Path.Combine("C:\\Users\\Documents\\", update.Message.Document.FileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await botClient.DownloadFileAsync(file.FilePath, fileStream);
        }

        // отвечаем пользователю
        await botClient.SendTextMessageAsync(update.Message.Chat.Id, $"File {update.Message.Document.FileName} has been saved");
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