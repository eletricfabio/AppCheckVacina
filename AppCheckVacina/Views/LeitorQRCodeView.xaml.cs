using Acr.UserDialogs;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCheckVacina.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeitorQRCodeView : ContentPage
    {
        public LeitorQRCodeView()
        {
            InitializeComponent();
        }

        private async void btnScannerQR_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText = "Aponte a câmera para leitura";
                scanner.BottomText = "Obrigado!";
                var result = await scanner.Scan();
                if (result != null)
                {
                    UserDialogs.Instance.ShowLoading("Verificando"); 
                    await Task.Delay(2500);
                    await DisplayAlert("Vacinação", "Imunizado(a): " + result, "Ok");
                    txtResultado.Text = result.Text;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }
    }
}