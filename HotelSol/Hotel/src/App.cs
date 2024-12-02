using HotelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src
{
    public class App
    {
        private IClass _class;

        public App(IClass myClass)
        {
            _class = myClass;
        }

        public void Run()
        {
            _class.ProcessData();
        }
    }
}
