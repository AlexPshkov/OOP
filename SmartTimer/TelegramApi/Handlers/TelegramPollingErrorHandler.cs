using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramApi.Handlers;

public class TelegramPollingErrorHandler : ITelegramPollingErrorHandler
{

    public void Handle( ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken )
    {
        
    }
    
}