using System;
using System.Collections.Generic;

namespace homework.Models
{
    public class BusPark
    {
        
        #region Private Properties

        private static List<int> _busnumbers;

        #endregion

        #region Public Properties

        private List<Bus> _buspark;
        public List<Bus> Buspark
        {
            get => _buspark;
            private set => _buspark = value;
        }
        
        
        #endregion

        #region Public Methods

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
            return 0;
        }

        public List<Bus> OutPark()
        {
            var list = new List<Bus>();
            list = _buspark.FindAll(delegate(Bus bs)
            {
                return bs.Status == 1;
            });
            return list;
        }

        public List<Bus> InPark()
        {
            var list = new List<Bus>();
            list = _buspark.FindAll(delegate(Bus bs)
            {
                return bs.Status == 0;
            });
            return list;
        }
        
        #endregion

        #region Initializator

        public BusPark()
        {
            
            _buspark = new List<Bus>();
            _busnumbers = new List<int>();

        }

        #endregion
        
        #region Debug Methods



        #endregion

    }
}