using System.Reflection;
using static System.Console;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Assembly metadata:");
            Assembly? assembly = Assembly.GetEntryAssembly();
            if (assembly is null)
            {
                WriteLine("Failed to get entry assembly.");
                return;
            }

            WriteLine($"    Full name: {assembly.FullName}");
            WriteLine($"    Location: {assembly.Location}");

            IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();
            WriteLine($"    Assembly-level attributes:");
            foreach (Attribute a in attributes)
            {
                WriteLine($"    {a.GetType()}");
            }
        }
    }
}