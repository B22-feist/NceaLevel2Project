using System.Collections.Generic;

namespace ActualSchoolInternal.Models.Database;

public partial class Answers
{
	public int ID { get; set; }
	
	public string LocationOfFile { get; set; }
	
	public string TutorialUrl { get; set; }
	
	public ICollection<Questions> Questions { get; set; }
}