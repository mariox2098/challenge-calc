// See https://aka.ms/new-console-template for more information
Console.WriteLine("--- Challenge Calculator ---\n");
var calculator = new Calculator();
var input = "1,2,3,4,5,6,7,8,9,10,11,12";

var result = calculator.Calculate(input);

Console.WriteLine("Input: " + input);
Console.WriteLine("Output: " + result);
