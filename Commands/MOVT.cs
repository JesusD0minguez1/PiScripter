using PiScripter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiScripter.Commands
{
    public class MOVT : ICommand
    {

        private string imm16;
        private string register;
        List<char> imm4 = new List<char>();
        List<char> imm12 = new List<char>();

        public MOVT(string register, string imm16)
        {
           this.imm16 = imm16;
            this.register = register;  
        }

        private void ConvertRegister()
        {
            this.register = this.register.Replace("R", "");
            int num = Convert.ToInt32(this.register);
            this.register = Convert.ToString(num, 2);
            this.register = this.register.PadLeft(4, '0');
        
        }



        private string ConvertImm16()
        {
            if (this.imm16.Contains("0x"))
            {
                this.imm16 = this.imm16.Replace("0x", "");
            }
            int number = Convert.ToInt32(this.imm16, 16);
            return Convert.ToString(number, 2).PadLeft(16, '0');
        }

        private void SplitImm16()
        {
           this.imm16 = ConvertImm16();  
           var arr = imm16.ToCharArray();
           
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < 4) { imm4.Add(arr[i]); }
                else { imm12.Add(arr[i]); }
            }
                     
        }


        private string immValues(List<Char> immValue)
        {
            string value = "";
            for(int c =0; c < immValue.Count(); c++)
            {
                value += immValue[c];
            }
            Console.WriteLine(value);
            return value;
        }

        public string Execute()
        {
            SplitImm16();
            ConvertRegister();
            string Cond = "1110";
            string imm4s = immValues(imm4);
            string imm12s = immValues(imm12);

            string Instruction = Cond + "00110100" + imm4s + this.register + imm12s;
           
            return Instruction;
           
        }
    }
}
