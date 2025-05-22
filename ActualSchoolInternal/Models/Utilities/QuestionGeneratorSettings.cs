namespace ActualSchoolInternal.Models.Utilities;

public static class QuestionGeneratorSettings
{
	public static string? QuestionDifficutly(bool achieved, bool merit, bool excellence)
	{
		if (excellence) return "exellence";
		
		if (achieved) return "achieved";
		
		if (merit) return "merit";

		return string.Empty;
	}

	public static string? Operation(bool log, bool exponential, bool quadratic, bool linear)
	{
		if (exponential) return "exponential";
		
		else if (quadratic) return "quadratic";

		else if (linear) return "linear";
		
		else if(log) return "log";
		
		return string.Empty;
	}

	public static string? TypeOfQuestion(bool simplify, bool expand, bool factorise, bool solve)
	{
		if (solve) return "solve";
		
		if (factorise) return "factorise";
		
		if (expand) return "expand";
		
		if(simplify) return "simplify";

		return string.Empty;
	}
}