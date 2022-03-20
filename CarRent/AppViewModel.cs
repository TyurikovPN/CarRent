using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CarRent
{
    internal class AppViewModel: INotifyPropertyChanged 
    {
        AppContext db;
        RelayCommand caraddCommand;
        RelayCommand careditCommand;
        RelayCommand cardeleteCommand;
        RelayCommand customeraddCommand;
        RelayCommand customereditCommand;
        RelayCommand customerdeleteCommand;
        RelayCommand orderaddCommand;
        RelayCommand ordereditCommand;
        RelayCommand orderdeleteCommand;
        IEnumerable<Car> cars;
        IEnumerable<Customer> customers;
        IEnumerable<Order> orders;
        public IEnumerable<Car> Cars
        {
            get { return cars; }
            set
            {
                cars = value;
                OnPropertyChanged("Cars");
            }
        }
        public IEnumerable<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                OnPropertyChanged("Customers");
            }
        }
        public IEnumerable<Order> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged("Orders");
            }

        }

        public AppViewModel()
        {
            db = new AppContext();
            db.Cars.Load();
            Cars = db.Cars.Local.ToBindingList();
            db.Customers.Load();
            Customers = db.Customers.Local.ToBindingList();
            db.Orders.Load();
            Orders = db.Orders.Local.ToBindingList();

        }

        public RelayCommand CarAddCommand
        {
            get
            {
                return caraddCommand ??
                    (caraddCommand = new RelayCommand((o) =>
                    {
                        CarWindow carWindow = new CarWindow(new Car());
                        if (carWindow.ShowDialog() == true)
                        {
                            Car car = carWindow.Car;
                            db.Cars.Add(car);
                            try { db.SaveChanges(); }
                            catch { MessageBox.Show("Введены пустые поля!"); }
                        }
                    }));
            }
        }
        public RelayCommand CarEditCommand
        {
            get
            {
                return careditCommand ??
                    (careditCommand = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        Car car = selectedItem as Car;
                        Car vm = new Car()
                        {
                            ID = car.ID,
                            Brand = car.Brand,
                            Model = car.Model,
                            RegNumber = car.RegNumber
                        };
                        CarWindow carWindow = new CarWindow(vm);
                        if (carWindow.ShowDialog() == true)
                        {
                            car = db.Cars.Find(carWindow.Car.ID);
                            if (car != null)
                            {
                                car.Brand = carWindow.Car.Brand;
                                car.Model = carWindow.Car.Model;
                                car.RegNumber = carWindow.Car.RegNumber;
                                db.Cars.Update(car);
                                db.SaveChanges();
                            }
                        }
                    }));
            }

        }
        public RelayCommand CarDeleteCommand
        {
            get
            {
                return cardeleteCommand ??
                   (cardeleteCommand = new RelayCommand((SelectedItem) =>
                   {
                       if (SelectedItem == null) return;
                       Car car = SelectedItem as Car;
                       db.Cars.Remove(car);
                       db.SaveChanges();
                   }));
            }
        }
        public RelayCommand CustomerAddCommand
        {
            get
            {
                return customeraddCommand ??
                    (customeraddCommand = new RelayCommand((o) =>
                    {
                        CustomerWindow customerWindow = new CustomerWindow(new Customer());
                        if (customerWindow.ShowDialog() == true)
                        {
                            Customer customer = customerWindow.Customer;
                            db.Customers.Add(customer);
                            try { db.SaveChanges(); }
                            catch { MessageBox.Show("Введены пустые поля!"); }
                        }
                    }));
            }
        }
        public RelayCommand CustomerEditCommand
        {
            get
            {
                return customereditCommand ??
                    (customereditCommand = new RelayCommand((SelectedItem) =>
                    {
                        if (SelectedItem == null) return;
                        Customer customer = SelectedItem as Customer;
                        Customer vm = new Customer()
                        {
                            ID = customer.ID,
                            Name = customer.Name,
                            LastName = customer.LastName,
                            City = customer.City
                        };
                        CustomerWindow customerWindow = new CustomerWindow(vm);
                        if (customerWindow.ShowDialog() == true)
                        {
                            customer = db.Customers.Find(customerWindow.Customer.ID);
                            if (customer != null)
                            {
                                customer.Name = customerWindow.Customer.Name;
                                customer.LastName = customerWindow.Customer.LastName;
                                customer.City = customerWindow.Customer.City;
                                db.Customers.Update(customer);
                                db.SaveChanges();
                            }
                        }
                    }));
            }

        }
        public RelayCommand CustomerDeleteCommand
        {
            get
            {
                return customerdeleteCommand ??
                   (customerdeleteCommand = new RelayCommand((SelectedItem) =>
                   {
                       if (SelectedItem == null) return;
                       Customer customer = SelectedItem as Customer;
                       db.Customers.Remove(customer);
                       db.SaveChanges();
                   }));
            }
        }


        public RelayCommand OrderAddCommand
        {
            get
            {
                return orderaddCommand ??
                    (orderaddCommand = new RelayCommand((o) =>
                    {
                        OrderWindow orderWindow = new OrderWindow(new Order());
                        if (orderWindow.ShowDialog() == true)
                        {
                            Order order = orderWindow.Order;
                            order.DateRent = DateTime.Now.ToString("dd-MM-yyyy");
                            db.Orders.Add(order);
                            try { db.SaveChanges(); }
                            catch { MessageBox.Show("Введены пустые поля!"); }
                        }
                    }));
            }
        }

        public RelayCommand OrderEditCommand
        {
            get
            {
                return ordereditCommand ??
                    (ordereditCommand = new RelayCommand((SelectedItem) =>
                    {
                        if (SelectedItem == null) return;
                        Order order = SelectedItem as Order;
                        Order vm = new Order()
                        {
                            ID = order.ID,
                            CarId  = order.CarId ,
                            CustomerId  = order.CustomerId,
                            TimeRent  = order.TimeRent
                        };
                        OrderWindow orderWindow = new OrderWindow(vm);
                        if (orderWindow.ShowDialog() == true)
                        {
                            order = db.Orders.Find(orderWindow.Order.ID);
                            if (order != null)
                            {
                                order.CarId  = orderWindow.Order.CarId ;
                                order.CustomerId = orderWindow.Order.CustomerId;
                                order.TimeRent = orderWindow.Order.TimeRent;
                                db.Orders.Remove(order);
                                db.SaveChanges();
                                db.Orders.Add(order);
                                db.SaveChanges();
                            }
                        }
                    }));
            }

        }

        public RelayCommand OrderDeleteCommand
        {
            get
            {
                return orderdeleteCommand ??
                   (orderdeleteCommand = new RelayCommand((SelectedItem) =>
                   {
                       if (SelectedItem == null) return;
                       Order Order = SelectedItem as Order;
                       db.Orders.Remove(Order);
                       db.SaveChanges();
                   }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
