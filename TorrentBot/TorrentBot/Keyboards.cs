using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TorrentBot
{
    internal class Keyboards
    {
        public static IReplyMarkup MainMenuKeyboard()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
            new KeyboardButton[] {"Info", "Send File"},
        })
            {
                ResizeKeyboard = true,
                
            };
            return replyKeyboardMarkup;
        }
    }
}