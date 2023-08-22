using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Naruto.Helpers;
using Naruto.Models.DTO;
using Naruto.Service.Interface;

namespace Naruto.Backend.Pages
{
    public partial class Add_Clan
    {
        [Inject]
        public IClan Clans { get; set; } = null!;
        [Inject]
        public Cloudinary_Manager CloudinaryManager { get; set; } = null!;
        [Inject]
        public SweetAlertService Swal { get; set; } = null!;

        public int IdClan { get; set; } = 0;

        static string url = "Assets/Clan_Uzumaki.webp";

        string title = "Add Clan";

        public string imagePreview = url;

        public string _folder = "clan";

        public bool _selectedImage;

        public string _urlImage = null!;

        public string _refImage = null!;

        public string nameImage = Guid.NewGuid().ToString();

        List<ClanDTO>? clanList = null;

        ClanDTO clan = new ClanDTO();

        string btntitle = "ADD CLAN";

        protected override async Task OnInitializedAsync()
        {
            clanList = await Clans._GETS();
        }

        private async void SubmitData()
        {
            if (IdClan == 0)
            {
                if (ValiDationsFields() == true && _selectedImage == true)
                {
                    await UploadImage();

                    var newClan = new ClanDTO()
                    {
                        ClanName = clan.ClanName,
                        Image = _urlImage,
                        RefImage = nameImage
                    };

                    await Clans._POST(newClan);
                    await OnInitializedAsync();
                    Cancel();
                    StateHasChanged();

                }
                else
                {
                    await Swal.FireAsync("Error", "Please fill in all the fields and Image", SweetAlertIcon.Error);
                }
            }
            else
            {
                if (_selectedImage == true)
                {

                    if (ValiDationsFields() == true)
                    {
                        await DeleteImage(_refImage);
                        await UploadImage();


                        var newClan = new ClanDTO()
                        {
                            ClanName = clan.ClanName,
                            Image = _urlImage,
                            RefImage = nameImage
                        };

                        await Clans._PUT(newClan, IdClan);
                        await OnInitializedAsync();
                        Cancel();
                        StateHasChanged();

                    }
                    else
                    {
                        await Swal.FireAsync("Error", "Please fill in all the fields", SweetAlertIcon.Error);
                    }
                }
                else
                {
                    await Clans._PUT(clan, IdClan);
                    await OnInitializedAsync();
                    Cancel();
                }
            }
        }

        private async Task GetClanById(int id, string imgRef)
        {
            clan = await Clans._GET(id);
            btntitle = "UPDATE CLAN";
            IdClan = clan.IdClan;
            imagePreview = clan.Image;
            _refImage = imgRef;
        }

        private async Task DeleteClan(int id, string imgRef)
        {
            var alert = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Estás seguro?",
                Text = "¡No podrás revertir esto!",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                CancelButtonText = "¡No, cancela!",
                ConfirmButtonText = "¡Sí, bórralo!",
                ReverseButtons = true
            });

            if (alert.IsConfirmed)
            {
                await Clans._DELETE(id);
                await DeleteImage(imgRef);
                await OnInitializedAsync();
            }
        }

        private void Cancel()
        {
            clan = new ClanDTO();
            btntitle = "ADD CLAN";
            IdClan = 0;
            _urlImage = null!;
            imagePreview = url;
            _selectedImage = false;
            _refImage = null!;
        }

        private async Task LoadImage(InputFileChangeEventArgs e)
        {
            _selectedImage = true;
            var view = await CloudinaryManager.SelectImage(e);

            if (view != null)
            {
                imagePreview = view;
            }
            else
            {
                imagePreview = url;
            }
        }


        private async Task UploadImage()
        {
            var result = await CloudinaryManager.UploadImage(_folder, nameImage);

            _urlImage = result;
        }

        private async Task DeleteImage(string imgRef)
        {
            await CloudinaryManager.DeleteImage(_folder, imgRef);
        }

        private bool ValiDationsFields()
        {
            if (string.IsNullOrEmpty(clan.ClanName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
