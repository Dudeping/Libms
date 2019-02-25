using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Libms
{
    class Add
    {
        public static void add()
        {
            string name, author, price, number;
            XDocument xd = XDocument.Load(Helper.Path);
            XElement xe = xd.Element("Books");
            var books = xe.Elements();

            Console.WriteLine("请输入图书信息：");
            Console.Write("请输入书名：");
            name = Console.ReadLine();

            foreach (var item in books)
            {
                if(item.Element("name").Value.Trim() == name)
                {
                    Console.WriteLine("此书已有，请输入添加的数量：");
                    var num = Convert.ToInt32(Console.ReadLine()); 
                    var sb = item.Element("number");
                    sb.ReplaceWith(new XElement("number", Convert.ToInt32(sb.Value.Trim()) + num));
                    xd.Save(Helper.Path);
                    Console.WriteLine("1.继续添加 2.返回主菜单");
                    if (Helper.read() == "1")
                        add();
                    return;
                }
            }
            Console.Write("请输入作者：");
            author = Console.ReadLine();
            Console.Write("请输入价格：");
            price = Console.ReadLine();
            Console.Write("请输入数量：");
            number = Console.ReadLine();
            Console.WriteLine();

            var book = xe.Elements("book").FirstOrDefault();
            XElement xe_add = new XElement(
                "book",
                 new XElement("name", name),
                 new XElement("author", author),
                 new XElement("price", price),
                 new XElement("number", number)
                 );
            Console.WriteLine("添加的图书信息为：");
            Helper.input(xe_add);

            Console.WriteLine("是否添加？1.重新输入 2.添加 ");
            if (Helper.read() == "1")
                add();

            book.AddBeforeSelf(xe_add);
            xd.Save(Helper.Path);

            Console.WriteLine("1.继续添加 2.返回主菜单");
            if (Helper.read() == "1")
                add();
            return;
        }        
    }
}
