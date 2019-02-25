using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libms
{
     static class Robot
    {
        public static string Name { get; set; }
        public static void SayHello()
        {
            Console.WriteLine("小主您好，我叫{0}，谢谢你选择了我！\n", Name);
        }
    }
}
