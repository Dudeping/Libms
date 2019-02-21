using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Library_managment_system
{
    class Check
    {
        public static int check()
        {
            Int32 i = 0;
            XDocument xd = XDocument.Load(Helper.Path);
            XElement xe = xd.Element("Books");
            var books = xe.Elements();

            Console.WriteLine("现藏图书：");
            foreach(var item in books)
            {
                if(item.Element("name").Value.Trim() == "")
                    Console.WriteLine(item.Element("name").Value.Trim());
                else
                {
                    Console.WriteLine("<<" + item.Element("name").Value.Trim() + ">>");
                    i++;
                }
            }
            Console.WriteLine();
            return i;
        }
    }
}
