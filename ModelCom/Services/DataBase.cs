using ModelCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Avalonia;
using DynamicData;

namespace ModelCom.Services
{
    public class Database
    {

       
         
        public IEnumerable<Base> GetBase() 
        {

            string[] ports = SerialPort.GetPortNames();
            IEnumerable<Base> ModCom;
            Base[] modCom=new Base[ports.Length];
            for (int i=0; i < ports.Length;i++)

            {
                modCom[i] = new Base { Description= ports[i] };

               
            }

            ModCom=modCom;
            if (ModCom.Count() == 0)
            { 
               // return GetItems();
            }

                return ModCom;
        }

        //public IEnumerable<Base> GetItems() => new[]
        //{



        //    new Base { Description = "Not found Com ports1" },
        //    new Base { Description = "Not found Com ports2" },
        //    new Base { Description = "Not found Com ports3" },
        //    new Base { Description = "Not found Com ports4" },
        //    new Base { Description = "Not found Com ports5" },

        //};
    }
}
