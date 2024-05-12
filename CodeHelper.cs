using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodingExam
{
    public class CodeHelper
    {
        public CodeHelper()
        {
			string codeFile = File.ReadAllText("Codes.txt");
			string[] codes = codeFile.Split("#SPLIT#");
			this.Codes = [];
			foreach (string code in codes)
			{
				string[] parts = code.Split("#EDITABLE#");
				Codes.Add(new Code() { Signature = parts[0], Editable = parts[1] });
			}

			Tests = File.ReadAllText("Tests.txt");
        }
		public List<Code> Codes;
		public string Tests;

		public string FullCode()
		{
            string template = @"public class Program
{
	public static string Run()
	{
		StringBuilder output = new StringBuilder();
		#TESTS#
		return output.ToString();
	}
	
	private static void RunTest(Func<string, string> method, string parameters, string expected, StringBuilder output)
	{
		output.AppendLine($""{method.Method.Name}(\""{parameters}\"")"");
		try
		{
			string result = method.Invoke(parameters);
			output.AppendLine($""Result: {result}"");
			output.AppendLine($""Expected: {expected}"");
			output.AppendLine($""Passed: {result == expected}"");
		}
		catch(Exception exception)
		{
			output.AppendLine($""Exception: {exception.Message}"");
		}
		output.AppendLine();
	}
	#METHODS#
}";
			
            template = template.Replace("#TESTS#", Tests);
			template = template.Replace("#METHODS#", string.Join(Environment.NewLine, Codes.Select(x => x.ToMethod())));
			return CSharpSyntaxTree.ParseText(template).GetRoot().NormalizeWhitespace().ToFullString(); 
        }
    }

	public class Code
	{
        public string? Signature { get; set; }
        public string? Editable { get; set; }

		public string ToMethod()
		{
			return $@"{Signature}
	{Editable}" + @"
}
";
		}
    }
}
