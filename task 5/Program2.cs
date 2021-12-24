using ClassLibrary;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace task5
{
    class Program2
    {
        static void Main(string[] args)
        {
            /*List<IDevice> devices = new List<IDevice>();
            DigitalCamera digitalCamera = new DigitalCamera("Canon", "EOS M6", 24.2, 16, LensType.MIRRORLESS, 3);
           
            devices.Add(new DigitalCamera("Canon", "EOS M6",24.2 , 16, LensType.MIRRORLESS, 3));
            devices.Add(new DigitalCamera("Nikon", "D780", 24.5, 64, LensType.MIRROR, 3.2));
            foreach (IDevice d in devices)
            {
                d.getParameters();
                
            }*/
            Assembly asm = Assembly.LoadFrom("ClassLibrary.dll");
            
            Type[] types = asm.GetTypes();
          
            foreach (Type t in types)
            {  if (t.GetInterface("IDevice") != null && t.IsSubclassOf(typeof(Camera)))
                {
                    Console.WriteLine(t.Name);
                    Console.WriteLine();
                    foreach (MethodInfo method in t.GetMethods())
                    {
                        object obj = Activator.CreateInstance(t);
                        if (method.Name != "GetType" && method.Name != "ToString" && method.Name != "Equals" && method.Name != "GetHashCode")
                        {
                            Console.WriteLine(method.Name);
                            
                        }
                        
                    }
                    Console.WriteLine("------------------------");
                }
            }
            

           
        }
    }
}
