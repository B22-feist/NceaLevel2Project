using System.Collections.Generic;

namespace ActualSchoolInternal.Models.Database;

public partial class Questions
{
	public int Id { get; set; }
	
	public string Operation { get; set; }
	
	public string Difficulty  { get; set; }
	
	public string Location  { get; set; }
	
	public Answers answers { get; set; }
}