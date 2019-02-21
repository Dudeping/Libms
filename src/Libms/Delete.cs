using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library_managment_system
{
    class Delete
    {
        public static void delete()
        {
            int flag = 0;
            XDocument xd = XDocument.Load(Helper.Path);
            XElement xe = xd.Element("Books");
            var books = xe.Elements();

            Console.Write("请输入要删除的书名：");
            string editBookName = Console.ReadLine();

            var book = from x in books
                       where x.Element("name").Value.Trim() == editBookName
                       select x;

            foreach (var item in books)
            {
                if (item.Element("name").Value.Trim() == editBookName)
                {
                    flag = 1;
                    Console.WriteLine("哇，居然真有这本书诶！\n但是........\n小主，你真的要删除么？1.删除 2.不删");
                    if(Helper.read() == "1")
                        item.Remove();
                    
                    Console.WriteLine("已删除！\n删除的的图书信息为：");
                    Helper.input(item);
                }
            }

            if(flag == 0)
            {
                Console.WriteLine("糟糕，没有找到图书！");
                Console.WriteLine("1.重新输入书名 2.返回主菜单");
                if (Helper.read() == "1")
                {
                    delete();
                }
                else
                {
                    return;
                }
            }

            xd.Save(Helper.Path);
            Console.WriteLine("小主，接下来干什么呢？1.继续删除 2.返回主菜单");
            if (Helper.read() == "1")
                delete();
            return;
        }        
    }
}
