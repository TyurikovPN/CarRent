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
using System.Windows.Shapes;

namespace CarRent
{
    /// <summary>
    /// Логика взаимодействия для CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        public Car Car { get; private set; }
        public CarWindow(Car c)
        {
            InitializeComponent();
            Car = c;
            this.DataContext = Car;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
