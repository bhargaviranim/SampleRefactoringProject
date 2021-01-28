using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinnacleSample
{
   public interface ICustomerRepositoryDB
    {
        Customer GetByName(string name);
    }
}
