public interface ICalculator
{
    int Calculate(string inputString);
    string[] GetDelimiters();
    string ParseCustomDelimiter(string inputString);
    void SetAltDelimiter(string? altDelimiter);
    void SetDenyNegative(bool? denyNegative);
    void SetOperation(string? operation);
    void SetUpperNumBound(int? upperBound);
}