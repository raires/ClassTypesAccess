using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassTypes;

namespace ClassTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Same Assembly Base Class");
            Console.WriteLine("////////////////////////////////////////");
            SameAssemblyBaseClass sameAssemblyBaseClass = new SameAssemblyBaseClass();
            sameAssemblyBaseClass.test();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Same Assembly Derived Class");
            Console.WriteLine("////////////////////////////////////////");
            SameAssemblyDerivedClass sameAssemblyDerivedClass = new SameAssemblyDerivedClass();
            sameAssemblyDerivedClass.test();



            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Same Assembly Different Class");
            Console.WriteLine("////////////////////////////////////////");
            SameAssemblyDifferentClass sameAssemblyDifferentClass = new SameAssemblyDifferentClass();
            sameAssemblyDifferentClass.ToString();

            Console.ReadLine();
        }
    }





    public class SameAssemblyBaseClass
    {
        public string publicVariable = "public";
        protected string protectedVariable = "protected";
        protected internal string protectedInternalVariable = "protected internal";
        internal string internalVariable = "internal";
        private string privateVariable = "private";
        public void test()
        {
            // OK
            Console.WriteLine(privateVariable);
            // OK
            Console.WriteLine(publicVariable);
            // OK
            Console.WriteLine(protectedVariable);
            // OK
            Console.WriteLine(internalVariable);
            // OK
            Console.WriteLine(protectedInternalVariable);
        }
    }

    public class SameAssemblyDerivedClass : SameAssemblyBaseClass
    {
        public void test()
        {
            SameAssemblyDerivedClass p = new SameAssemblyDerivedClass();

            // NOT OK -- Console.WriteLine(privateVariable);
            Console.WriteLine("ERROR: 'SameAssemblyBaseClass.privateVariable' is inaccessible due to its protection level");
            // OK
            Console.WriteLine(p.publicVariable);
            // OK
            Console.WriteLine(p.protectedVariable);
            // OK
            Console.WriteLine(p.internalVariable);
            // OK
            Console.WriteLine(p.protectedInternalVariable);
        }
    }

    public class SameAssemblyDifferentClass
    {
        public SameAssemblyDifferentClass()
        {
            SameAssemblyBaseClass p = new SameAssemblyBaseClass();

            // OK
            Console.WriteLine(p.publicVariable);
            // OK
            Console.WriteLine(p.internalVariable);
            // NOT OK -- Console.WriteLine(privateVariable);
            Console.WriteLine("ERROR: The name 'privateVariable' does not exist in the current context");
            // NOT OK -- Console.WriteLine(p.protectedVariable);
            Console.WriteLine("ERROR: 'SameAssemblyBaseClass.protectedVariable' is inaccessible due to its protection level");
            // OK
            Console.WriteLine(p.protectedInternalVariable);
        }
    }
}



