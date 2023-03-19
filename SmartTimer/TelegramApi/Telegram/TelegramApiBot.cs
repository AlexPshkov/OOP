using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using TelegramApi.Configuration;
using TelegramApi.Handlers;

namespace TelegramApi.Telegram;

public class TelegramApiBot
{
    private readonly ITelegramBotConfiguration _configuration;
    private readonly ITelegramUpdateHandler _telegramUpdateHandler;
    private readonly ITelegramPollingErrorHandler _telegramPollingErrorHandler;
    private readonly TelegramBotClient _telegram;

    public TelegramApiBot( ITelegramBotConfiguration configuration, ITelegramUpdateHandler telegramUpdateHandler, ITelegramPollingErrorHandler telegramPollingErrorHandler ) 
    {
        _configuration = configuration;
        _telegramUpdateHandler = telegramUpdateHandler;
        _telegramPollingErrorHandler = telegramPollingErrorHandler;

        string token = _configuration.Token;

        if ( string.IsNullOrEmpty( token ) )
        {
            throw new ArgumentException( "Token can't be empty, please provide it" );
        } 
        
        _telegram = new TelegramBotClient( token );
        
        ReceiverOptions receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
        };

        _telegram.StartReceiving(
            updateHandler: _telegramUpdateHandler.Handle,
            pollingErrorHandler: _telegramPollingErrorHandler.Handle,
            receiverOptions: receiverOptions,
            cancellationToken: CancellationToken.None );
    }
}