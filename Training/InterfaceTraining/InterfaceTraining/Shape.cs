using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTraining
{
    public interface Shape
    {        
        string DrawShape(string type, int width,int height);
    }

    public class Rectangle : Shape
    {
        public string DrawShape(string type, int width, int height)
        {
            return "It is rectangle with: "+width+"\n height:"+height;
        }
    }
    public class Circle : Shape
    {
        public string DrawShape(string type, int width, int height)
        {
            return "It is cicle with: " + width + "\n height:" + height;
        }
    }

    public abstract class TestFactory
    {
        public abstract Shape GetShape(string type);
    }

    public class Factory : TestFactory
    {
        public override Shape GetShape(string type)
        {
            if (type.Equals("circle"))
                return new Circle();
            else
                return new Rectangle();
        }
    }
}
