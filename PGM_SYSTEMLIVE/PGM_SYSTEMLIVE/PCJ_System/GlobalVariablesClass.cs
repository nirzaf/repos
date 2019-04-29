using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCJ_System
{
    class GlobalVariablesClass
    {
        private static String v_VariableOne = "";

        public static String VariableOne
        {
            get { return v_VariableOne; }
            set { v_VariableOne = value; }
        }
       
    }
}
