using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Library_managment_system
{
    class AddDefaultBook
    {
        /// <summary>
        /// 添加默认图书
        /// </summary>
        public static void Add()
        {
            string[] name = new string[10];
            name[0] = "山居笔记";
            name[1] = "文化苦旅";
            name[2] = "行者无疆";
            name[3] = "千年之叹";
            name[4] = "君子之道";
            name[5] = "寻觅中华";
            name[6] = "看见";
            name[7] = "家";
            name[8] = "春";
            name[9] = "秋";
            string[] author = new string[10];
            author[0] = "余秋雨";
            author[1] = "余秋雨";
            author[2] = "余秋雨";
            author[3] = "余秋雨";
            author[4] = "余秋雨";
            author[5] = "余秋雨";
            author[6] = "柴静";
            author[7] = "巴金";
            author[8] = "巴金";
            author[9] = "巴金";
            string[] price = new string[10];
            price[0] = "50";
            price[1] = "50";
            price[2] = "50";
            price[3] = "50";
            price[4] = "50";
            price[5] = "50";
            price[6] = "40";
            price[7] = "30";
            price[8] = "30";
            price[9] = "30";
            int i = 0;
            var s = Enumerable.Range(1, 10);
            XDocument xdoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Books",
                    from item in s
                    select new XElement("book",
                    new XElement("name", name[i]),
                    new XElement("author", author[i]),
                    new XElement("price", price[i++]),
                    new XElement("number", "5")
                )));
            xdoc.Save(Helper.Path);
            Console.WriteLine("初始化完成！");
        }
    }
}
