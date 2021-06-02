using Database.DataSet1TableAdapters;
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
using System.Windows.Shapes;


namespace Database
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string Name;
        public string Password;

        private UsersTableAdapter UTA = new UsersTableAdapter();
        private DataSet1 DS = new DataSet1();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UTA.Fill(DS.Users);
            DataContext = DS.Users;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var query = from user in DS.Users
                        where (user.Name == txtName.Text)
                        where (user.Password == txtPassword.Text)
                        select user;

            if (query.Count() > 0)
            {
                MainWindow window = new MainWindow();
                window.Show();
                Close();
            }
            else
            {
                MessageBoxResult box = MessageBox.Show("User doesn't exist. Try registering a new user", "Submit", MessageBoxButton.OK, MessageBoxImage.Error);
                txtName.Clear();
                txtPassword.Clear();
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            DataSet1.UsersRow row = (DataSet1.UsersRow)DS.Users.NewRow();
            row.Name = txtName.Text;
            row.Password = txtPassword.Text;
            DS.Users.AddUsersRow(row);
            UTA.Update(DS);
            MessageBoxResult box = MessageBox.Show("User registered!", "Register", MessageBoxButton.OK, MessageBoxImage.Information);
            txtName.Clear();
            txtPassword.Clear();
        }
    }
}
