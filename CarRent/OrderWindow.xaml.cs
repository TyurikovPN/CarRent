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
using System.Runtime;

namespace CarRent
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public Order Order
        {
            get; set;
        }

        public OrderWindow(Order ord)
        {
            InitializeComponent();

            Order = ord;

            TB1.Text = Order.TimeRent .ToString ();
            this.DataContext = new AppViewModel ();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car Car = CarsList.SelectedItem as Car;
                Order.CarId = Car.ID;
                Customer Customer = CustomersList.SelectedItem as Customer;
                Order.CustomerId = Customer.ID;
            }
            catch { MessageBox.Show("Вы не выбрали машину или клиента из списка"); }

            Order.TimeRent  = Convert .ToInt32(TB1.Text);

            this.DialogResult = true;
        }
    }
}
