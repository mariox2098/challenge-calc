// See https://aka.ms/new-console-template for more information
public class Calculator
{
    private List<char> _delimiters = ['\n', ','];

    public Calculator() { }
    public int Calculate(string inputString) {
        var numbers = ParseStringToNumbers(inputString);
        var output = RunOperation(numbers);
        return output;
    }

    private List<int> ParseStringToNumbers(string inputString)
    {
        var parsedInts = new List<int>();   
        var result = inputString.Split(_delimiters.ToArray());
        var index = 0;

        foreach (var item in result)
        {
            if(int.TryParse(item, out var parsedInt))
            {
                parsedInts.Add(parsedInt);
            }
            else
            {
                parsedInts.Add(0);
            }

            index++;
        }

        return parsedInts;
    }

    private int RunOperation(List<int> inputNumbers)
    {
        return inputNumbers.Sum();
    }
}