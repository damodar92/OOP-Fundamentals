using System;
using System.Numerics;
using System.Text;
using System.Linq;


namespace CSharp
{
    class PointRef
    {
		class Person
		{
			public string personName;
			public int personAge;
			// Constructors.
			public Person(string name, int age)
			{
				personName = name;
				personAge = age;
			}
			public Person() { }
			public void Display()
			{
				Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
			}
		}


		static void SendAPersonByValue(Person p)
		{
			// Change the age of "p"?
			p.personAge = 99;
			// Will the caller see this reassignment?
			p = new Person("Nikki", 99);
		}
		static void TesterMethod(string[] args)
		{
			// We should check for null before accessing the array data!
			if (args != null)
			{
				Console.WriteLine($"You sent me {args.Length} arguments.");
			}
		}


		static void Main(string[] args)
		{
			// Passing ref-types by value.
			
            TesterMethod(null);
		}
    }
}

