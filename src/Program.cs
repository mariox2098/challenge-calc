using Microsoft.Extensions.Configuration;

Console.WriteLine("--- Challenge Calculator ---\n");
var calculator = new Calculator();

var configuration = new ConfigurationBuilder()
   .AddCommandLine(args)
   .Build();

calculator.SetOperation(configuration.GetSection("Operation").Value);
calculator.SetAltDelimiter(configuration.GetSection("AltDelimeter").Value);

if(bool.TryParse(configuration.GetSection("DenyNegative").Value, out var denyNegative))
{
    calculator.SetDenyNegative(denyNegative);
}

if (int.TryParse(configuration.GetSection("UpperNumBound").Value, out var upperBound))
{
    calculator.SetUpperNumBound(upperBound);
}

var inputs = new List<string>
{
    "-5,-6,343,1200",
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
