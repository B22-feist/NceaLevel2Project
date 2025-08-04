using System.ComponentModel.DataAnnotations;

namespace ActualSchoolInternal.Models.Database;
/*This class is used to model answer database and answers to questions*/
public class Answers
{
	public int Id { get; init; }
	
	[MaxLength(200)]
	public required string LocationOfFile { get; init; }
	
	[MaxLength(200)]
	public string? TutorialUrl { get; set; }
	
	[MaxLength(200)]
	public required string Name { get; init; }
	
	public int QuestionId { get; init; }
	
	public Questions Question { get; init; }
}