using ActualSchoolInternal.Models.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ActualSchoolInternal.Models.Database.Database.Data;

/*This class is the source of all Database actions*/
public class QuestionContext : DbContext
{
	/*Sets up questions table*/
	public virtual DbSet<Questions>? Questions { get; set; }
	
	/*sets up answers table*/
	public virtual DbSet<Answers> Answers { get; set; }
	
	/*path to db*/
	private string DbPath { get; set; }

	/*when question context is called gets the location of the Database
	 and sets the database path*/
	public QuestionContext()
	{
		string folder = GetFolderPath.FolderPath();

		DbPath = Path.Combine(folder, "ActualSchoolInternal.db");
	}

	/*when being configured sets the path to db to be the database path
	 when generated with ef core*/
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite($"Data Source={DbPath}");
	}

	/*When the model is created using ef core set required items,
	 ID's, primary and foreign keys*/
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		/*sets operation difficultly, operation and location to be required
		 as well as id as a key*/
		modelBuilder.Entity<Questions>(entity =>
		{
			entity.Property(e => e.Operation).IsRequired();

			entity.Property(e => e.Location).IsRequired();

			entity.Property(e => e.Difficulty).IsRequired();

			entity.HasKey(e => e.Id).HasName("ID");
		});

		/*set location to be required, sets up the id and
		 sets the primary key of questions table to be the 
		 foreign key of answers*/
		modelBuilder.Entity<Answers>(entity =>
		{
			entity.Property(e => e.LocationOfFile).IsRequired();

			entity.HasKey(e => e.Id);
			
			entity.HasOne(q => q.Questions)
				.WithMany(a => a.Answers)
				.HasForeignKey(q => q.Id)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_answers");
		});
	}
}