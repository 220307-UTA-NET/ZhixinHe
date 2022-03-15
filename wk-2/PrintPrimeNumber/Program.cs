Console.Write("Please enter a number <larger than 2>: ");
int numUpperRange = int.Parse(Console.ReadLine());

Console.WriteLine($"The prime numbers not bigger than {numUpperRange} listed below:");

int i = 0;
int j = 0;
int n = 0;
const int NLINE = 10;
for (i = 2; i <= numUpperRange; i++)
{
    for (j = 2; j <= i/j ; j++)
    {
        if (i%j == 0) break;
    }
    if (j > i/j) 
    {
        if (n%NLINE == 0) Console.WriteLine();
        Console.Write(format:"{0,10}", arg0:i);
        n++;
    }
}
