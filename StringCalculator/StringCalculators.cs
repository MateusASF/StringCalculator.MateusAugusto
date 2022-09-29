namespace StringCalculator.Domain
{
    public class StringCalculators
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var parts = numbers.Split(",");
            var exceedsCount = parts.Length > 2;
            var consecutiveCommands = parts.Any(x => x == "");
            var nomNumbers = parts.Any(x => !int.TryParse(x, out _));


            if (exceedsCount || consecutiveCommands || nomNumbers)
                throw new ArgumentException(nameof(numbers));

            var sum = parts.Sum(Convert.ToInt32);

            return sum;
        }
    }
}