using ConsultarCep.Services;
using System;
using Xamarin.Forms;

namespace ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Btn_Submit_Clicked(object sender, EventArgs e)
        {
            if (!Valido()) return;

            try
            {
                using (var _viaCepServices = new ViaCepServices())
                {
                    var endereco = _viaCepServices.BuscarEndereco(Ent_CEP.Text.Trim());
                    if (endereco == null)
                    {
                        DisplayAlert("Erro ao buscar o CEP", "CEP inválido", "Ok");
                        return;
                    }
                    Lbl_Resultado.Text = string.Format("Endereço: {0}, {1}, {2}-{3}", endereco.Logradouro, endereco.Bairro, endereco.Localidade, endereco.Uf);
                }
            }
            catch (Exception)
            {
                DisplayAlert("Erro de servidor", "Não foi possível buscar os dados.", "Ok");
            }
        }

        private bool Valido()
        {
            var valido = true;
            if (Ent_CEP.Text.Length < 8)
            {
                DisplayAlert("Validação", "o Cep deve conter 8 caracteres.", "Ok");
                valido = false;
            }

            var ret = 0;
            if (!int.TryParse(Ent_CEP.Text, out ret))
            {
                DisplayAlert("Validação", "o CEP deve conter somente números", "Ok");
                valido = false;
            }
            return valido;
        }
    }
}