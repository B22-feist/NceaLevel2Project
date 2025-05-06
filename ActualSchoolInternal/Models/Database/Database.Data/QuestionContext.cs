using Microsoft.EntityFrameworkCore;

namespace ActualSchoolInternal.Models.Database.Database.Data;

public class QuestionContext : DbContext
{
	public virtual DbSet<Questions>? Questions { get; set; }
	
	public virtual DbSet<Answers> Answers { get; set; }
	
	private string DbPath { get; set; }

	public QuestionContext()
	{
		const Environment.SpecialFolder folder = Environment.SpecialFolder.ApplicationData;
		
		string path = Environment.GetFolderPath(folder);
		DbPath = Path.Combine(path, "ActualSchoolInternal.db");
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite($"Data Source={DbPath}");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Questions>(entity =>
		{
			entity.HasOne(q => q.answers)
				.WithMany(a => a.Questions)
				.HasForeignKey(q => q.Id)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_answers");
			
			entity.Property(e => e.Operation).IsRequired();

			entity.Property(e => e.Location).IsRequired();

			entity.Property(e => e.Difficulty).IsRequired();

			entity.HasKey(e => e.Id).HasName("ID");
		});

		modelBuilder.Entity<Answers>(entity =>
		{
			entity.Property(e => e.LocationOfFile).IsRequired();

			entity.HasKey(e => e.Id);
		});
	}
}