using System.Collections.Generic;

namespace ActualSchoolInternal.Models.Database;

public class Answers
{
	public int ID { get; set; }
	
	public string LocationOfFile { get; set; }
	
	public string TutorialUrl { get; set; }
	
	public Questions Questions { get; set; }
}