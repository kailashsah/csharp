using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMisc
{

    [Serializable]
    public class Base
    {
        private decimal a = 10m;
        private decimal b = 10m;
        private string str = "get the object size";
    }

    [Serializable]
    public class ObjectSize : Base
    {
        public int i = 40;
        private int e = 50;
        protected int f = 60;
        ~ObjectSize()
        {
            Console.WriteLine("Dtor", GetType().Name);
            PrintSize();
        }

        public void PrintSize()
        {
            long size = 0;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, this);
                size = s.Length;
            }
            Console.WriteLine("ObjectSize class size is :" + size);
        }
    } //ObjectSize

    class DestructorDemo
    {
        public DestructorDemo()
        {
            Console.WriteLine("Constructor Object Created");
        }
        ~DestructorDemo()
        {
            Console.WriteLine($"Object {GetType().Name} is Destroyed");
        }
    }
}
