using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WorkShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DBConecshen DBConecshen;
        public static CurrentUser CurrentUser;
        public MainWindow()
        {
            InitializeComponent();
            DBConecshen = new DBConecshen();
        }

        private void bt_login_Click(object sender, RoutedEventArgs e)
        {
            var avtorizachiya = new Avtorizachiya();
            avtorizachiya.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            avtorizachiya.Show();
            this.Close();
        }

        private void bt_reg_Click(object sender, RoutedEventArgs e)
        {
            string login = Text_Login.Text;
            string email = Text_Pochta.Text;
            string password1 = Text_V_Password.Text;
            string password2 = Text_P_Password.Text;
            bool dataCorrect = true;

            var regexLog = new Regex(@"^[\w\d!*]{1,17}$");
            var regexPas = new Regex(@"^[\w\d!*$#]{5,25}$");
            var regexEmail = new Regex(@"^[\w\d]{3,40}@[\w\d]{3,6}\.[\w]{2,5}$");

            if (regexLog.IsMatch(login))
                Text_Login.Foreground = Brushes.Green;
            else
            {
                Text_Login.Foreground = Brushes.Red;
                dataCorrect = false;
            }

            if (regexPas.IsMatch(password1))
                Text_V_Password.Foreground = Brushes.Green;
            else
            {
                Text_V_Password.Foreground = Brushes.Red;
                dataCorrect = false;
            }

            if (regexPas.IsMatch(password2))
                Text_P_Password.Foreground = Brushes.Green;
            else
            {
                Text_P_Password.Foreground = Brushes.Red;
                dataCorrect = false;
            }

            if (regexEmail.IsMatch(email))
                Text_Pochta.Foreground = Brushes.Green;
            else
            {
                dataCorrect = false;
                Text_Pochta.Foreground = Brushes.Red;
            }

            if (password1 != password2)
            {
                Text_P_Password.Foreground = Brushes.Red;
                Text_V_Password.Foreground = Brushes.Red;
                dataCorrect = false;
            }

            if (dataCorrect)
            {
                string SQLExpreshion = @"Insert into [users](login,password,email)" +
                                     $"values('{Text_Login.Text}', '{Text_V_Password.Text}', '{Text_Pochta.Text}');";
                var command = new SqlCommand(SQLExpreshion, DBConecshen.con);
                command.ExecuteNonQuery();
                MessageBox.Show("запись создана!!!!!!!!!!!!");
            }
        }
    }
}
