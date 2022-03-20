using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarRent
{
    // Модель данных приложения (Model в паттерне MVVM)
    // Модель соответствует имеющейся базе данных CarRentDB (SQLite)
    
    // Арендуемый автомобиль: марка, модель, гос.номер
    public class Car : INotifyPropertyChanged
    {
        private string brand;
        private string model;
        private string regnumber;

        public int ID { get; set; }

        public string Brand
        {
            get { return brand; }
            set
            {
                brand = value;
                OnPropertyChanged("Brand");
            }
        }
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }
        public string RegNumber
        {
            get { return regnumber; }
            set
            {
                regnumber = value;
                OnPropertyChanged("RegNumber");
            }
        }

        public List<Order> Orders { get; set; } = new();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }

    // Клиент, арендующий автомобиль: имя, фамилия, город проживания
    public class Customer : INotifyPropertyChanged
    {
        private string name;
        private string lastname;
        private string city;

        public int ID { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged("LastName");
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public List<Order> Orders { get; set; } = new();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }

    // Заказ, содержит в себе клиент и автомобиль
    // В БД отношение между клиентом и автомобилем "многие ко многим"
    public class Order : INotifyPropertyChanged
    {
        private int timerent;
        private string daterent;        

        public int ID { get; set; }

        public int CarId
        {
            get; set;
        }

        public Car Cars { get; set; }

        public int CustomerId
        {
            get; set;
        }

        public Customer Customers { get; set; }

        public int TimeRent   // время аренды (в часах)
        {
            get { return timerent; }
            set
            {
                timerent = value;
                OnPropertyChanged("TimeRent");
            }
        }
        public string DateRent   // дата аренды (начало аренды)
        {
            get { return daterent; }
            set
            {
                daterent = value;
                OnPropertyChanged("DateRent");
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
