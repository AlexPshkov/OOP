using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramApi.Handlers;

public interface ITelegramUpdateHandler
{
    /// <summary>
    /// Handle telegram update event
    /// </summary>
    void Handle( ITelegramBotClient botClient, Update update, CancellationToken cancellationToken );
}