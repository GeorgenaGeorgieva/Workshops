namespace LinkedList
{
    using System;
    using System.Collections.Generic;
    
    public class Program
    {
       public static void Main()
        {
            var stack = new CoolStack();

            stack.Push(2);
            stack.Push(5);
            stack.Push(10);

            Console.WriteLine(stack.Count == 3);

            var value = (int)stack.Pop();

            Console.WriteLine(value == 10);

            Console.WriteLine(stack.Count == 2);

            stack.ForEach(obj => Console.WriteLine(obj));
        }
    }
}
