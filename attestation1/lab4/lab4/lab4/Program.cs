using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Xml.Serialization;
namespace lab4
{
    class MainClass
    {
        static void f1(Complex s)
        {
            FileStream fs = new FileStream(@"complex.asd", FileMode.Create, FileAccess.Write);
            BinaryFormatter  bf = new BinaryFormatter();

            try
            {
                bf.Serialize(fs, s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

            Console.WriteLine("done");
        }


        static void f2()
        {
            FileStream fs = new FileStream(@"complex.asd", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                Complex s = bf.Deserialize(fs) as Complex;

                Console.WriteLine(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }


        }
        /*static void f3(Complex s){
            FileStream fs = new FileStream(@"complex.xml", FileMode.Open, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            try
            {
                xs.Serialize(fs, s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine("Done"); 

        }
        static void f4()
        {
            FileStream fs = new FileStream(@"complex.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            try
            {
                Complex s= xs.Deserialize(fs) as Complex;
                Console.WriteLine(s); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        */
        public static void Main(string[] args)
        {
            Complex s = new Complex(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            f1(s);
            f2();
            //f3(s);
           // f4();
            Console.ReadKey(); 
        }
    }
}
