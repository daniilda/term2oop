namespace homework.Models
{
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

        public Bus(int num, string name, int? route, byte status)
        {
            _num = num;
            _driverName = name;
            _route = route;
            _status = status;
        }
        
    }
}