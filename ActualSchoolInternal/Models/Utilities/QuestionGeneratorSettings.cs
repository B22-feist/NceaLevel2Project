namespace ActualSchoolInternal.Models.Utilities;

public static class QuestionGeneratorSettings
{
	public static string? QuestionDifficutly(bool achieved, bool merit, bool excellence)
	{
		if (excellence) return "Excellence";
		
		if (achieved) return "Achieved";
		
		if (merit) return "Merit";

		return string.Empty;
	}

	public static string? Operation(bool log, bool exponential, bool quadratic, bool linear)
	{
		if (exponential) return "Exponential";
		
		else if (quadratic) return "Quadratic";

		else if (linear) return "Linear";
		
		else if(log) return "Log";
		
		return string.Empty;
	}

	public static string? TypeOfQuestion(bool simplify, bool expand, bool factorise, bool solve)
	{
		if (solve) return "Solve";
		
		if (factorise) return "Factorise";
		
		if (expand) return "Expand";
		
		if(simplify) return "Simplify";

		return string.Empty;
	}
}