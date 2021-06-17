using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    class CustomerAddress
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        public CustomerAddress()
        {

        }
        public CustomerAddress(string street, string city, string state)
        {
            this.street = street;
            this.city = city;
            this.state = state;
        }
    }
}
