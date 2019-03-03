using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ListViewWithJson.Models;
using Xamarin.Forms;

namespace ListViewWithJson
{
    public partial class MainPage : ContentPage
    {
        public List<ProductData> productDataFromJson;
        string fileName = "ListViewWithJson.products.json";

        public MainPage()
        {
            InitializeComponent();

            ReadInJsonFile();
        }

        private void ReadInJsonFile()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(fileName);

            using (var reader = new StreamReader(stream))
            {
                var jsonAsString = reader.ReadToEnd();
                productDataFromJson = JsonConvert.DeserializeObject<List<ProductData>>(jsonAsString);
            }
            ListViewWithCustomCells.ItemsSource = new ObservableCollection<ProductData>(productDataFromJson);
        }

        async void Handle_ContextMenuMoreButton(object sender, System.EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var itemClicked = menuItem.CommandParameter as ProductData;
            await Navigation.PushAsync(new MoreInfoPage(itemClicked));
        }
    }
}
