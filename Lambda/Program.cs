using System;

namespace Lambda
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			// Register with delegate as a lambda expression.
			SimpleMath m = new SimpleMath();
			m.SetMathHandler((msg, result) =>
			  { Console.WriteLine("Message: {0}, Result: {1}", msg, result); });
			// This will execute the lambda expression.
			m.Add(10, 10);

			Console.ReadLine();
        }
    }
	public class SimpleMath
	{
        
		public delegate void MathMessage(string msg, int result);

		private MathMessage mmDelegate;
		public void SetMathHandler(MathMessage target)
		{ mmDelegate = target; 
            Console.WriteLine("Inside SetMathHandler: "+target.GetInvocationList());
        }
		public void Add(int x, int y)
		{
            Console.WriteLine("Simple Add Method");
			mmDelegate?.Invoke("Adding has completed!", x + y);
		}
	}
}
