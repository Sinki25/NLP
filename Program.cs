using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP2
{
    class Program
    {

      //  static List<char> numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        static void Main(string[] args)
        {
            string path = @"C:\Users\Kotik\Desktop\Practika\annotated_test\";
            

           // List<int> numbers = new List<int>() { 0,1,2,3,4,5,6,7,8,9};


            for (int i=0;i<10;i++)
            {
                string file1 = path + "A" + i.ToString() + "_1.txt.json";
                string file2 = path + "A" + i.ToString() + "_2.txt.json";
                string[] codesFromFile1 = GetNumbersArrayFromFile(file1);              
                string[] codesFromFile2 = GetNumbersArrayFromFile(file2);
                int coincidence = compareCodes(codesFromFile1, codesFromFile2);
                string result = "COincidence for " + i + "_1 and " + i + "_2: " + coincidence.ToString();
                Console.WriteLine(result);
            }

        }

        private static int compareCodes(string[] codes1, string[] codes2)
        {
            int count = 0;
            int i = 0;
           // Console.WriteLine(codes1[i].Length);
           // Console.WriteLine(codes1[i]);

            while (i < 433)
            {
                codes1[i] = codes1[i].Trim();
                codes2[i] = codes2[i].Trim();

               // Console.WriteLine(codes1[i].Length);

                if (codes1[i] == "" || codes2[i] == "")
                {
                   // Console.WriteLine(i);
                    i++;
                }
                else if (codes1[i].Length == 8 && codes2[i].Length == codes1[i].Length)
                {
                    if (codes1[i] == codes2[i])
                    {
                        //Console.WriteLine(codes1[i]);
                        //Console.WriteLine(codes2[i]);
                        count++;
                       // Console.WriteLine(i);
                       
                    }

                    i++;
                }
                else if (codes1[i].Length <= codes2[i].Length)
                {
                    string[] in_numbers = codes2[i].Split(' ');

                    for (int j = 0; j < in_numbers.Count(); j++)
                    {
                        if (codes1[i].Contains(in_numbers[j]))
                        {
                            //Console.WriteLine(codes1[i]);
                            //Console.WriteLine(codes2[i]);
                            count++;
                            break;
                        }
                    }

                    i++;
                }
                else if (codes1[i].Length > codes2[i].Length)
                {
                    string [] in_numbers = codes1[i].Split(' ');
                       
                    for(int j = 0; j < in_numbers.Count(); j++)
                    {
                        if(codes2[i].Contains(in_numbers[j]))
                        {
                            count++;
                            //Console.WriteLine(i);
                            //Console.WriteLine(codes1[i]);
                            //Console.WriteLine(codes2[i]);
                            break;
                        }
                    }

                    i++;
                }

            }

            return count;
        
        }

        private static string[] GetNumbersArrayFromFile(string filename)
        {
            StreamReader file = new StreamReader(filename);

            string f = file.ReadToEnd();

            int index = 0, index1 = 0;
            int i = 0, j = 0;
            bool result = false;


            string[] numbers = new string[433];

            for(int n = 0; n<433; n++)
            {
                numbers[n] = "";
            }

            while (j < 433)
            {
               // Console.WriteLine(j);
               // Console.WriteLine(i);
                if (j.ToString() + "C" == (f[i].ToString() + f[i + 1].ToString()) && j < 10)
                {
                    index = i + 1;

                    index1 = j+1;

                    

                    while (result == false)
                    {
                        i++;

                        
                        //Console.WriteLine(i);
                        

                        if (index1.ToString() + "C" == (f[i].ToString() + f[i + 1].ToString()) || index1.ToString() + "C" == (f[i].ToString() + f[i + 1].ToString()+ f[i + 2].ToString()))
                        {
                            result = true;
                        }
                        else if (i==f.Length)
                        {
                            index1++;
                            i = index;
                        }

                    }

                    numbers[j]=f.Substring(index, i - index);
                   // Console.WriteLine(numbers[j]);
                    j++;

                    if(j==10)
                    {
                        i--;
                    }

                    result = false;
                }
                else if(" "+j.ToString() + "C" == (f[i].ToString() + f[i + 1].ToString() + f[i + 2].ToString() + f[i + 3].ToString()) && j < 100)
                {
                   // Console.WriteLine(j);
                    index = i + 3;

                    index1 = j + 1;

                    while (result == false)
                    {


                        if (i + 3 == f.Length - 1)
                        {
                            //Console.WriteLine(index1);
                            index1++;
                            i = index;
                        }
                        else if (" "+index1.ToString() + "C" == (f[i-1]+f[i].ToString() + f[i + 1].ToString() + f[i + 2].ToString()) || " "+index1.ToString() + "C" == (f[i - 1] + f[i].ToString() + f[i + 1].ToString() + f[i + 2].ToString() + f[i + 3].ToString()))
                        {
                            result = true;
                            
                        }
                        else
                        {
                            i++;

                        }                      

                    }

                    numbers[j] = f.Substring(index, i - index);
                    //Console.WriteLine(i);
                    //Console.WriteLine(j);
                    //Console.WriteLine(numbers[j]);
                    j++;
                    i--;
                    result = false;

                    //Console.WriteLine(j);
                }
                else if( j == 432)
                {
                    index = i + 3;
                    i = f.LastIndexOf("\"");
                    numbers[j] = f.Substring(index,i - index - 1);
                    break;
                }
                else if(j.ToString() + "C" == (f[i].ToString() + f[i + 1].ToString() + f[i + 2].ToString() + f[i + 3].ToString()) && j >= 100)
                {
                    index = i + 3;

                    index1 = j + 1;

                    //Console.WriteLine(index1);

                    while (result == false)
                    {
                       // i++;

                        //Console.WriteLine(j);
                        //Console.WriteLine(i);

                        if (index1.ToString() + "C" == (f[i].ToString() + f[i + 1].ToString() + f[i + 2].ToString() + f[i + 3].ToString()))
                        {
                            result = true;
                        }
                        else if (i+3 == f.Length - 1)
                        {
                            index1++;
                            i = index;
                        }
                        else if(index1== 433)
                        {
                            break;
                        }
                        else
                        {
                            i++;
                        }

                    }

                    numbers[j] = f.Substring(index, i - index);
                    //Console.WriteLine(j);
                   // Console.WriteLine(numbers[100]);
                    j++;
                    result = false;
                }
                else if( i +3 == f.Length - 1)
                {
                    j++;
                    i = 0;
                }
                else
                {
                    i++;
                }
                
            }

           // Console.WriteLine(numbers[432]);
            return numbers;
        }

    }
}
