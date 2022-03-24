using static System.Console;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            A anA = new A("i'm an A.");
            B aB = new B("i'm a B.", "extra info in B");
            anA.print();
            aB.print();
            A x = aB;
            x.print();
        }
    }

    class A
    {
        private string a;
        public A(string a)
        {
            this.a = a;
        }
        public virtual void print()
        {
            WriteLine(a);
        }
    }

    class B : A
    {
        private string b;
        public B(string a, string b) : base(a)
        {
            this.b = b;
        }
        public override void print()
        {
            base.print();
            WriteLine(b);
        }
    }
}
