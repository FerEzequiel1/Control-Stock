using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinFormsApp1.Delegados;

namespace WinFormsApp1
{
    internal class Persona
    {
        private int edad;
        public event mensajeDelegado mensaje1;
        public event mensajeDelegado mensaje2;

        public Persona()
        {
           
        }

        public int Edad {

            get { return this.edad; }
            set
            {
                if (value == 2)
                {
                    mensaje2.Invoke(value);
                }
                else
                {
                    if(value == 1)
                    {
                        mensaje1.Invoke(value); 
                    }
                }
            }
        
        }

       
    }
}
