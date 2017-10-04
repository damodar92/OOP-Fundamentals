using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;

namespace Generics
{
    class GenericsList
    {
        public static void ListMethod(){
			List<Person> people = new List<Person>()
		{
			new Person(){FirstName="Ajay", LastName="Ajay", Age=25},
			new Person(){FirstName="Varun", LastName="Varun", Age=25}
		};
            Console.WriteLine("Total Items in the list: "+people.Count);
			foreach (Person p in people)
			{
				Console.WriteLine(p.ToString());
			}
            Console.WriteLine("Inserting new item in the list");
            people.Insert(2, new Person { FirstName = "Damodar", LastName = "Bhat", Age = 25 });

            Console.WriteLine();
            Console.WriteLine("Total items in the list: "+people.Count);
            foreach(Person p in people){
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Converting List to Array format and printing");
            Person[] newPeople = people.ToArray();
            for(int p = 0; p < newPeople.Length; p++){
                
                Console.WriteLine("First Name: " + newPeople[p].FirstName);
            }
        }
     
    }
    class GenericsStack{
        public static void StackMethod()
        {
            Stack<Person> sPeople = new Stack<Person>();
            sPeople.Push(new Person() { FirstName = "Ghanshyam", LastName = "Bhat", Age = 27 });
            sPeople.Push(new Person() { FirstName = "Vasudeva", LastName = "Bhat", Age = 59 });
            try{
				Console.WriteLine("Item that is at the top: " + sPeople.Peek());
				Console.WriteLine("Popped Item is : " + sPeople.Pop());
				Console.WriteLine("Item that is at the top: " + sPeople.Peek());
				Console.WriteLine("Popped Item is : " + sPeople.Pop());
				Console.WriteLine("Item that is at the top: " + sPeople.Peek());
				Console.WriteLine("Popped Item is : " + sPeople.Pop());
            }
            catch(InvalidOperationException ex){
                Console.WriteLine("Error !: "+ex.Message);
                try{
                    sPeople.Push(new Person() { FirstName = "Gayathri", LastName = "Bhat", Age = 53 });
					Console.WriteLine("Item that is at the top: " + sPeople.Peek());
					Console.WriteLine("Popped Item is : " + sPeople.Pop());
					Console.WriteLine("Item that is at the top: " + sPeople.Peek());
					Console.WriteLine("Popped Item is : " + sPeople.Pop());
                }
                catch(InvalidOperationException ex1){
                    Console.WriteLine("Error Again! : "+ex1.Message);
                }
            }

        }

    }
    class GenericsQueue{
        public static void QueueMethod(){
            Queue<Person> qPeople = new Queue<Person>();
            qPeople.Enqueue(new Person(){FirstName = "Ramadas", LastName = "Kamath", Age = 56 });
            qPeople.Enqueue(new Person() { FirstName = "Srimati", LastName = "Nayak", Age = 50 });
            try{
                Console.WriteLine("The first Person in Queue is: "+qPeople.Peek());
                qPeople.Dequeue();
				Console.WriteLine("The second Person in Queue is: " + qPeople.Peek());
				qPeople.Dequeue();
				Console.WriteLine("The third Person in Queue is: " + qPeople.Peek());
				qPeople.Dequeue();

            }
            catch(InvalidOperationException ex2){
                Console.WriteLine("Error!: "+ex2.Message);
            }
        }
    }

