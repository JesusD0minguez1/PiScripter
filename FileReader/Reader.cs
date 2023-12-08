using PiScripter.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiScripter.FileReader
{
    internal class Reader
    {


        public void Execute(string pathFile)
        {
            try {
                using (StreamReader sr = new StreamReader(pathFile))
                {
                    string str = sr.ReadToEnd();
                    sr.Close();
                    string[] words = str.Split(new char[]{'\r','\n'});
                    var Ilist = words.ToList();
                    for(int i=0; i < Ilist.Count; i++)
                    {
                        if(Ilist[i] == "" || Ilist[i] == " "){ Ilist.Remove(Ilist[i]);}
                    }
                    int num = 0;

                    while (num < Ilist.Count)
                    {
                        string[] lines = Ilist[num].Split(" ");

                        Console.WriteLine(lines);

                        switch (lines[0])
                        {
                            case "MOVT":
                                Controller.ExecuteMOV(lines[0], lines[1], lines[2]);
                                num++;
                                break;
                            case "MOVW":
                                Controller.ExecuteMOV(lines[0], lines[1], lines[2]);
                                num++;
                                break;
                            case "ADD":
                                Controller.ExecuteCMDS(lines[0], lines[1], lines[2], lines[3]);
                                num++;
                                break;
                            case "SUB":
                                Controller.ExecuteCMDS(lines[0], lines[1], lines[2], lines[3]);
                                num++;
                                break;
                            case "ORR":
                                Controller.ExecuteCMDS(lines[0], lines[1], lines[2], lines[3]);
                                num++;
                                break;
                            case "LDR":
                                Controller.ExecuteDT(lines[0], lines[2], lines[1]);
                                num++;
                                break;
                            case "STR":
                                Controller.ExecuteDT(lines[0], lines[2], lines[1]);
                                num++;
                                break;
                            case "LDMEA":
                                Controller.ExecuteDTMany(lines[0], lines[1], lines[2]);
                                num++;
                                break;
                            case "STMEA":
                                Controller.ExecuteDTMany(lines[0], lines[1], lines[2]);
                                num++;
                                break;
                            case "B:":
                                Controller.ExecuteBranch(lines[0], false, lines[1]);
                                num++;
                                break;

                            case "B":
                                Controller.ExecuteBranch(lines[1], false, lines[2]);
                                num++;
                                break;
                            case "BL:":
                                int offset = Controller.CalculateOffset(Ilist, num);
                                Controller.ExecuteBranchL(true, offset.ToString());
                                num++;
                                break;
                            case "BX":
                                Controller.ExecuteBranchX(lines[1]);
                                num++;
                                break ;



                        }

                    }
                    



                }
                Controller.WriteAssembly();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);          
            }
        
        
        
        
        }


    }
}
