using Microsoft.EntityFrameworkCore;
using SGU.Data;
using System;
using System.Collections.Generic;
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

namespace SGU.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorisationPage.xaml
    /// </summary>
    public partial class AutorisationPage : Page
    {
        public AutorisationPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = Utils.db.Users.FirstOrDefault(u => u.EMail.ToLower() == loginTb.Text.ToLower().Trim());
            if (user == null)
            {
                Utils.Error("Такой пользователь не существует");
                return;
            }
            if (user.Password != passwordTb.Password.Trim())
            {
                Utils.Error("Неверный пароль");
                return;
            }
            NavigationService.Navigate(new MenuPage(user));
        }
    }
}
