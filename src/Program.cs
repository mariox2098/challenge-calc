// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("--- Challenge Calculator ---\n");
var calculator = new Calculator();
var input = "2,1001,6";

var result = calculator.Calculate(input);

Console.WriteLine("Input: " + Regex.Escape(input));
Console.WriteLine("Output: " + result);
