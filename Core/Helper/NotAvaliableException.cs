﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
   public class NotAvaliableException:Exception
    {

        public NotAvaliableException(string message):base (message) { }
    }
}
