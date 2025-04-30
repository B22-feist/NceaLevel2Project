using System.Collections.Generic;

namespace ActualSchoolInternal.Models.Database;

public class Questions
{
	public Questions()
	{
		answers = new HashSet<Answers>();
	}
	
	public int Id { get; set; }
	
	public string Operation { get; set; }
	
	public string Difficulty  { get; set; }
	
	public string Location  { get; set; }
	
	public ICollection<Answers> answers { get; set; }
}