using MauiApp8.Config;

namespace MauiApp8.Services;

public class ApiClient
{
    protected readonly HttpClient HttpClient;

    public ApiClient()
    {
        HttpClient = new HttpClient
        {
            BaseAddress = new Uri(ApiSettings.BaseUrl)
        };
    }
}