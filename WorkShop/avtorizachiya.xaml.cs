using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WorkShop
{
    /// <summary>
    /// Логика взаимодействия для avtorizachiya.xaml
    /// </summary>
    public partial class Avtorizachiya : Window
    {
        public Avtorizachiya()
        {
            InitializeComponent();
        }

        private void bt_Close_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string SQLExpression = @"select * from [users]" +
                                    $"where convert(Varchar, login) = '{Text_Login.Text}'" +
                                    $"and convert(varchar, password) = '{Text_Password.Text}'";

            var cmd = new SqlCommand(SQLExpression, MainWindow.DBConecshen.con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() &&
                (string)reader.GetValue(1) == Text_Login.Text &&
                (string)reader.GetValue(2) == Text_Password.Text)
            {
                MainWindow.CurrentUser.id = (int)reader.GetValue(0);
                MainWindow.CurrentUser.login = (string)reader.GetValue(1);
                reader.Close();
            }
            else
            {
                MessageBox.Show("пользователь не найден");
            }
        }
    }
}
