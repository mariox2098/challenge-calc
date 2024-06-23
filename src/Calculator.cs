// See https://aka.ms/new-console-template for more information
public class Calculator
{
    private List<char> _delimiters = ['\n', ','];
    private char? _customDelimiter = null;

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

    public char[] GetDelimiters()
    {
        var allDelimiters = _delimiters;
        if (_customDelimiter != null) { allDelimiters.Add(_customDelimiter.Value); }
        return allDelimiters.ToArray();
    }
    public string ParseCustomDelimiter(string inputString)
    {
        var newInputString = inputString;
        _customDelimiter = null;
        if (inputString.StartsWith("//"))
        {
            var splitString = inputString.Split('\n', 2);
            if (splitString != null && splitString.Length == 2)
            {
                _customDelimiter = char.Parse(splitString[0].Substring(2));
                newInputString = splitString[1];
            }
        }
        return newInputString;
    }

    private List<int> ParseStringToNumbers(string inputString)
    {
        var parsedInts = new List<int>();
        var result = inputString.Split(GetDelimiters());
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
        return inputNumbers.Sum();
    }
}