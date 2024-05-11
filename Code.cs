using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingExam
{
    public class Code
    {
        public const string RandomPreCode = @"
// Randomize numbers from 1 to [max]
// No repetition of numbers
// Get random number 
// Utilize it as index to get a random item from numbers list
// then put it on the output list
public static List<int> RandomizeNumbers(int max)
{";

        public const string RandomCode = @"var numbers = new List<int>();
var output = new List<int>();
for (int i = 0; i < 5; i++)
{
   numbers.Add(i);
}
int index = new Random().Next(max); // get random number from 1 - max
numbers.RemoveAt(index); // remove item from list at index
output.AddRange(numbers);
return output;";

        public const string SortPreCode = @"// This sorts the int list (regardless of size) in ASCENDING order using ranks
// each number will be compared against other numbers
// rank is the count of all numbers less than the current number
// currentnumber will then be saved depending on his rank as index on the array
// Do not use pre-defined sorting methods (eg.Sort, OrderBy)
public static int[] SortNumbers(List<int> numbers)
{";
        public const string SortCode = @"int[] output = new int[5];
for(int i = 0; i < numbers.Count + 1; i++)
{
   int rank = 0;
   int currentNumber = numbers[i];
   for(int j = 0; j < i; j++)
   {
      if(currentNumber < numbers[j])
      {
         rank++;
      }
   }
   output[i] = currentNumber;
}
return output;";

        public const string DivisibilityPreCode = @"// if divisible by 2, write 'Two'
// if divisible by 5, write 'Five'
// if divisible by 10, write 'Ten'
// if not divisible by 2, 5, and 10, write the number
// sample result: 1,Two,3,Two,Five,Two,7,Two,9,Ten
public static IEnumerable<string> DetermineDivisibilities(int[] numbers)
{";

        public const string DivisibilityCode = @"var output = new List<string>();
foreach(var number in numbers)
{
   if(number % 2 == 0) // if number is divisible by 2
   {
      output.Add(" + "\"Two\");" + @"
      continue;
   }
   else
   {
      output.Add(" + "\"Ten\");" + @"
      continue;
   }
   if (number % 5 == 0) // if number is divisible by 5
   {
      output.Add(" + "\"Five\");" + @"
   }
   else
   {
      output.Add(number.ToString());
   }
}
return output; ";

		public string FormatCode(string randomCode, string sortCode, string divisibilityCode)
		{
            return @"public class Program
{
	public static void RunRandomTest(int max, StringBuilder output)
	{
		List<int> randomNumbers = RandomizeNumbers(max);
		string randomNumbersAsString = string.Join("","", randomNumbers);
		output.AppendLine($""Result: {randomNumbersAsString}"");
		output.AppendLine(""No Duplicates Passed: "" + !randomNumbers.GroupBy(x => x).Any(g => g.Count() > 1));
		output.AppendLine(""Within Range Passed: "" + !randomNumbers.Any(x => x < 1 || x > max));
		output.AppendLine(""Correct Length Passed: "" + (randomNumbers.Count == max));
		output.AppendLine(""Is Randomized Passed: "" + (randomNumbersAsString != string.Join("","", randomNumbers.OrderBy(x => x))));
	}

	public static void FormatResult(string result, string expected, StringBuilder output)
	{
		output.AppendLine($""Result: {result}"");
		output.AppendLine($""Expected: {expected}"");
		output.AppendLine($""Passed: "" + (result == expected).ToString());
	}
	public static string Run()
	{
		StringBuilder output = new StringBuilder();
		output.AppendLine(""-- RandomizeNumbers() --"");
		try
		{
			output.AppendLine(""Test: 5"");
			RunRandomTest(5, output);
			
			output.AppendLine(""Test: 10"");
			RunRandomTest(10, output);
		}
		catch (Exception ex)
		{
			output.AppendLine($""Exception: {ex.Message}"");
		}
		output.AppendLine();
		output.AppendLine(""-- SortNumbers() --"");
		try
		{
			List<int> sortingTest = new List<int> {4, 5, 2, 3, 1};
			output.AppendLine($""Test: {string.Join("","", sortingTest)}"");
			FormatResult(string.Join("","", SortNumbers(sortingTest)), ""1,2,3,4,5"", output);
			
			List<int> sortingTest2 = new List<int> {4, 5, 2, 3, 1, 10, 8, 6, 9, 7};
			output.AppendLine($""Test: {string.Join("","", sortingTest2)}"");
			FormatResult(string.Join("","", SortNumbers(sortingTest2)), ""1,2,3,4,5,6,7,8,9,10"", output);
		}
		catch (Exception ex)
		{
			output.AppendLine($""Exception: {ex.Message}"");
		}
		output.AppendLine();
		output.AppendLine(""-- DetermineDivisibilities() --"");
		try
		{
			int[] divisibilityTest = new int[5] {1,2,3,4,5};
			output.AppendLine($""Test: {string.Join("","", divisibilityTest)}"");
			FormatResult(string.Join("","", DetermineDivisibilities(divisibilityTest)), ""1,Two,3,Two,Five"", output);

			int[] divisibilityTest2 = new int[10] {1,2,3,4,5,6,7,8,9,10};
			output.AppendLine($""Test: {string.Join("","", divisibilityTest2)}"");
			FormatResult(string.Join("","", DetermineDivisibilities(divisibilityTest2)), ""1,Two,3,Two,Five,Two,7,Two,9,Ten"", output);
		}
		catch (Exception ex)
		{
			output.AppendLine($""Exception: {ex.Message}"");
		}
		
		return output.ToString();
	}

	public static List<int> RandomizeNumbers(int max)
	{
		" + randomCode + @"
	}
	
	public static int[] SortNumbers(List<int> numbers)
    {
        " + sortCode + @"
    }
	
	public static IEnumerable<string> DetermineDivisibilities(int[] numbers)
    {
        " + divisibilityCode + @"
    }
}";
        }
    }
}
