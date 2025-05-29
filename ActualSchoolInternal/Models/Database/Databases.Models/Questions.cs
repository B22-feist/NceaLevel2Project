using System.Collections.Generic;

namespace ActualSchoolInternal.Models.Database;

public partial class Questions
{
	public int Id { get; set; }
	
	public required string Operation { get; set; }
	
	public required string Difficulty  { get; set; }
	
	public required string Location  { get; set; }
	
	public string TypeOfQuestion { get; set; }
	
	public required string Name { get; set; }
	
	public required ICollection<Answers> answers { get; set; }
}