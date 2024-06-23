using System.Text.RegularExpressions;

Console.WriteLine("--- Challenge Calculator ---\n");
var calculator = new Calculator();

var inputs = new List<string>
{
    "20",
    "1,5000",
    "5,tytyt",
    "1,2,3,4,5,6,7,8,9,10,11,12",
    "1\n2,3",
    "2,1001,6",
    "//#\n2#5",
    "//,\n2,ff,100",
    "//[***]\n11***22***33",
    "//[*][!!][r9r]\n11r9r22*hh*33!!44"
};

foreach (var input in inputs)
{
    Console.WriteLine("Input: " + input);
    var result = calculator.Calculate(input);
    Console.WriteLine();
}
