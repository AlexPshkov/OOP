using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramApi.Handlers;

public interface ITelegramPollingErrorHandler
{
    /// <summary>
    /// Handle telegram polling error
    /// </summary>
    void Handle( ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken );
}