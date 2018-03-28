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
using SimpleBankSystem.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace SimpleBankSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Initialises a connection to the localhost database named "simplebankdb"
        static string connectionString = "SERVER=localhost;DATABASE=simplebankdb;UID=root;PASSWORD=password;";
        MySqlConnection connection = new MySqlConnection(connectionString);

        public MainWindow()
        {
            InitializeComponent();

        }



        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmdRegister = connection.CreateCommand();

            string id = IdentificationStorage.getInstance().GenerateID('U');

            cmdRegister.CommandText = "insert into person (idPerson, password, firstName, lastName, userName) VALUES ('"
                + id + "', '" + tbPasswordRegister.Text + "', '" + tbFirstName.Text + "', '" + tbLastName.Text + "', '" + tbUsernameRegister.Text + "')";
            connection.Open();
            cmdRegister.ExecuteNonQuery();
            MessageBox.Show("Thank you for registering " + tbFirstName.Text + " " + tbLastName.Text + "!");
            connection.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int returnedRows = 0;

            connection.Open();
            MySqlCommand cmdCheckCredentials = connection.CreateCommand();
            cmdCheckCredentials.CommandType = CommandType.Text;

            
            cmdCheckCredentials.CommandText = "select * from person where userName='" + tbUsernameLogin
                .Text + "' and password='" + tbPasswordLogin.Text + "'";


            cmdCheckCredentials.ExecuteNonQuery();

            DataTable dataTable = new DataTable();

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmdCheckCredentials);

            dataAdapter.Fill(dataTable);

            connection.Close();
            returnedRows = Convert.ToInt32(dataTable.Rows.Count);

            if(returnedRows == 0)
            {
                //Invalid credentials!
                MessageBox.Show("You have entered an invalid username and/or password!");
            }
            else
            {
                MessageBox.Show("You have successfully logged in " + tbUsernameLogin.Text + "!");
            }
        }

        private void CreateBankUser(object sender, RoutedEventArgs e)
        {
            Person user = new BankUser();
        }

        private void CreateAdmin(object sender, RoutedEventArgs e)
        {
            Person userAdmin = new Administrator();
        }

        private void CreateDeveloper(object sender, RoutedEventArgs e)
        {
            Person userDev = new Developer();
        }

        private void ViewIDStorage(object sender, RoutedEventArgs e)
        {
            IdentificationStorage.getInstance().PrintAllID();

        }
    }
}
