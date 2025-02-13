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
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = AppFrame.AppConnect.Model.Authors.FirstOrDefault(u => u.Login == txtNewlogin.Text && u.Password == txtNewpassword.Text);
                if (user != null)
                {
                    MessageBox.Show($"Вы успешно вошли, {user.AuthorName}");
                }
                else
                {
                    MessageBox.Show($"vi durak :P :3 ^o^ ^_^ (‿|‿)   (╥﹏╥) programma RIP † ");
                }
            }
            catch 
            {
                MessageBox.Show("vi durak :P :3 ^o^ ^_^ (‿|‿)   (╥﹏╥) programma RIP † ");
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.MainFrame.FrameMain.Navigate(new regin());
        }
    }
}
