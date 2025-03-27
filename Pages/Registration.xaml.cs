using CookBook.AppFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace CookBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void RegiBUT_Click(object sender, RoutedEventArgs e)
        {
            string Name = Nametxt.Text;
            string login = CreateLogintxt.Text;
            string Password = CreatePasswordtxt.Password;
            string PasswordAgain = CreatePasswordAgaintxt.Password;
            DateTime? Biirth = Birthdaytxt.SelectedDate;
            string Work = Worktxt.Text;
            string Email = Emailtxt.Text;
            string Phone = Phonetxt.Text;

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(PasswordAgain) || !Biirth.HasValue || string.IsNullOrWhiteSpace(Work) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Phone))
            {
                MessageBox.Show("Введите все данные", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Password != PasswordAgain)
            {
                MessageBox.Show("Пароли не совпадают", " ( ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (AppFrame.AppConnect.Model.Authors.Count(x => x.Login == CreateLogintxt.Text) > 0)
            {
                MessageBox.Show("Такой логин уже существует", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Authors userObj = new Authors
                {
                    AuthorName = Name,
                    Login = login,
                    Password = Password,
                    Birthday = Biirth.Value,
                    Experience = Work,
                    Email = Email,
                    Phone = Phone

                };
                AppConnect.Model.Authors.Add(userObj);
                AppConnect.Model.SaveChanges();
                MessageBox.Show("Все успешно", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Nametxt.Clear();
                CreateLogintxt.Clear();
                CreatePasswordtxt.Clear();
                CreatePasswordAgaintxt.Clear();
                Birthdaytxt.SelectedDate = null;
                Worktxt.Clear();
                Emailtxt.Clear();
                Phonetxt.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Не работает " + ex.Message, "RIP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBUY_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
