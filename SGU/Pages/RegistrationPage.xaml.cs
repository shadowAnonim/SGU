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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            Gender_box.Items.Add("Женский");
            Gender_box.Items.Add("Мужской");
        }


        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Utils.checkEmail(Email.Text))
            {
                Utils.Error("Неверный формат почты");
                return;
            }

            try
            {
                User user = new User() { FirstName = First_name.Text, MiddleName = Middle_name.Text, LastName = Last_name.Text, EMail = Email.Text, GenderId = Gender_box.SelectedIndex + 1};
                List<User> users = Utils.db.Users.ToList();
                foreach (User u in users)
                {
                    if (u.EMail == Email.Text)
                    {
                        Utils.Error("Пользователь с такой почтой уже существует");
                        return;
                    }
                }
                Utils.db.Users.Add(user);
                Utils.db.SaveChanges();
                MessageBox.Show("Регистрация успешно пройдена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information );
                NavigationService.GoBack();
            }
            catch(Exception ex)
            {
                Utils.Error(ex.Message);
            }
            
        }
    }
}
