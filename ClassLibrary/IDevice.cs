using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public interface IDevice
    {
        public string Firm { get;  set;}
        public string getParameters();
        public string startWorking();
    }
}
