﻿using CookBook.AppFrame;
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

namespace CookBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.Model = new CookBookEntities1();
            AppFrame.MainFrame.FrameMain = Basic;
            Basic.Navigate(new Pages.Login());
        }

        private void Basic_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
