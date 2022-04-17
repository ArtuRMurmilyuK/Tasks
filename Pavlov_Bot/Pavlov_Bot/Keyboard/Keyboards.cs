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

        public static IReplyMarkup GetButtonsSneakersNike()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] {"Force", "Dunk"},
                new KeyboardButton[] {"M2k", "Shadow"},
            })
            {
                ResizeKeyboard = true
            };
            return replyKeyboardMarkup;
        }

        public static IReplyMarkup GetButtonsSneakersAdidas()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] {"Ozelia", "Iniki"},
                new KeyboardButton[] {"Niteball", "Yeezy 350"},
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
                    InlineKeyboardButton.WithCallbackData("Інформація","інформація"),
                    InlineKeyboardButton.WithCallbackData("Наступне","наступне"),
                },
            });
            return inlineKeyboard;
        }
    }
}