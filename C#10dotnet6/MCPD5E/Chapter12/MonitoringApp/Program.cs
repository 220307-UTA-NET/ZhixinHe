using MonitoringLib;
using static System.Console;

int[] numbers = Enumerable.Range(start: 1, count: 50000).ToArray();

WriteLine("Processing. Using string with + ...");
Recorder.Start();
string s = string.Empty;
for (int i = 0; i < numbers.Length; i++)
{
    s += numbers[i] + ", ";
}
Recorder.stop();
WriteLine("Processing. Using StringBuilder ...");
Recorder.Start();
System.Text.StringBuilder builder = new();
for (int i = 0; i < numbers.Length; i++)
{
    builder.Append(numbers[i]);
    builder.Append(",");
}
Recorder.stop();