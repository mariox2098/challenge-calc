// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("--- Challenge Calculator ---\n");
var calculator = new Calculator();
var input = "1\n2,3,-1,-3,1";

var result = calculator.Calculate(input);

Console.WriteLine("Input: " + Regex.Escape(input));
Console.WriteLine("Output: " + result);
