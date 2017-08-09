using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Facebook;

namespace Reflaction
{
    class Program 
    {
        static void Main(string[] args)
        {
           

        }

        static void Avto()
        {
            string path = @"E:\ProjecktC#\Tank\MyClasssLibrery\bin\Debug\MyClasssLibrery.dll";

            Assembly assembly = Assembly.LoadFrom(path);
            IEnumerable<Type> list = assembly.ExportedTypes;
            List<Type> classes = new List<Type>();
            Type inter = null;

            foreach (Type s in list)
            {
                if (s.IsInterface)
                {
                    inter = s;
                }
                else
                {
                    classes.Add(s);
                }

            }
            foreach (Type s in classes)
            {
                MethodInfo[] meth = s.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

                foreach (MethodInfo m in meth)
                {
                    Console.WriteLine(m.Name);
                }
            }

            foreach (Type s in classes)
            {
                MethodInfo[] meth = s.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                object obj = assembly.CreateInstance("MyClasssLibrery." + s.Name);
                foreach (MethodInfo m in meth)
                {
                    try
                    {
                        // var item = m.GetMethodBody().ToString();
                        m.GetCustomAttributes(s);

                        // var qwwe = s.GetMethod(m.Name).Invoke(obj, null);


                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Class " + s + "  Method " + m + "Не реализовано");
                    }

                }
            }
            //foreach (Type s in list)
            //{
            //    if (s.)
            //    {
            //        inter = s;
            //    }
            //}


            // Type printerType = tankPrinterInstance.GetType();

            //MemberTypes types= tankPrinterInstance.GetT


            // printerType.GetMethod("Print").Invoke(tankPrinterInstance, new object[] { "Printer Method invokes!!!!" });



            Type t = typeof(ReflectionTestClass);
            //foreach(RoleInfo s in t.GetCustomAttributes(false))
            //{
            //    Console.WriteLine();
            //}
            Console.ReadKey();

        }

       
    }

}
