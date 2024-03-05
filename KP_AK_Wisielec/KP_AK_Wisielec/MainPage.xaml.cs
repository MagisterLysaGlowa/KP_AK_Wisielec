using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KP_AK_Wisielec
{
    public partial class MainPage : ContentPage
    {
        List<string> categories = new List<string>()
        {
            "item", "animal", "city", "plant"
        };

        public MainPage()
        {
            InitializeComponent();
            picker_category.ItemsSource = categories;
            picker_category.SelectedItem = categories[0];
        }
    }
}
