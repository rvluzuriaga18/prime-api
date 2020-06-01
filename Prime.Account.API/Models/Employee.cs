﻿using System;

namespace Prime.Account.API.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public string Job { get; set; }

        public DateTime DateHired {get; set;}
    }
}