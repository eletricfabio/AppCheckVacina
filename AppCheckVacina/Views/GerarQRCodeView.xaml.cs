using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace AppCheckVacina.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GerarQRCodeView : ContentPage
    {
        ZXingBarcodeImageView qr;
        public GerarQRCodeView()
        {
            InitializeComponent();
        }

        private void btnGeneraCodigo_Clicked(object sender, EventArgs e)
        {
            qr = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeOptions.Width = 500;
            qr.BarcodeOptions.Height = 500;
            qr.BarcodeValue = txtValorQR.Text;
            //qr.BarcodeValue = "https://www.youtube.com/watch?v=q1f2vzn8xbA";//
            stkQR.Children.Add(qr);
        }
    }
}