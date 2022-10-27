using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace BrainFuck.Keyboards
{
    public class Keyboards
    {
        public static IReplyMarkup GetButtonsCommands()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] {"Дать задание!", "Информация"},
            })
            {
                ResizeKeyboard = true
            };
            return replyKeyboardMarkup;
        }
    }
}
