using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Libms
{
    class Helper
    {
        /// <summary>
        /// 建立访问路径
        /// </summary>
        public static String Path
        {
            get
            {
                String path = String.Format("{0}\\data.xml", Environment.CurrentDirectory);

                if (Program.q_flag == 0)
                {
                    Program.q_flag = 1;
                    String E_path = String.Format("{0}\\data.xml", Environment.CurrentDirectory);

                    var s = Enumerable.Range(1, 1);
                    XDocument xdoc = new XDocument(
                        new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("Books",
                            from item in s
                            select new XElement("book",
                            new XElement("name", ""),
                            new XElement("author", ""),
                            new XElement("price", ""),
                            new XElement("number", "")
                        )));
                    xdoc.Save(E_path);
                    return E_path;
                }
                return path;
            }
        }

        /// <summary>
        /// 帮助
        /// </summary>
        public static void help()
        {
            Console.WriteLine("该图书管理系统总共有四个功能\n1.修改图书：管理图书>>修改图书\n2.删除图书：管理图书>>查看图书>>删除图书\n3.添加图书：管理图书>>查看图书>>添加图书\n4.外借图书\n");
        } 

        /// <summary>
        /// 欢迎或者送别
        /// </summary>
        /// <param name="WorF"></param>
        public static void greet(string WorF)
        {
            if (WorF == "yes")
                WorF = "欢迎";
            else
                WorF = "谢谢";
            Console.WriteLine("**************************************************");
            Console.WriteLine("*                                                *");
            Console.WriteLine("*                                                *");
            Console.WriteLine("*            "+ WorF +"使用图书馆管理系统              *");
            Console.WriteLine("*                                                *");
            Console.WriteLine("*                                                *");
            Console.WriteLine("**************************************************");
            Console.WriteLine("\n");
        }

        /// <summary>
        /// 读取选项数据
        /// </summary>
        /// <returns></returns>
        public static string read()
        {
            string result;
            Console.Write("请输入：");
            result = Console.ReadLine();
            while(result != "1" && result != "2" && result != "3" && result != "4")
            {
                Console.Write("输入错误，请重新输入！\n请输入：");
                result = Console.ReadLine();
            }
            Console.WriteLine();
            return result;
        }

        /// <summary>
        /// 读取字符串数据
        /// </summary>
        /// <returns></returns>
        public static string readString()
        {
            string result;
            Console.Write("请输入：");
            result = Console.ReadLine();
            Console.WriteLine();
            return result;
        }

        /// <summary>
        /// 创建机器人
        /// </summary>
        public static void CreateRobot()
        {
            Console.WriteLine("本系统有两个服务机器人(1.小I，2.小J),请选择：");
            string robot = Helper.read();
            if (robot == "1")
            {
                Robot.Name = "小I";
            }
            else
            {
                Robot.Name = "小J";
            }
            Robot.SayHello();
        }

        public static void input(XElement item)
        {
            if(item.Element("name").Value.Trim() == "")
                Console.WriteLine("书名：" + item.Element("name").Value.Trim() + "");
            else
                Console.WriteLine("书名：<<" + item.Element("name").Value.Trim() + ">>");
            Console.WriteLine("作者：" + item.Element("author").Value.Trim());
            Console.WriteLine("价格：" + item.Element("price").Value.Trim());
            Console.WriteLine("数量：" + item.Element("number").Value.Trim() +"\n");
            
        }
    }
}
