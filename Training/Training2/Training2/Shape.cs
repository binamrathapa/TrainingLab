using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training2
{
    public abstract class Shape
    {
        public abstract string DrawShape();
    }

    public class Circle:Shape
    {
        public override string DrawShape()
        {
            return "this is circle";
        }

        public string DrawShape(string a)
        {
            return "this is overload";
        }

    }
}
