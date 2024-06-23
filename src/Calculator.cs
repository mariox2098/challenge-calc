// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using System.Linq;

public class Calculator
{
    private List<string> _delimiters = ["\n", ","];
    private List<string> _customDelimiters = [];
    private readonly string CustomDelimiterRegex = @"(?:\[(.+?)\]+)|(.*)";

    public Calculator()
    {

    }

    public int Calculate(string inputString)
    {
        inputString = ParseCustomDelimiter(inputString);
        var numbers = ParseStringToNumbers(inputString);
        var output = RunOperation(numbers);
        return output;
    }

    public string[] GetDelimiters()
    {
        return _delimiters.Concat(_customDelimiters).Distinct().ToArray();
    }
    public string ParseCustomDelimiter(string inputString)
    {
        var newInputString = inputString;
        _customDelimiters.Clear();
        if (inputString.StartsWith("//"))
        {
            var splitString = inputString.Split('\n', 2);
            if (splitString != null && splitString.Length == 2)
            {
                var customDelimiterPart = splitString[0].Substring(2);
                var r = Regex.Matches(customDelimiterPart, CustomDelimiterRegex);
                _customDelimiters.AddRange(
                    r.Where(x => x.Success && !string.IsNullOrWhiteSpace(x.Value))
                    .Select(y => y.Value.Trim(['[', ']']))
                );
                newInputString = splitString[1];
            }
        }
        return newInputString;
    }

    private List<int> ParseStringToNumbers(string inputString)
    {
        var parsedInts = new List<int>();
        var result = inputString.Split(separator: GetDelimiters(), StringSplitOptions.None);
        var index = 0;

        var hasNegativeNumbers = false;
        var negativeNumbers = new List<int>();

        foreach (var item in result)
        {
            if (int.TryParse(item, out var parsedInt))
            {
                if (parsedInt < 0)
                {
                    hasNegativeNumbers = true;
                    negativeNumbers.Add(parsedInt);
                }
                else if (parsedInt > 1000)
                {
                    parsedInts.Add(0);
                }
                else
                {
                    parsedInts.Add(parsedInt);
                }
            }
            else
            {
                parsedInts.Add(0);
            }

            index++;
        }

        if (hasNegativeNumbers) { throw new ArgumentOutOfRangeException(message: $"Input string contains the following invalid negative numbers: {string.Join(',', negativeNumbers)}", innerException: null); }
        return parsedInts;
    }

    private int RunOperation(List<int> inputNumbers)
    {
        var sum = inputNumbers.Sum();
        Console.WriteLine($"Formula: {string.Join("+", inputNumbers)} = {sum}");
        return inputNumbers.Sum();
    }
}