using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Naruto.Helpers;
using Naruto.Models.DTO;
using Naruto.Service.Interface;
using Naruto.Service.Repositories;

namespace Naruto.Backend.Pages
{
    public partial class Add_Character
    {
        [Inject]
        private ICharacter Characters { get; set; } = null!;
        [Inject]
        private IClan Clans { get; set; } = null!;
        [Inject]

        private Cloudinary_Manager CloudinaryManager { get; set; } = null!;
        [Inject]
        private SweetAlertService Swal { get; set; } = null!;

        [Inject]
        private RepositoryJutsu Jutsus { get; set; } = null!;

        [Inject]
        private RepositoryVillage Village { get; set; } = null!;

        [Inject]
        private RepositoryOcupation Ocupation { get; set; } = null!;

        [Inject]
        private RepositoryCurrent Status { get; set; } = null!;


        [Parameter]
        public int IdCharacter { get; set; } = 0;

        CharacterDTO characters = new CharacterDTO();


        List<ClanDTO> listClan = new List<ClanDTO>();
        ClanDTO addClan = new ClanDTO();

        List<JutsusDTO> listJutsu = new List<JutsusDTO>();
        JutsusDTO addJutsu = new JutsusDTO();

        List<VillagesDTO> listVillage = new List<VillagesDTO>();
        VillagesDTO addVillage = new VillagesDTO();

        List<OcupationDTO> listOcupation = new List<OcupationDTO>();
        OcupationDTO addOcupation = new OcupationDTO();

        List<CurrentDTO> listStatus = new List<CurrentDTO>();


        static string url = "Assets/Naruto_logo.png";

        public string imagePreview = url;

        public string _folder = "character";

        public bool _selectedImage;

        public string _urlImage = null!;

        public string _refImage = null!;

        public string nameImage = Guid.NewGuid().ToString();

        string btntitle = "";

        string title = "Add Character";

        string namePlaceholder = "";

        string ModalTitle = "";

        string closeModal = "modal";

        string propertyModel = "";

        enum typeModal
        {
            CLAN,
            JUTSU,
            VILLAGE,
            OCUPATION
        }

