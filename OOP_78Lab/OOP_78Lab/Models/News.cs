using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_78Lab
{
    public class News
    {
        private string title;
        public string Title
        {
            get => title;
            set => title=value;
        }

        private string description;
        public string Desctiprion
        {
            get => description;
            set => description = value;
        }

        private DateTime time;
        public DateTime Time
        {
            get => time;
            set => time = value;
        }

        private string url;
        public string Url
        {
            get => url;
            set => url = value;
        }
    }
}
