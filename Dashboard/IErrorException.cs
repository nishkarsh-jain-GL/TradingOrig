using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    interface IErrorException
    {
        void nullError();
        void valueError();
    }
}
