using System.ComponentModel.DataAnnotations;

namespace ActualSchoolInternal.Models.Database;

public class Answers
{
	public int Id { get; init; }
	
	[MaxLength(200)]
	public required string LocationOfFile { get; init; }
	
	[MaxLength(200)]
	public string? TutorialUrl { get; set; }
	
	[MaxLength(200)]
	public required string Name { get; init; }
	
	public required Questions Questions { get; init; }
}