using KP_AK_Wisielec.Models;
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
        List<PasswordModel> passwords = new List<PasswordModel>()
        {
            new PasswordModel("cow,","animal"),
            new PasswordModel("cat,","animal"),
            new PasswordModel("dog,","animal"),
            new PasswordModel("hammer,","item"),
            new PasswordModel("drill,","item"),
            new PasswordModel("fork,","item"),
            new PasswordModel("rose,","plant"),
            new PasswordModel("apple,","plant"),
            new PasswordModel("pear,","plant"),
            new PasswordModel("los angeles,","city"),
            new PasswordModel("new york,","city"),
            new PasswordModel("warsaw,","city"),
        };
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
                button.Clicked += LetterButton_Clicked;
                Grid.SetColumn(button, i % 7);
                Grid.SetRow(button, i / 7);
                button_grid.Children.Add(button);

            }
        }

        private void LetterButton_Clicked(object sender,EventArgs e)
        {
            var button = (Button)sender;
            if (SetLettersInGuess(button.Text))
            {
                button.BorderColor = Color.Green;
                button.TextColor = Color.Green;
            }
            else
            {
                button.BorderColor = Color.Red;
                button.TextColor = Color.Red;
            }
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