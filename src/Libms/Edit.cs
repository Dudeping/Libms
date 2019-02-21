using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Library_managment_system
{
    class Edit
    {
        public static void edit()
        {
            int flag = 0;
            XDocument xd = XDocument.Load(Helper.Path);
            XElement xe = xd.Element("Books");
            var books = xe.Elements();

            Console.Write("请输入要修改的书名：");
            string editBookName = Console.ReadLine();

            foreach(var item in books)
            {
                if (item.Element("name").Value.Trim() == editBookName)
                {
                    flag = 1;
                    Console.WriteLine("哇，居然真有这本书诶！");
                    Helper.input(item);
                    Console.WriteLine("请输入要修改的选项：1.书名 2.作者 3.价格 4.数量");
                    string option = Helper.read();
                    if(option == "1")
                    {
                        var book = item.Element("name");
                        book.ReplaceWith(new XElement("name", Helper.readString()));
                    }
                    else if(option == "2")
                    {
                        var book = item.Element("author");
                        book.ReplaceWith(new XElement("author", Helper.readString()));
                    }
                    else if (option == "3")
                    {
                        var book = item.Element("price");
                        book.ReplaceWith(new XElement("price", Helper.readString()));
                    }
                    else
                    {
                        var book = item.Element("number");
                        book.ReplaceWith(new XElement("number", Helper.readString()));
                    }

                    Console.WriteLine("修改后的图书信息为：");
                    Helper.input(item);
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("小主，你记错了吧，并没有这本书啊！");
                Console.WriteLine("1.重新输入书名 2.增加此图书 2.返回主菜单");
                string answer = Helper.read();
                if (answer == "1")
                {
                    edit();
                }
                else if(answer == "2")
                {
                    Add.add();
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine("是否保存？1.保存2.不保存");
            if(Helper.read() == "1")
                xd.Save(Helper.Path);

            Console.WriteLine("小主，接下来干什么呢？1.继续修改 2.返回主菜单");
            if (Helper.read() == "1")
                edit();
            return;
        }        
    }
}
