using System.Text.RegularExpressions;

Console.WriteLine("--- Challenge Calculator ---\n");
var calculator = new Calculator();
var input = "//,\n2,ff,100";

var result = calculator.Calculate(input);

Console.WriteLine("Input: " + input);
Console.WriteLine("Output: " + result);
