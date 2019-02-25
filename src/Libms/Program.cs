using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libms
{
    class Program
    {
        public static Int32 q_flag = 0;
        static void Main(string[] args)
        {
            bool loop = true;  //问候方法的变量初始化
            Helper.greet("yes");

            Helper.CreateRobot();   //创造机器人，改变语言风格

            Console.WriteLine("是否初始化图书管理系统?1.是 2.否");
            if(Helper.read() == "1")
            {
                AddDefaultBook.Add();  //初始化图书
                q_flag = 1;
            }                

            while(loop)
            {
                Console.WriteLine("小主，接下来准备做什么呢？ 1.管理图书 2.外借图书 3.退出系统 4.帮助");
                string item = Helper.read();
                if (item == "1")
                {
                    Console.WriteLine("1.查看图书 2.增加图书");
                    if (Helper.read() == "1")
                    {
                        int i = 0;
                        i = Check.check();
                        if(i <= 1)
                        {
                            Console.WriteLine("小主，并没有图书啊！就不需要修改和删除图书了吧！\n");
                            Console.WriteLine("1.添加图书 2.返回主菜单");
                            if (Helper.read() == "1")
                            {
                                Add.add();
                            }
                            else
                            {
                                continue;
                            }
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("1.修改图书 2.删除图书");
                            if (Helper.read() == "1")
                            {
                                Edit.edit();
                            }
                            else
                            {
                                Delete.delete();
                            }
                        }
                    }
                    else
                    {
                        Add.add();
                    }
                }
                else if (item == "2")
                {
                    Borrow.borrow();
                }
                else if (item == "4")
                {
                    Helper.help();
                }
                else
                    loop = false;

                if(loop)
                {
                    Console.WriteLine("小主，屏幕把{0}的眼睛都看花了，是否清理一下？1.是 2.不", Robot.Name);
                    if (Helper.read() == "1")
                        Console.Clear();
                }                
            }

            Console.Clear();
            Helper.greet("");
            Console.WriteLine("请按任意键退出程序,小主拜拜！");
            Console.ReadKey();
        }
    }
}
