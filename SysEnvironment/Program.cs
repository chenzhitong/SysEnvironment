using Microsoft.Win32;
using System;
using System.Linq;

namespace SysEnvironment
{
    class Program
    {
        public static void Main()
        {
            SetPath(Environment.CurrentDirectory);
            Console.ReadLine();
        }
        
        public static void SetPath(string directory)
        {
            var userEnvironment  = Registry.CurrentUser.OpenSubKey("Environment", true);
            string path = userEnvironment.GetValue("PATH").ToString();
            if (!path.Split(';').Contains(directory))
            {
                userEnvironment.SetValue("PATH", path + directory + ";");
                Console.WriteLine("已将当前目录添加到用户的环境变量PATH中");
            }
            else
            {
                Console.WriteLine("环境变量PATH中已存在当前目录，不用重复添加");
            }
        }
    }
}
