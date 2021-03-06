﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReporting.Dal.Exceptions.CustomTypes
{
    public class DalException : Exception
    {
        public string errorType;

        public DalException(string errorType, string message) : base(message)
        {
            this.errorType = errorType;
        }
    }
}
