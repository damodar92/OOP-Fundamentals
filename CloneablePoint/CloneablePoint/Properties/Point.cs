using System;
using System.Collections;

namespace CloneablePoint.Properties
{
    public class Color{
        public string MyColor
        {
            get;
            set;
        }
    }
    public class Point: ICloneable
	{
		public int X { get; set; }
		public int Y { get; set; }
        //Reference type of Color class
        public Color myCol = new Color();
        public Point(int xPos, int yPos, string col) { 
            X = xPos; 
            Y = yPos;
            myCol.MyColor = col;
        }
		public Point() { 
        }
		// Override Object.ToString().
		public override string ToString()
		{ 
            return string.Format("X = {0}; Y = {1}", X, Y); 
        }
        public object Clone(){
            Point pObj = (Point)this.MemberwiseClone();

            Color cObj = new Color();
            myCol.MyColor= this.myCol.MyColor;

            pObj.myCol = cObj;
            return pObj;
        }
	}
	
    public class MainClass{
		static void Main(string[] args)
		{
			Console.WriteLine("***** Fun with Object Cloning *****\n");
			// Two references to same object!
			Point p1 = new Point(50, 50,"Red");
            //p1.myCol.MyColor = "Red";
            Point p2 = (Point)p1.Clone();
			p2.X = 0;
            p2.myCol.MyColor = "Yellow";
            Console.WriteLine("Object 1: "+p1+" Color: "+p1.myCol.MyColor);
            Console.WriteLine("Object 2: "+p2+" Color: "+p2.myCol.MyColor);
			Console.ReadLine();


		}
    }
}
