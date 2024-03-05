using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        private void GenerateButtons()
        {
            for (int i = 0; i < button_characters.Length; i++)
            {
                var button = new Button()
                {
                    Text = button_characters[i].ToString(),
                    CornerRadius = 15,
                    TextColor = Color.Black,
                    BorderWidth = 3,
                    BorderColor = Color.Black,
                    BackgroundColor = Color.Transparent,
                    FontAttributes = FontAttributes.Bold,
                };

                Grid.SetColumn(button, i % 7);
                Grid.SetRow(button, i / 7);
                button_grid.Children.Add(button);

            }
        }

        private void LetterButton_Clicked(object sender,EventArgs e)
        {
            var button = (Button)sender;

        }

        private bool SetLettersInGuess(string letter)
        {
            bool any_correct = false;
            for (int i = 0; i < hidden_password.Length; i++)
            {
                if (hidden_password.ToUpper()[i] == letter.ToUpper()[0])
                {
                    StringBuilder stringBuilder = new StringBuilder(password_guess);
                    stringBuilder[i] = letter[0];
                    password_guess = stringBuilder.ToString();
                    any_correct = true;
                }
            }

            if (!any_correct)
            {
                mistakes++;
            }

            return any_correct;
        }

    }
}