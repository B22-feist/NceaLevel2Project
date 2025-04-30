using System.Collections.Generic;

namespace ActualSchoolInternal.Models.Database;

public class Answers
{
	Answers()
	{
		Questions = new HashSet<Questions>();
	}
	public int ID { get; set; }
	
	public string LocationOfFile { get; set; }
	
	public string TutorialUrl { get; set; }
	
	public ICollection<Questions> Questions { get; set; }
}