using System;
namespace CSharp
{
	class PointRef
	{
        public int Y;
        public int X;
		// Same members as the Point structure...
		// Be sure to change your constructor name to PointRef!
		public PointRef(int XPos, int YPos)
		{
			X = XPos;
			Y = YPos;
		}
		
		public void Increment()
		{
			X++; Y++;
		}
		// Subtract 1 from the (X, Y) position.
		public void Decrement()
		{
			X--; Y--;
		}
		// Display the current position.
		public void Display()
		{
			Console.WriteLine("X = {0}, Y = {1}", X, Y);
		}

		static void ReferenceTypeAssignment()
		{
			Console.WriteLine("Assigning reference types\n");
			PointRef p1 = new PointRef(10, 10);
			PointRef p2 = p1;
			// Print both point refs.
			p1.Display();
			p2.Display();
			// Change p1.X and print again.
			p1.X = 100;
			Console.WriteLine("\n=> Changed p1.X\n");
			p1.Display();
			p2.Display();
		}
		

	}
}
