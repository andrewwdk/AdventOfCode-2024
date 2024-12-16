namespace AdventOfCode2024.Models
{
    public class Operation
    {
        public Operation(string line)
        {
            var parts = line.Split(' ', ':').Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse).ToList();
            Sum = parts[0];
            Numbers = parts.Skip(1).ToList();
            InitBinaryOperators();
            InitTrinaryOperators();
        }

        public long Sum { get; set; }
        public List<long> Numbers { get; set; } = new List<long>();
        public List<List<char>> BinaryOperators { get; set; } = new List<List<char>>();
        public List<List<char>> TrinaryOperators { get; set; } = new List<List<char>>();

        private void InitBinaryOperators()
        {
            int length = Numbers.Count - 1;
            int possibleOperatorSetCount = 1 << length; // equivalent of 2^n
            for (int i = 0; i < possibleOperatorSetCount; i++)
            {
                string binary = Convert.ToString(i, 2);
                string leading_zeroes = "00000000000000".Substring(0, length - binary.Length);
                binary = leading_zeroes + binary;
                var set = new List<char>();

                foreach (char c in binary)
                    set.Add(c == '0' ? '+' : '*');

                BinaryOperators.Add(set);
            }
        }

        private void InitTrinaryOperators()
        {
            int length = Numbers.Count - 1;
            int possibleOperatorSetCount = (int)Math.Pow(3, length);
            for (int i = 0; i < possibleOperatorSetCount; i++)
            {
                string convertedNumber = "";
                ConvertToTernary(i, ref convertedNumber);

                string leading_zeroes = "000000000000000000000000".Substring(0, length - convertedNumber.Length);
                convertedNumber = leading_zeroes + convertedNumber;
                //Console.WriteLine(convertedNumber);
                var set = new List<char>();

                foreach (char c in convertedNumber)
                    set.Add(c == '0' ? '+' : (c == '1' ? '*' : '|'));

                TrinaryOperators.Add(set);
            }
        }

        public bool IsBinarySolvable()
        {
            foreach (var set in BinaryOperators)
            {
                long result = 0;

                for (int i = 0; i < Numbers.Count - 1; i++)
                {
                    if (i == 0)
                        result = set[i] == '+' ? Numbers[i] + Numbers[i + 1] : Numbers[i] * Numbers[i + 1];
                    else
                        result = set[i] == '+' ? result + Numbers[i + 1] : result * Numbers[i + 1];
                }

                if (result == Sum)
                    return true;
            }

            return false;
        }

        public bool IsTrinarySolvable()
        {
            foreach (var set in TrinaryOperators)
            {
                long result = 0;

                for( var i = 0; i < set.Count; i++)
                {
                    switch (set[i])
                    {
                        case '+':
                            if (i == 0)
                                result = Numbers[i] + Numbers[i + 1];
                            else
                                result += Numbers[i + 1];
                            break;
                        case '*':
                            if (i == 0)
                                result = Numbers[i] * Numbers[i + 1];
                            else
                                result *= Numbers[i + 1];
                            break;
                        case '|':
                            if (i == 0)
                                result = long.Parse($"{Numbers[i]}{Numbers[i + 1]}");
                            else 
                                result = long.Parse($"{result}{Numbers[i + 1]}");
                            break;
                        default:
                            break;
                    }
                }

                if (result == Sum)
                    return true;
            }

            return false;
        }

        private string ConvertToTernary(int N, ref string res)
        {
            //string res = result;

            // Base case 
            if (N == 0)
                return res;

            // Finding the remainder 
            // when N is divided by 3 
            int x = N % 3;
            N /= 3;
            if (x < 0)
                N += 1;

            // Recursive function to 
            // call the function for 
            // the integer division 
            // of the value N/3 
           ConvertToTernary(N, ref res);

            // Handling the negative cases 
            if (x < 0)
                res += x + (3 * -1);
            else
                res += x;

            return res;
        }
    }
}
