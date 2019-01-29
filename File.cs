using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NLP
{

    class Program
    {
        // static int Sub_(string s)
        //{
        //    if (s.Contains("\t"))
        //        return 0;
        //    else if(s.Contains(" "))

        //}


        static void Main(string[] args)
        {
            string path = @"C:\Users\Kotik\Desktop\Practika\datasets\AskAPatient\";

            string new_path1 = @"C:\Users\Kotik\Desktop\Practika\3_1\";

            string file_string = "";

            for (int i=0; i<10; i++)
            {
                StreamReader file = new StreamReader(path + "AskAPatient.fold-" + i + ".test.txt");
                StreamWriter new_file1 = new StreamWriter(new_path1 + "A" + i + "_1.txt");
                StreamWriter new_file2 = new StreamWriter(new_path1 + "A" + i + "_2.txt");

                while (file.ReadLine() != null)
                {
                    file_string = file.ReadLine();

                   // int count = 0;

                    int index;

                    //Console.WriteLine("Rfnz"+file_string);
                    if (file_string == null)
                        break;

                    index = file_string.IndexOf("\t");

                    string file_substring = "";
                    file_substring = file_string.Substring(index+1);

                    string sub = "";
                    sub = file_substring.Substring(0,file_substring.IndexOf("\t"));

                    new_file2.WriteLine(sub);

                    sub = file_substring.Substring(file_substring.IndexOf("\t")+1);

                    string file_write = "";

                    new_file1.WriteLine(sub);
                }

                file.Close();
                new_file1.Close();
                new_file2.Close();
            }           
        }
    }
}
