﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Orders
{
    public class OrderAddress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
    }
}
