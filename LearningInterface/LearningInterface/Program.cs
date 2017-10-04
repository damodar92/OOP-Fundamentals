using System;

namespace LearningInterface
{
	public interface IDrawToForm
	{
		void Draw();
	}
	// Draw to buffer in memory.
	public interface IDrawToMemory
	{
		void Draw();
	}
	// Render to the printer.
	public interface IDrawToPrinter
	{
		void Draw();
	}
	
    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
	{
		public void Draw()
		{
			// Shared drawing logic.
			Console.WriteLine("Drawing the Octagon...");
		}
	}
    class MainClass{
		static void Main(string[] args)
		{
			Console.WriteLine("***** Fun with Interface Name Clashes *****\n");
			// All of these invocations call the // same Draw() method!
			Octagon oct = new Octagon();
			IDrawToForm itfForm = (IDrawToForm)oct;
			itfForm.Draw();
			IDrawToPrinter itfPriner = (IDrawToPrinter)oct;
			itfPriner.Draw();
			IDrawToMemory itfMemory = (IDrawToMemory)oct;
			itfMemory.Draw();
			Console.ReadLine();
		}
    }

}
