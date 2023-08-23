using Microsoft.AspNetCore.Components;
using Naruto.Helpers;
using Naruto.Models.Model;
using Naruto.Service.Repositories;

namespace Naruto.Backend.Pages
{
    public partial class AuthView
    {
        [Inject]
        private RepositoryAuth repositoryAuth { get; set; } = null!;

        [Inject]
        private LocalStorageData LocalStorageData { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        private InitialConfiguration myConfig { get; set; } = null!;

        string title = "Register";
        string btnTitle = "Show Login";
        bool isLogin = false;
        string ShowRegister = "d-block";
        string ShowLogin = "d-none";


        Auth authData = new Auth();

        private void ShowBtn()
        {
            if (isLogin)
            {
                title = "Register";
                btnTitle = "Show Login";
                isLogin = false;
                ShowRegister = "d-block";
                ShowLogin = "d-none";
            }
            else
            {
                title = "Login";
                btnTitle = "Show Register";
                isLogin = true;
                ShowRegister = "d-none";
                ShowLogin = "d-block";
            }
        }


        protected override async Task OnInitializedAsync()
        {

            //   await myConfig.DefaultData();
            await base.OnInitializedAsync();
            if (await LocalStorageData.GetLocalStorage() != null)
            {
                NavigationManager.NavigateTo("/home");
            }

        }


        private async void Login()
        {
            var query = await repositoryAuth._LOGIN(authData);

            if (query == true)
            {
                title = "Login Con Exito";

                await LocalStorageData.SetLocalStorage(authData.Username);

                NavigationManager.NavigateTo("/home");
            }
            else
            {
                title = "Error al Logiarte";
            }
        }

        private async void Register()
        {
            var query = await repositoryAuth._REGISTER(authData);

            if (query == true)
            {
                title = "Registrado Con Exito";

                await LocalStorageData.SetLocalStorage(authData.Username);

                NavigationManager.NavigateTo("/home");
            }
            else
            {
                title = "Ya Existe Un Registro";
            }
        }
    }
}