	class GenericSortedSet : IComparer<Person>
	{
        public int Compare(Person firstPerson, Person secondPerson)
		{
			if (firstPerson.Age > secondPerson.Age)
				return 1;
			if (firstPerson.Age < secondPerson.Age)
				return -1;
			else
				return 0;
		}
		public static void SortedMethod()
		{
            SortedSet<Person> sortPerson = new SortedSet<Person>(new GenericSortedSet()){
                new Person(){FirstName= "Homer", LastName="Simpson", Age=47}
            };
			sortPerson.Add(new Person() { FirstName = "Swathi", LastName = "Kamath", Age = 31 });
			sortPerson.Add(new Person() { FirstName = "Mahesh", LastName = "Kamath", Age = 35 });
			sortPerson.Add(new Person() { FirstName = "Anjali", LastName = "Kamath", Age = 1 });
            foreach(Person p in sortPerson){
                Console.WriteLine(p);
            }
		}

	}
    class GenericDictionary
    {
        public static void DictionaryMethod()
        {
            Dictionary<string, Person> dPeople = new Dictionary<string, Person>();
            dPeople.Add("P", new Person() { FirstName = "Swathi", LastName = "Bhat", Age = 31 });
            dPeople.Add("Q", new Person() { FirstName = "Ramani", LastName = "Bhat", Age = 53 });
            foreach (KeyValuePair<string, Person> p in dPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
            Console.WriteLine("Second Implementation: Populate with initialization syntax.");
            //Another way of initializing dictionary.
            Dictionary<string, Person> dPeople1 = new Dictionary<string, Person>(){
                { "Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 } },
                 { "Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 } },
                { "Lisa",  new Person { FirstName = "Lisa",  LastName = "Simpson", Age = 9 } }

            };
			foreach (KeyValuePair<string, Person> p in dPeople1)
			{
				Console.WriteLine(p);
			}
            Console.WriteLine();
            Console.WriteLine("Third Implementation: // Populate with dictionary initialization syntax.");
			Dictionary<string, Person> dPeople2 = new Dictionary<string, Person>()
			{
				["A1"] = new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
				["A2"] = new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
				["A3"] = new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 }
			};
			foreach (KeyValuePair<string, Person> p in dPeople2)
			{
				Console.WriteLine(p);
			}
        }
    }
    class GenericsObservable{
        public static void ObservableMethod(){
            ObservableCollection<Person> obsPeople = new ObservableCollection<Person>(){
                new Person(){FirstName="John", LastName="Dcosta", Age=30},
                new Person(){FirstName="Oliver",LastName="Pope",Age=43}
            };
            obsPeople.CollectionChanged += people_CollectionChanged;
            obsPeople.Add(new Person(){FirstName="Abhishek", LastName="Someone", Age=35});
            obsPeople.Remove(new Person() { FirstName="John", LastName="Dcosta", Age=30});
        }

		public enum NotifyCollectionChangedAction
		{
			Add = 0,
			Remove = 1,
			Replace = 2,
			Move = 3,
			Reset = 4,
		}

		static void people_CollectionChanged(object sender,
        System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			// What was the action that caused the event?
			Console.WriteLine("Action for this event: {0}", e.Action);
			// They removed something.
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
			{
				Console.WriteLine("Here are the OLD items:");
				foreach (Person p in e.OldItems)
				{
					Console.WriteLine(p.ToString());
				}
				Console.WriteLine();
			}
			// They added something.
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
			{
				// Now show the NEW items that were inserted.
				Console.WriteLine("Here are the NEW items:");
				foreach (Person p in e.NewItems)
				{
					Console.WriteLine(p.ToString());
				}
			}
		}
    }
	class Person
	{
		public string FirstName;
		public string LastName;
		public int Age;

        public string Fn{
            get{
                return FirstName;
            }
            set{
                FirstName = value;
            }
        }
        public string Ln{
            get{
                return LastName;
            }
            set{
                LastName = value;
            }
        }
        public int personAge{
            get{
                return Age;

            }
            set{
                Age = value;
            }

        }
        public override string ToString()
        {
            return this.FirstName + " , "+ this.LastName + " "+ this.Age;
        }

	}
    class MainClass{
        public static void Main (){
            Console.WriteLine("Implementing LIST<T>");
            GenericsList.ListMethod();
            Console.WriteLine("---------------------------");
            Console.WriteLine("");

            Console.WriteLine("Implementing STACK<T>");
            GenericsStack.StackMethod();
			Console.WriteLine("---------------------------");
			Console.WriteLine("");

			Console.WriteLine("Implementing QUEUE<T>");
            GenericsQueue.QueueMethod();
			Console.WriteLine("---------------------------");
			Console.WriteLine("");

			Console.WriteLine("Implementing SORTEDSET<T>");
            GenericSortedSet.SortedMethod();
			Console.WriteLine("---------------------------");
			Console.WriteLine("");

			Console.WriteLine("Implementing DICTIONARY<Tkey, Tvalue>");
            GenericDictionary.DictionaryMethod();
			Console.WriteLine("---------------------------");
			Console.WriteLine("");

            Console.WriteLine("Implementing OBSERVABLECOLLECTION<T>");
            GenericsObservable.ObservableMethod();

            Console.ReadLine();

        }
    }
}

