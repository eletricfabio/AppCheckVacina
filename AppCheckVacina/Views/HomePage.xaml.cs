using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCheckVacina.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void BtnGerarQRCode_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GerarQRCodeView());
        }

        private void BtnLeitorQRCode_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LeitorQRCodeView());
        }

        private void BtnSintomas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SintomasView());
        }

        private async void BtnEmergencia_Clicked(object send, EventArgs e)
        {
            try
            {
                await Launcher.OpenAsync("tel:192");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops, deu um erro", ex.Message, "OK");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}