string inputMsg;
int inputNum;

Console.WriteLine("Please enter your message and press enter");
inputMsg = Console.ReadLine();

Console.WriteLine("Please enter a number LESS THAN the length of your string and press enter");
inputNum = int.Parse(Console.ReadLine());

char inputChar;
Console.WriteLine("For which character should I search in your original message?");
inputChar = Console.ReadLine()[0];

Console.WriteLine("Please enter your first name and press enter");
string fName = Console.ReadLine();
Console.WriteLine("Please enter your last name and press enter");
string lName = Console.ReadLine();

Console.WriteLine($"{fName} {lName}");
Console.WriteLine($"{fName[0]}{lName[0]}");
Console.WriteLine(fName + lName[0] + lName[1]);
Console.WriteLine(lName.Length);
