using System.Text;
using MauiApp8.Config;
using MauiApp8.Models;
using Newtonsoft.Json;

namespace MauiApp8.Services;

public class AuthService : ApiClient
{
    public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        try
        {
            string json = JsonConvert.SerializeObject(request);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync(ApiSettings.LoginEndpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();

                return new ApiResponse<LoginResponse> { Success = false, Message = $"HTTP {(int)response.StatusCode}\n{error}" };
            }

            string responseJson = await response.Content.ReadAsStringAsync();

            var login = JsonConvert.DeserializeObject<LoginResponse>(responseJson);

            return new ApiResponse<LoginResponse> { Success = true, Data = login, Message = "Login correcto" };
        }
        catch (Exception)
        {
            return new ApiResponse<LoginResponse> { Success = false, Message = "No fue posible conectarse al servidor." };
        }
    }
}