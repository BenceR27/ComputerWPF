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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySqlConnector;

namespace Blog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private const string sql = "Server=localhost;User ID=root;Password=;Database=computer";

        private void systemButton_Click(object sender, RoutedEventArgs e)
        {
            Listbox.Items.Clear();
            using (var connection = new MySqlConnection(sql))
            {
                connection.Open();
                var query = "SELECT * FROM osystem";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Listbox.Items.Add(" ID:  " + reader.GetInt32(0) + "  | " +
                                "Name:  " + reader.GetString(1));
                        }
                    }
                }
            }
        }

        private void compButton_Click(object sender, RoutedEventArgs e)
        {
            Listbox.Items.Clear();

            using (var connection = new MySqlConnection(sql))
            {
                connection.Open();
                var query = "SELECT * FROM comp";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Listbox.Items.Add(" Brand: " + reader.GetString(1) + " | " +
                                " Type:  " + reader.GetString(2) + " | " +
                                " Display:  " + reader.GetDouble(3) + " | " +
                                " Memory: " + reader.GetInt32(4) + " | " +
                                " Created time:  " + reader.GetDateTime(5) + " | " +
                                " OsId:  " + reader.GetInt32(6));
                        }
                    }
                }
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}