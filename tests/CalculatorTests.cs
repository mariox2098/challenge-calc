namespace tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        [DataRow("+")]
        [DataRow("-")]
        [DataRow("*")]
        [DataRow("/")]
        public void SetOperation_ValidOperation_Success(string operation)
        {
            var calculator = new Calculator();
            calculator.SetOperation(operation);
            Assert.AreEqual(operation, calculator.GetOperation());
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("d")]
        [DataRow("&")]
        [DataRow("$")]
        public void SetOperation_InvalidOperation_UseDefaultOperation(string operation)
        {
            var calculator = new Calculator();
            calculator.SetOperation(operation);
            Assert.AreEqual("+", calculator.GetOperation());
        }

        [TestMethod]
        public void SetAltDelimiter_ValidDelimiter_Success()
        {
            var delimeter = "**";
            var calculator = new Calculator();
            calculator.SetAltDelimiter(delimeter);
            Assert.IsTrue(calculator.GetDelimiters().Contains(delimeter));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("  ")]
        public void SetAltDelimiter_InvalidDelimiter_NotAdded(string? delimeter)
        {
            var calculator = new Calculator();
            calculator.SetAltDelimiter(delimeter);
            Assert.IsFalse(calculator.GetDelimiters().Contains(delimeter));
        }

        [TestMethod]
        public void SetUpperNumBound_ValidNumber_Success()
        {
            var upperBound = 2000;
            var calculator = new Calculator();
            calculator.SetUpperNumBound(upperBound);
            Assert.AreEqual(upperBound, calculator.GetUpperNumBound());
        }

        [TestMethod]
        public void SetUpperNumBound_NullNumber_NoChange()
        {
            var calculator = new Calculator();
            calculator.SetUpperNumBound(null);
            Assert.AreEqual(1000, calculator.GetUpperNumBound());
        }

        [TestMethod]
        public void ParseCustomDelimiter_ValidString_Success()
        {
            var calculator = new Calculator();
            var result = calculator.ParseCustomDelimiter("//#\n2#5");

            Assert.IsFalse(result.StartsWith("//"));
            Assert.IsTrue(calculator.GetDelimiters().Contains("#"));
        }

        [TestMethod]
        [DataRow("//\n2#5")]
        [DataRow("//[]\n2#5")]
        [DataRow("//[][]\n2#5")]
        public void ParseCustomDelimiter_InvalidString_NoNewDelimiters(string inputString)
        {

            var calculator = new Calculator();
            var defaultNumberOfDelimiters = calculator.GetDelimiters().Length;
            var result = calculator.ParseCustomDelimiter(inputString);

            Assert.IsFalse(result.StartsWith("//"));
            Assert.AreEqual(defaultNumberOfDelimiters, calculator.GetDelimiters().Length);
        }

        [TestMethod]
        [DataRow("20")]
        [DataRow("1,5000")]
        [DataRow("5,tytyt")]
        [DataRow("1,2,3,4,5,6,7,8,9,10,11,12")]
        [DataRow("1\n2,3")]
        [DataRow("2,1001,6")]
        [DataRow("//#\n2#5")]
        [DataRow("//,\n2,ff,100")]
        [DataRow("//[***]\n11***22***33")]
        [DataRow("//[*][!!][r9r]\n11r9r22*hh*33!!44")]
        public void Calculate_ValidString_Success(string inputString)
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(inputString);
        }

        [TestMethod]
        [DataRow("-5")]
        [DataRow("-5,-6,343,1200")]
        public void Calculate_NegativeNumbersInString_ThrowsException(string inputString)
        {
            var calculator = new Calculator();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calculator.Calculate(inputString));
        }

        [TestMethod]
        [DataRow("0")]
        [DataRow("1,4,0,2")]
        [DataRow("1,4,2000,2")]
        public void Calculate_DivideByZero_Return0(string inputString)
        {
            var calculator = new Calculator();
            calculator.SetOperation("/");
            var result = calculator.Calculate(inputString);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow("2000,1,3", 4)]
        [DataRow("1400,5600", 0)]
        public void Calculate_LargerThanUpperBOunds_UsesNumberAsZero(string inputString, int expectedResult)
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(inputString);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("+", 6)]
        [DataRow("-", -4)]
        [DataRow("*", 6)]
        [DataRow("/", 0)]
        public void Calculate_DifferentOperations_ReturnsExceptedResult(string operation, int expectedResult)
        {
            var calculator = new Calculator();
            calculator.SetOperation(operation);
            var result = calculator.Calculate("1,2,3");
            Assert.AreEqual(expectedResult, result);
        }
    }
}