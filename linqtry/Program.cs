using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();

        // var tmp = s.Where(c => c >= 'A' && c <= 'Z');
// 
        // Console.WriteLine(tmp);

        Console.WriteLine(s.Split(' ').Reverse().ToArray().ToString());

    }
}