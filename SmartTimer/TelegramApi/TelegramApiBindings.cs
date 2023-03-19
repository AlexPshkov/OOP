using SimpleInjector;
using TelegramApi.Configuration;
using TelegramApi.Handlers;
using TelegramApi.Telegram;

namespace TelegramApi;

public static class TelegramApiBindings
{
    public static Container AddTelegramApiBindings( this Container container )
    {
        container.Register<ITelegramUpdateHandler, TelegramUpdateHandler>( Lifestyle.Scoped );
        container.Register<ITelegramPollingErrorHandler, TelegramPollingErrorHandler>( Lifestyle.Scoped );
        
        container.Register<ITelegramBotConfiguration, TelegramBotConfiguration>( Lifestyle.Singleton );
        
        container.Register<TelegramApiBot>( Lifestyle.Singleton ); 

        return container;
    }
}