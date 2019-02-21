using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library_managment_system
{
    class Borrow
    {
        public static void borrow()
        {
            int flag = 0;
            XDocument xd = XDocument.Load(Helper.Path);
            XElement xe = xd.Element("Books");
            var books = xe.Elements();

            Console.WriteLine("现藏图书如下：");
            foreach (var item in books)
            {
                Console.WriteLine("<<" + item.Element("name").Value.Trim() + ">>");
            }
            Console.WriteLine();

            Console.WriteLine("请输入书名：");
            var name = Helper.readString();
            foreach (var item in books)
            {
                if (item.Element("name").Value.Trim() == name)
                {
                    flag = 1;
                    int num = 0;
                    Console.Write("请稍等......\n已找到！\n请输入要借的数量：");
                    num = Convert.ToInt32(Helper.readString());
                    while (Convert.ToInt32(item.Element("number").Value.Trim()) < num)
                    {
                        Console.WriteLine("不好意思，库存只有{0}本了，请重新输入要借的数量！", item.Element("number").Value.Trim());
                        num = Convert.ToInt32(Helper.readString());
                    }

                    var sb = item.Element("number");
                    sb.ReplaceWith(new XElement("number", Convert.ToInt32(sb.Value.Trim()) - num));

                    xd.Save(Helper.Path);
                    Console.WriteLine("1.继续借书 2.返回主菜单");
                    if (Helper.read() == "1")
                        borrow();
                    return;
                }
            }

            if(flag != 1)
            {
                Console.WriteLine("{0}实在已经尽力了，还是没找到!1.重新输入书名 2.返回主菜单", Robot.Name);
                if(Helper.read() == "1")
                    borrow();
                return;
            }

            Console.WriteLine("1.继续借书 2.返回主菜单");
            if (Helper.read() == "1")
                borrow();
            return;
        }        
    }
}
