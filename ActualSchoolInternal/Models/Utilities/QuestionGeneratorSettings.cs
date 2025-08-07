namespace ActualSchoolInternal.Models.Utilities;

public static class QuestionGeneratorSettings
{
	public static string QuestionDifficultly(bool achieved, bool merit, bool excellence)
	{
		if (excellence) return "Excellence";
		
		if (achieved) return "Achieved";
		
		if (merit) return "Merit";

		return string.Empty;
	}

	public static string Equation(bool log, bool exponential, bool quadratic, bool linear)
	{
		if (exponential) return "Exponential";

		if (quadratic) return "Quadratic";

		if (linear) return "Linear";

		if(log) return "Log";

		return string.Empty;
	}

	public static string Operation(bool simplify, bool expand, bool factorise, bool solve)
	{
		if (solve) return "Solve";
		
		if (factorise) return "Factorise";
		
		if (expand) return "Expand";
		
		if(simplify) return "Simplify";

		return string.Empty;
	}
}