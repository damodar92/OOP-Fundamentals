using System;

namespace DelegateCarProject
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Console.WriteLine("***** Delegates as event enablers *****\n");
			// First, make a Car object.
			Car c1 = new Car("SlugBug", 100, 10);
            // Now, tell the car which method to call
            // when it wants to send us messages.

            Car.CarEngineHandler CCE = new Car.CarEngineHandler(OnCarEngineEvent);
            //Tell the RegisterWithCarEngine to use OnCarengineEvent to print the messages.
			c1.RegisterWithCarEngine(CCE);
			// Speed up (this will trigger the events).
			Console.WriteLine("***** Speeding up *****");
			for (int i = 0; i < 6; i++)
				c1.Accelerate(20);
			Console.ReadLine();
        }
		public static void OnCarEngineEvent(string msg)
		{
			Console.WriteLine("\n***** Message From Car Object *****");
			Console.WriteLine("=> {0}", msg);
			Console.WriteLine("***********************************\n");
		}
    }
	public class Car
	{
		// Internal state data.
		public int CurrentSpeed { get; set; }
		public int MaxSpeed { get; set; } = 100;
		public string PetName { get; set; }
		// Is the car alive or dead?
		private bool carIsDead;
		// Class constructors.
		public Car() { }
		public Car(string name, int maxSp, int currSp)
		{
			CurrentSpeed = currSp;
			MaxSpeed = maxSp;
			PetName = name;
		}
		// 1) Define a delegate type.
		public delegate void CarEngineHandler(string msgForCaller);

		// 2) Define a member variable of this delegate.
		private CarEngineHandler listOfHandlers;

		// 3) Add registration function for the caller.
		public void RegisterWithCarEngine(CarEngineHandler methodToCall)
		{
			listOfHandlers = methodToCall;
		}

		public void Accelerate(int delta)
		{
			// If this car is "dead," send dead message.
			if (carIsDead)
			{
				if (listOfHandlers != null)
					//listOfHandlers has been already pointed to the method OnCarEngineEvent in the main function
					//So the printing will take place from that method. 
                    //listOfHandlers takes string as the input as it of the delegate type defined above. 
					listOfHandlers("Sorry, this car is dead...");
			}
			else
			{
				CurrentSpeed += delta;
				// Is this car "almost dead"?
				if (10 == (MaxSpeed - CurrentSpeed)
					&& listOfHandlers != null)
				{
					//listOfHandlers has been already pointed to the method OnCarEngineEvent in the main function
                    //So the printing will take place from that method. 
					listOfHandlers("Careful buddy! Gonna blow!");
				}
				if (CurrentSpeed >= MaxSpeed)
					carIsDead = true;
				else
					Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
			}
		}
	}
}
