﻿using System;
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

namespace SimpleBankSystem
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

        private void CreateBankUser(object sender, RoutedEventArgs e)
        {
            Person user = new BankUser();
            System.Diagnostics.Debug.WriteLine(user.ID);
        }

        private void CreateAdmin(object sender, RoutedEventArgs e)
        {
            Person userAdmin = new Administrator();
            System.Diagnostics.Debug.WriteLine(userAdmin.ID);
        }

        private void CreateDeveloper(object sender, RoutedEventArgs e)
        {
            Person userDev = new Developer();
            System.Diagnostics.Debug.WriteLine(userDev.ID);
        }

    }
}