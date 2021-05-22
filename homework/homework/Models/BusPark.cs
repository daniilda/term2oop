using System;
using System.Collections.Generic;
using System.IO;

namespace homework.Models
{
    public class BusPark
    {
        
        #region Private Properties

        private static List<int> _busnumbers;

        #endregion

        #region Public Properties

        private LinkedList<Bus> _buspark;
        public LinkedList<Bus> Buspark
        {
            get => _buspark;
            private set => _buspark = value;
        }
        
        public LinkedList<Bus> OutPark
        { 
            get
            {
                var list = new LinkedList<Bus>();
                list = _buspark.FindAll(delegate(Bus bs) { return bs.Status >= 1; });
                return list;
            }
        }
        

        public LinkedList<Bus> InPark
        {
            get
            {
                var list = new LinkedList<Bus>();
                list = _buspark.FindAll(delegate(Bus bs) { return bs.Status == 0; });
                return list;
            }
        }
        
        
        #endregion

        #region Public Methods

        public void ReadFromFile()
        {
            string path = @"../../buspark.txt";
            if (!File.Exists(path))
            {
                return;
            }
            var rowdata = File.ReadAllLines(path);
            
            Buspark.Clear();
            for(var i=0 ; i<rowdata.Length ; i++)
            {
                string[] line = rowdata[i].Split(' ');
                if (line[2] == "-1")
                {
                    Bus bus;
                    bus = new Bus(int.Parse(line[0]), line[1], null, byte.Parse(line[3]));
                    Buspark.Add(bus);
                }
                else
                {
                    Bus bus;
                    bus = new Bus(int.Parse(line[0]), line[1], int.Parse(line[2]), byte.Parse(line[3]));
                    Buspark.Add(bus);
                }
            }
            
        }

        public void WriteToFile()
        {
            string path = @"../../buspark.txt";
            var list = Buspark.ToList();
            string[] lines = new string[list.Count];
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].Route == null)
                    lines[i]=$"{list[i].Num} {list[i].DriverName} -1 {list[i].Status}";
                else
                    lines[i]=$"{list[i].Num} {list[i].DriverName} {list[i].Route} {list[i].Status}";
            }
            File.WriteAllLines(path, lines);
        }
        
        public byte Edit(Bus old,Bus edited) 
        {
            if ((edited.Num != old.Num) && _busnumbers.Contains(edited.Num))
            {
                return 1;
            }
            _buspark.Remove(old);
            _buspark.Add(edited);
            return 0;
        }

        public byte Remove(Bus bus)
        {
            _buspark.Remove(bus);
            _busnumbers.Remove(bus.Num);
            return 0;
        }

        public byte Add(int num, string name, int? route=null, byte status=0)
        {
            if (_busnumbers.Contains(num))
            {
                return 1;
            }
            var bus = new Bus(num, name, route, status);
            _busnumbers.Add(num);
            Buspark.Add(bus);
            return 0;
        }

        public bool CheckNum(int num)
        {
            return _busnumbers.Contains(num);
        }

        public int Lastnum()
        {
            
            _busnumbers.Sort();
            if (_busnumbers.Count == 0)
                return 0;
            return _busnumbers[_busnumbers.Count - 1] + 1;

        }

      

        
        
        #endregion

        #region Initializator

        public BusPark()
        {
            
            _buspark = new LinkedList<Bus>();
            _busnumbers = new List<int>();

        }

        #endregion
        
        #region Debug Methods



        #endregion

    }
}