        protected override async Task OnInitializedAsync()
        {
            if (IdCharacter == 0)
            {
                btntitle = "ADD CHARACTER";
                title = "Add Character";
                listClan = await Clans._GETS();
                listJutsu = await Jutsus._GETS();
                listVillage = await Village._GETS();
                listOcupation = await Ocupation._GETS();
                listStatus = await Status._GETS();
            }
            else
            {
                btntitle = "EDIT CHARACTER";
                title = "Edit Character";
                listClan = await Clans._GETS();
                listJutsu = await Jutsus._GETS();
                listVillage = await Village._GETS();
                listOcupation = await Ocupation._GETS();
                listStatus = await Status._GETS();
                await GetOneCharacter();
            }
        }
        public void SelectButtonModal(string text)
        {
            if (text.ToUpper() == typeModal.CLAN.ToString())
            {
                namePlaceholder = "Add Clan";
                ModalTitle = "CLAN";
                propertyModel = addClan.ClanName;
            }
            else if (text.ToUpper() == typeModal.JUTSU.ToString())
            {
                namePlaceholder = "Add Jutsu";
                ModalTitle = "JUTSU";
                propertyModel = addJutsu.JutsuName;
            }
            else if (text.ToUpper() == typeModal.VILLAGE.ToString())
            {
                namePlaceholder = "Add Village";
                ModalTitle = "VILLAGE";
                propertyModel = addVillage.VillageName;
            }
            else if (text.ToUpper() == typeModal.OCUPATION.ToString())
            {
                namePlaceholder = "Add Ocupation";
                ModalTitle = "OCUPATION";
                propertyModel = addOcupation.OcupationName;
            }
        }
        private async Task GetOneCharacter()
        {
            characters = await Characters._GET(IdCharacter);
            imagePreview = characters.Image;
            _refImage = characters.RefImage;
            characters.IdClan = characters.IdClan;
            characters.IdJutsu = characters.IdJutsu;
            characters.IdVillage = characters.IdVillage;
            characters.IdOcupation = characters.IdOcupation;
            characters.IdStatus = characters.IdStatus;
        }
        private async Task AddInfoAditiona()
        {
            if (ModalTitle.ToUpper() == typeModal.CLAN.ToString())
            {
                await Clans._POST(new ClanDTO { ClanName = propertyModel, Image = "https://res.cloudinary.com/erudito/image/upload/v1692840384/clan/ClanUzumaki.webp" });
                listClan = await Clans._GETS();
                StateHasChanged();
                ResetFieldsModal();
            }
            else if (ModalTitle.ToUpper() == typeModal.JUTSU.ToString())
            {
                await Jutsus._POST(new JutsusDTO { JutsuName = propertyModel });
                listJutsu = await Jutsus._GETS();
                StateHasChanged();
                ResetFieldsModal();
            }
            else if (ModalTitle.ToUpper() == typeModal.VILLAGE.ToString())
            {
                await Village._POST(new VillagesDTO { VillageName = propertyModel });
                listVillage = await Village._GETS();
                StateHasChanged();
                ResetFieldsModal();
            }
            else if (ModalTitle.ToUpper() == typeModal.OCUPATION.ToString())
            {
                await Ocupation._POST(new OcupationDTO { OcupationName = propertyModel });
                listOcupation = await Ocupation._GETS();
                StateHasChanged();
                ResetFieldsModal();
            }
        }
        private async Task SubmitData()
        {
            if (IdCharacter == 0)
            {
                if (ValiDationsFields() == true && _selectedImage == true)
                {
                    await UpLoadImage();

                    var newChatacter = new CharacterDTO
                    {
                        FirstName = characters.FirstName,
                        IdClan = characters.IdClan,
                        Age = characters.Age,
                        Image = _urlImage,
                        RefImage = nameImage,
                        IdJutsu = characters.IdJutsu,
                        IdVillage = characters.IdVillage,
                        IdOcupation = characters.IdOcupation,
                        IdStatus = characters.IdStatus
                    };

                    await Characters._POST(newChatacter);
                    ResetFields();
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
                        await UpLoadImage();

                        await DeleteImageCloud(_refImage);

                        var newChatacter = new CharacterDTO
                        {
                            FirstName = characters.FirstName,
                            IdClan = characters.IdClan,
                            Age = characters.Age,
                            Image = _urlImage,
                            RefImage = nameImage,
                            IdJutsu = characters.IdJutsu,
                            IdVillage = characters.IdVillage,
                            IdOcupation = characters.IdOcupation,
                            IdStatus = characters.IdStatus
                        };

                        var result = await Characters._PUT(newChatacter, IdCharacter);

                        if (result == true)
                        {
                            ResetFields();
                            StateHasChanged();
                        }
                        else
                        {
                            await Swal.FireAsync("Error", "Please fill in all the fields", SweetAlertIcon.Error);
                        }
                    }

                }
                else
                {
                    if (ValiDationsFields() == true)
                    {
                        var newChatacter = new CharacterDTO
                        {
                            FirstName = characters.FirstName,
                            IdClan = characters.IdClan,
                            Age = characters.Age,
                            Image = characters.Image,
                            RefImage = characters.RefImage,
                            IdJutsu = characters.IdJutsu,
                            IdVillage = characters.IdVillage,
                            IdOcupation = characters.IdOcupation,
                            IdStatus = characters.IdStatus
                        };
                        var result = await Characters._PUT(newChatacter, IdCharacter);
                        if (result == true)
                        {
                            ResetFields();
                            StateHasChanged();
                        }
                    }
                    else
                    {
                        await Swal.FireAsync("Error", "Please fill in all the fields", SweetAlertIcon.Error);
                    }
                }
            }
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
        private async Task UpLoadImage()
        {
            var result = await CloudinaryManager.UploadImage(_folder, nameImage);

            _urlImage = result;
        }
        private async Task DeleteImageCloud(string imgRef)
        {
            await CloudinaryManager.DeleteImage(_folder, imgRef);
        }
        private void ResetFields()
        {
            characters = new CharacterDTO();
            _selectedImage = false;
            imagePreview = url;
            _urlImage = null!;
            _refImage = null!;
            btntitle = "ADD CHARACTER";
            title = "Add Character";
        }
        private void ResetFieldsModal()
        {
            closeModal = "modal";
            addClan = new ClanDTO();
            addJutsu = new JutsusDTO();
            addVillage = new VillagesDTO();
            addOcupation = new OcupationDTO();
            namePlaceholder = "";
            ModalTitle = "";
            propertyModel = "";
        }
        private bool ValiDationsFields()
        {
            if (characters.FirstName == null || characters.FirstName == "")
            {
                return false;
            }
            else if (characters.IdClan == 0)
            {
                return false;
            }
            else if (characters.Age == 0)
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
