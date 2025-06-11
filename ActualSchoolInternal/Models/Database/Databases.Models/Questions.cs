using System.ComponentModel.DataAnnotations;

namespace ActualSchoolInternal.Models.Database;
/*This class is used to model question and the quesiton database*/
public class Questions
{
	public int Id { get; set; }
	
	[MaxLength(100)]
	public required string Operation { get; set; }
	
	[MaxLength(100)]
	public required string Difficulty  { get; set; }
	[MaxLength(100)]
	public required string Location  { get; set; }
	[MaxLength(100)]
	public required string TypeOfQuestion { get; set; }
	
	[MaxLength(100)]
	public required string Name { get; set; }
	
	public required ICollection<Answers> Answers { get; set; }
}