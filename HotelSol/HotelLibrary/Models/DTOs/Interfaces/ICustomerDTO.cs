﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models.DTOs.Interfaces
{
    public interface ICustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
