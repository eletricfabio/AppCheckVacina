using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCheckVacina.Services;

namespace AppCheckVacina.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SintomasView : ContentPage
    {
        ContatoService contatoService = new ContatoService();

        public SintomasView()
        {
            InitializeComponent();
        }

        private async void BtnIncluir_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                await DisplayAlert("Erro", "Os campos não podem ficar em branco", "Ok");
            }
            else
            {
                await contatoService.AddContato(Convert.ToInt32(txtID.Text), txtNome.Text, txtEmail.Text, txtCelular.Text, txtFebre.Text, txtDordeCab.Text, txtFaltadeAr.Text);

                txtID.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtCelular.Text = string.Empty;
                txtFebre.Text = string.Empty;
                txtDordeCab.Text = string.Empty;
                txtFaltadeAr.Text = string.Empty;

                await DisplayAlert("Sucess", "Contato incluído com sucesso", "Ok");

            } 
        }
        
    }
}