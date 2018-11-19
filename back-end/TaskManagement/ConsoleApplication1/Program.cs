using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"C:\Users\User\Desktop\seldat-finalProject\back-end\TaskManagement\ConsoleApplication1";
            //path = "../../../DAL/bin/Debug/DAL.dll";
            //string full=Path.GetFullPath(path); 
            //Console.Read();

            //string word = "EmailUser";
            //List<char> arr =new List<char>();
            //word.ToList().ForEach(ch =>
            //{
            //    if (ch >= 'A' && ch <= 'Z')
            //    {
            //        arr.Add('_');
            //        arr.Add(ch.ToString().ToLower()[0]);
            //    }
            //    else
            //        arr.Add(ch);
            //});
            //arr.ForEach(f => Console.Write(f));
            //Console.Read();

            string input = "TestStringForYou";
            string replaced = Regex.Replace(input, @"(?<!_)([A-Z])", "_$1");
            replaced=replaced.ToLower();
            replaced=replaced.Substring(1);
            Console.WriteLine(replaced);
            Console.Read();
        }
    }
}
