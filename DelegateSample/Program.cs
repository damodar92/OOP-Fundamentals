using System;

namespace DelegateSample
{
    public delegate int BinaryOp(int x, int y);

    class MainClass
    {
        public static void Main(string[] args)
        {
            BinaryOp binOpAdd = new BinaryOp(BinaryOperations.Add);
            BinaryOp binOpSub = new BinaryOp(BinaryOperations.subtract);
            Console.WriteLine("Sum: "+binOpAdd(10,10));
            Console.WriteLine("Difference: "+binOpSub(20,10));
            BinaryOperations.DelegateInvestigation(binOpAdd);
            Console.ReadLine();
        }
    }
    class BinaryOperations{
        public static int Add(int a, int b){
            return a + b;
        }
        public static int subtract(int a, int b){
            return a - b;
        }

        public static void DelegateInvestigation(Delegate delObj){
            foreach(Delegate del in delObj.GetInvocationList()){
                Console.WriteLine("Info on Delegates: " + del.Method);
                Console.WriteLine("Info: "+del.Target);
            }


        }
    }
}
