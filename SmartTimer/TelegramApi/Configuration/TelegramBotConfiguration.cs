using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace TelegramApi.Configuration;

public class TelegramBotConfiguration : ITelegramBotConfiguration
{
    private readonly IConfiguration _settings;

    [ConfigurationProperty( "token", IsRequired = true )]
    public string Token
    {
        get => _settings[ "token" ];
        set => _settings[ "token" ] = value;
    }


    public TelegramBotConfiguration( IConfiguration configuration ) 
    {
        _settings = configuration.GetSection( "TelegramBot" ) as TelegramBotConfiguration;
    }
}