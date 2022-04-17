using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace Pavlov_Bot.Keyboard
{
    public class Keyboards
    {
        public static IReplyMarkup GetButtonsSneakersName()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] {"Nike", "Adidas"},
            })
            {
                ResizeKeyboard = true
            };
            return replyKeyboardMarkup;
        }

        public static IReplyMarkup GetButtons()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] {"Переглянути товари", "Інформація про нас"},
            })
            {
                ResizeKeyboard = true
            };
            return replyKeyboardMarkup;
        }

        public static IReplyMarkup GetInlineButton()
        {
            InlineKeyboardMarkup inlineKeyboard = new(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Попереднє","1"),
                    InlineKeyboardButton.WithCallbackData("Наступне","0"),
                },
            });
            return inlineKeyboard;
        }
    }
}