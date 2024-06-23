// See https://aka.ms/new-console-template for more information
Console.WriteLine("--- Challenge Calculator ---\n");
var calculator = new Calculator();
var input = "5,tytyt";

var result = calculator.Calculate(input);

Console.WriteLine("Input: " + input);
Console.WriteLine("Output: " + result);
