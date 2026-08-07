using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MauiApp8.Helpers;

namespace MauiApp8.Helpers
{
    public static class SessionManager
    {
        public static async Task SaveTokenAsync(string token)
        {
            await SecureStorage.Default.SetAsync(Constants.TokenKey, token);
        }

        public static async Task<string?> GetTokenAsync()
        {
            return await SecureStorage.Default.GetAsync(Constants.TokenKey);
        }

        public static void ClearSession()
        {
            SecureStorage.Default.Remove(Constants.TokenKey);
        }
    }
}
