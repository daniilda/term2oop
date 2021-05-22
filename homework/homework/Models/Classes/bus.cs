using System;
using System.ComponentModel;

namespace homework.Models
{
    public class BusModel : IDataErrorInfo //для валидации модели
    {
        private int _num;
        public int Num
        {
            get => _num;
            set => _num = value;
        }

        private string _driverName;
        public string DriverName
        {
            get => _driverName;
            set => _driverName = value;
        }

        private int? _route;
        public int? Route
        {
            get => _route;
            set => _route = value;
        }

        private byte _status;
        public byte Status
        {
            get => _status;
            set => _status = value;
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Num":
                        if (Num < 0 || Num > 100)
                        {
                            error = "Попробуйте другое число";
                        }
                        break;
                    case "Name":
                        //Обработка ошибок для свойства Name
                        break;
                    case "Route":
                        //Обработка ошибок для свойства Position
                        break;
                    case "Status":
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }

    

    public class Bus
    {


        private int _num;
        public int Num
        {
            get => _num;
            set => _num = value;
        }

        private string _driverName;
        public string DriverName
        {
            get => _driverName;
            set => _driverName = value;
        }

        private int? _route;
        public int? Route
        {
            get => _route;
            set => _route = value;
        }

        private byte _status;
        public byte Status
        {
            get => _status;
            set => _status = value;
        }
        public string NameOfStatus
        {
            get
            {
                if (_status == 0)
                {
                    return "В парке";
                }
                if (_status == 1)
                {
                    return "Вне парка";
                }
                    return "На маршруте"; 
            }
        }


        public Bus(int num, string name, int? route, byte status)
        {
            _num = num;
            _driverName = name;
            _route = route;
            _status = status;
        }

        
    }
}