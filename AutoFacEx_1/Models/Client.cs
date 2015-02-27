using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFacEx_1.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Client()
        {
        }
        public Client( int Id, string Name )
        {
            this.Id = Id;
            this.Name = Name;
        }

    }
}