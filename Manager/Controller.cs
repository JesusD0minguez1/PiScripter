using PiScripter.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiScripter.Manager
{
    static class Controller
    {
        static List<byte> data = new List<byte>();       

        public static void ExecuteMOV(string CMD, string register, string hex)
        {
            switch (CMD)
            {
                case "MOVW":
                    MOVW movw = new MOVW(register, hex);
                    string movwCMD = movw.Execute();
                    ConvertTOBytes(movwCMD);
                    break;
                case "MOVT":
                    MOVT movt = new MOVT(register, hex);
                    string movtCMD = movt.Execute();
                    ConvertTOBytes(movtCMD);
                    break;
      
            }


        }

     
        public static void ExecuteCMDS(string CMD, string rd, string rn, string hex)
        {
            Command command = new Command(CMD, rd, rn, hex);
            string instruction = command.Execute();
            ConvertTOBytes(instruction);

        }

        public static void ExecuteBranch(string cond, bool linkBit,string offset)
        {
            string instruction;
            if(cond == "B:") { cond = null; }
            if (cond != null)
            {
                Branch branch = new Branch(cond, linkBit, offset);
                instruction = branch.Execute();
                ConvertTOBytes(instruction);
               
            }
            else
            {
                Branch branch = new Branch(linkBit, offset);
                instruction = branch.Execute();
                ConvertTOBytes(instruction);

            }



        }

        public static void ExecuteBranchL(bool linkBit, string offset)
        {
            Branch branch = new Branch(linkBit, offset);
            string instruction = branch.Execute();
            ConvertTOBytes(instruction);

        }


        public static void ExecuteBranchX(string rn)
        {
            BranchX branch = new BranchX(rn);
            string instruction = branch.Execute();
            ConvertTOBytes(instruction);

        }

        public static void ExecuteDT(string CMD, string rn, string rd)
        {
            DataTransfer dt = new DataTransfer(CMD,rn,rd);
            string instruction = dt.Execute();
            ConvertTOBytes(instruction);
        }

        public static void ExecuteDelay()
        {
            Delay delay = new Delay();
            string[] instruciton = delay.ExecuteDelay();
            for (int i = 0; i < instruciton.Length; i++)
            {
                ConvertTOBytes(instruciton[i]);
            }
        }

        public static void ConvertTOBytes(string instruction)
        {
            List<Byte> bytes = new List<Byte>();
            for (int i = 0; i <= 24; i += 8)
            {
                bytes.Add(
                    Convert.ToByte(instruction.Substring(i, 8), fromBase: 2)
                );

            }
            bytes.Reverse();


            data.Add(bytes[0]);
            data.Add(bytes[1]);
            data.Add(bytes[2]);
            data.Add(bytes[3]);
            bytes.Clear();

        }


        public static void ExecuteDTMany(string CMD, string Rn, string RegList)
        {
            DataMany dtMany = new DataMany(CMD, Rn, RegList);
            string instruction = dtMany.ExecuteMany();
            ConvertTOBytes(instruction);
           
        }


        public static int CalculateOffset(List<String> words,int index)
        {
            int value = 0;
            for (int i = index; i < words.Count; i++)
            {
                if (words[i].Contains("[DELAY]")){ return value - 2; }
                value++;
            }
            return value - 2;

        }


        public static void WriteAssembly()
        {
            string localDir = "C:\\Users\\jedominguez\\Downloads\\";
            File.WriteAllBytes(localDir + "kernel7.img", data.ToArray());
        }

    }
}
