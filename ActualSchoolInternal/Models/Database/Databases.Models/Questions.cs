using System.ComponentModel.DataAnnotations;

namespace ActualSchoolInternal.Models.Database;
/*This class is used to model question and the question database*/
public class Questions
{
	public int Id { get; set; }
	
	[MaxLength(100)]
	public required string Operation { get; init; }
	
	[MaxLength(100)]
	public required string Difficulty  { get; init; }
	[MaxLength(100)]
	public required string Location  { get; init; }
	[MaxLength(100)]
	public required string TypeOfQuestion { get; init; }
	
	[MaxLength(100)]
	public required string Name { get; init; }

	[MaxLength(100)] 
	public string? TutorialUrl { get; init; }

	public Answers Answer { get; set; }
}