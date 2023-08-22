using Blazored.LocalStorage;

namespace Naruto.Helpers
{
    public class LocalStorageData
    {
        private readonly string keyLocalStorage = "myData";

        private readonly ILocalStorageService localStorage;

        public LocalStorageData(ILocalStorageService localStorageService)
        {
            localStorage = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
        }

        public async Task<string?> GetLocalStorage()
        {
            try
            {
                return await localStorage.GetItemAsync<string>(keyLocalStorage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving from local storage: {ex.Message}");
                return null;
            }
        }

        public async Task SetLocalStorage(string value)
        {
            try
            {
                await localStorage.SetItemAsync(keyLocalStorage, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error storing in local storage: {ex.Message}");
            }
        }

        public async Task RemoveLocalStorage()
        {
            try
            {
                await localStorage.RemoveItemAsync(keyLocalStorage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing from local storage: {ex.Message}");
            }
        }
    }
}
