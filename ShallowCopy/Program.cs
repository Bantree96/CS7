using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShallowCopy
{
    public class Camera
    {
        public int No;
        public string Name;

        public Camera ShallowCopy()
        {
            return this.MemberwiseClone() as Camera;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Camera cam = new Camera();
            cam.No = 0;
            cam.Name = "Samsung";

            Camera cam2 = cam.ShallowCopy();
            cam2.No = 1;
            cam2.Name = "Sony";

            Console.WriteLine($"{cam.No} : {cam.Name}");
            Console.WriteLine($"{cam2.No} : {cam2.Name}");

        }
    }
}
