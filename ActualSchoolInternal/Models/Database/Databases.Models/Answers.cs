using System.Collections.Generic;

namespace ActualSchoolInternal.Models.Database;

public partial class Answers
{
	public int Id { get; set; }
	
	public required string LocationOfFile { get; set; }
	
	public string TutorialUrl { get; set; }
	
	public required string Name { get; set; }
	
	public required Questions Questions { get; set; }
}