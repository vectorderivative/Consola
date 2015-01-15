using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Xml;

namespace Utils
{
    public class Consola
    {
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out int mode);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetStdHandle(int handle);

        const int STD_INPUT_HANDLE = -10;
        const int ENABLE_QUICK_EDIT_MODE = 0x40 | 0x80;

        public static void EnableQuickEditMode()
        {
            int mode;
            IntPtr handle = GetStdHandle(STD_INPUT_HANDLE);
            GetConsoleMode(handle, out mode);
            mode |= ENABLE_QUICK_EDIT_MODE;
            SetConsoleMode(handle, mode);
        }

        public static void Divisor(string message)
        {
            int i = 0;
            int width = Console.WindowWidth - (message.Length*2); 
            while (i < width)
            {
                if (i == width / 2)
                {
                    Console.Write(DivisorMessage(message));
                }
                else
                {
                    Console.Write("+");
                }
                i++;
            }
            Console.WriteLine(Environment.NewLine);
        }

        public static string DivisorMessage(string message)
        {
            string newMessage = " ";
            int i = 0;
            while (i < message.Length)
            {
                newMessage += message[i] + " ";
                i++;
            }

            return newMessage;
        }

        public static void WriteXML(string xmlString)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlString);
            XmlTextWriter writer = new XmlTextWriter(Console.Out);
            writer.Formatting = Formatting.Indented;
            xml.WriteTo(writer);
            writer.Flush();
            Console.WriteLine();
        }

        public static void WriteXML(XmlDocument xml)
        {
            XmlTextWriter writer = new XmlTextWriter(Console.Out);
            writer.Formatting = Formatting.Indented;
            xml.WriteTo(writer);
            writer.Flush();
            Console.WriteLine();
        }
    }
}
