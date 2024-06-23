// See https://aka.ms/new-console-template for more information
public class Calculator
{
    public Calculator() { }
    public int Calculate(string inputString) {
        var numbers = ParseStringToNumbers(inputString);
        var output = RunOperation(numbers);
        return output;
    }

    private List<int> ParseStringToNumbers(string inputString)
    {
        var parsedInts = new List<int>();   
        var result = inputString.Split(',');
        var index = 0;

        foreach (var item in result)
        {
            if(index >= 2)
            {
                throw new ArgumentOutOfRangeException("");
            }
            else if(int.TryParse(item, out var parsedInt))
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