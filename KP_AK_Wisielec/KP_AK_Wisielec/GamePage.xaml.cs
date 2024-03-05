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
            GenerateButtons();
            hidden_password = GetRandomPassword();
        }

        private string GetRandomPassword()
        {
            Random random = new Random();
            var passwords_list = passwords.Where(x => x.Category == category_name).ToList();
            int randomIndex = random.Next(0,passwords_list.Count);
            PasswordModel model = passwords_list[randomIndex];
            return model.Password;
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


        private void SetPasswordInvisible()
        {
            for (int i = 0;i < hidden_password.Length;i++)
            {
                if (hidden_password[i] == ' ')
                {
                    password_guess += "_";
                }
                else
                {
                    password_guess += ' ';
                }
            }
            password_label.Text = password_guess;
        }

        private void DisplayInfo()
        {
            password_label.Text = password_guess;
            hangmen_image_container.Source = $"s{mistakes}.jpg";
            mistakes_label.Text = "mistakes: " + mistakes;
        }

        private void BackToMainMenu(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        
        private void CheckEndGame()
        {
            if(password_guess.ToUpper() == hidden_password.ToUpper())
            {
                var button = new Button()
                {
                    Text = "Wroc do menu",
                    BorderColor = Color.Green,
                    TextColor = Color.White,
                    FontAttributes = FontAttributes.Bold,
                    CornerRadius = 20,
                };

                button_area.Children.Add(button);
                button_grid.IsEnabled = false;
            }

            if (mistakes >= 9)
            {
                var button = new Button()
                {
                    Text = "Wroc do menu",
                    BorderColor = Color.Red,
                    TextColor = Color.White,
                    FontAttributes = FontAttributes.Bold,
                    CornerRadius = 20,
                };

                button_area.Children.Add(button);
                button_grid.IsEnabled = false;
            }
        }
    }
}