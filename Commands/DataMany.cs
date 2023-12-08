using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiScripter.Commands
{
    internal class DataMany
    {
        private string cmd;
        private string rn;
        private string regList;

        public DataMany(string CMD, string Rn, string RegisterList)
        {
            this.cmd = CMD;
            this.rn = Rn;
            this.regList = RegisterList;
        }

        private string ConvertRegister(string register)
        {
            register = register.Replace("R", "");
            int num = Convert.ToInt32(register);
            register = Convert.ToString(num, 2);
            register = register.PadLeft(4, '0');
            return register;
        }

        private string ConvertRange()
        {
            this.regList = this.regList.Replace("{", "");
            this.regList = this.regList.Replace("}", "");
            string[] range = this.regList.Split("-");
            int num = Convert.ToInt32(range[0]);
            int num2 = Convert.ToInt32(range[1]);
            string instruction;
            string bits = "";

            if (num < num2)
            {
                this.regList = "1";
                this.regList =this.regList.PadLeft(num2 - num, '1');
            }
            else {
                this.regList = this.regList.PadLeft(num-num2, '1');
            }


            this.regList = this.regList.PadLeft(16, '0');

            return regList;
        }


        public string ExecuteMany()
        {
            string LBit = "0";
            string PBit = "0";
            string UBit = "0";
            string cond = "1110";
            if (this.cmd == "LDMEA")
            {
                LBit = "1";
                PBit = "1";
            }
            else{
                LBit= "0";
                PBit= "0";
                UBit= "1";
            }
            string instruction = cond + "100" + PBit + UBit + "0" + "1" + LBit + ConvertRegister(this.rn) + ConvertRange();
            int numver = instruction.Length;

            return instruction;
        }

        






    }
}
