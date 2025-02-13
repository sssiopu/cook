using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

namespace CookBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public MainWindow _mainWindow;

        public Login(MainWindow mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewlogin.Text.Length > 0) 
            {
                if (txtNewpassword.Text.Length > 0) 
                {            
                    DataTable dt_user = MainWindow.Select ("SELECT * FROM [dbo].[users] WHERE [login] = '" + txtNewlogin.Text + "' AND [password] = '" + txtNewpassword.Text + "'");
                    if (dt_user.Rows.Count > 0)
                    {
                        MessageBox.Show("Пользователь авторизовался");    
                    }
                    else MessageBox.Show("Пользователя не найден");
                }
                else MessageBox.Show("Введите пароль"); 
            }
            else MessageBox.Show("Введите логин"); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.regin);
        }
    }
}
