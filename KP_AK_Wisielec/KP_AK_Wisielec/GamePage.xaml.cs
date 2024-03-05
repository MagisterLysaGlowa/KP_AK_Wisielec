using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KP_AK_Wisielec
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        string button_characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ-.";
        string password_guess = "";
        string hidden_password = "";
        string category_name = "";
        int mistakes = 0;
        public GamePage(string category_name)
        {
            InitializeComponent();
            this.category_name = category_name;
        }
    }
}