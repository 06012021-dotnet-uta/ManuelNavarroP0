using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    class Customer
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string phoneNum { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Customer()
        {

        }
        public Customer(string fname, string lname, string phoneNum, string email, string password)
        {
            this.fname = fname;
            this.fname = lname;
            this.fname = phoneNum;
            this.fname = email;
            this.fname = password;
        }
    }
}
