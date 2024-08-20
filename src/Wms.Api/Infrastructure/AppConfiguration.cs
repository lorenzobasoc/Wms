namespace Wms.Api.Infrastructure;

public class AppConfiguration
{
    private readonly IConfiguration _config;

    public string ASPNETCORE_ENVIRONMENT { get; set; }
    public string DATABASE_URL { get; }
    public string DATABASE_URL_TEST { get; }
    public string FIRST_ADMIN_EMAIL { get; }
    public string FIRST_ADMIN_PASSWORD { get; }
    
    public AppConfiguration(IConfiguration config) {
        _config = config;
        ASPNETCORE_ENVIRONMENT = GetNonEmptyString(nameof(ASPNETCORE_ENVIRONMENT));
        DATABASE_URL = GetNonEmptyString(nameof(DATABASE_URL));
        DATABASE_URL_TEST = GetNonEmptyString(nameof(DATABASE_URL_TEST));
        FIRST_ADMIN_EMAIL = GetNonEmptyString(nameof(FIRST_ADMIN_EMAIL));
        FIRST_ADMIN_PASSWORD = GetNonEmptyString(nameof(FIRST_ADMIN_PASSWORD));
    }

    public string this[string key] => _config[key];

    private string GetNonEmptyString(string key) {
        var value = _config[key];
        if (string.IsNullOrEmpty(value)) {
            throw new ArgumentNullException(key);
        }
        return value;
    }

    private int GetInt(string key) {
        var value = _config[key];
        if (int.TryParse(value, out int result)) {
            return result;
        } else {
            var error = $"key '{key}' - '{value}' is not parsable to a int";
            throw new ArgumentException(error);
        }
    }
}
