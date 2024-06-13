using Tengella.Survey.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Tengella.Survey.Data;

public class SurveyDbContext : DbContext
{
    public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<SurveyObject> SurveyObjects { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Choice> Choices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seeding a customer
        modelBuilder.Entity<User>().HasData(new User
        {
            UserId = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "jattebra123",
            PhoneNumber = "1234567890",
            CreationDate = DateTime.Parse("2024-05-11"),
        });

        // Seeding products
        modelBuilder.Entity<SurveyObject>().HasData(new SurveyObject
        {
            SurveyObjectId = 1,
            SurveyTitle = "Enkät för anställda",
            SurveyDescription = "Enkät för att kolla av med anställda",
            SurveyType = "Feedback",
            UserId = 1

        }
        );

        // Seeding an order
        modelBuilder.Entity<Question>().HasData(new Question
        {
            QuestionId = 1,
            QuestionName = "Hur mår du?",
            QuestionPosition = 1,
            QuestionType = "Single",
            SurveyObjectId = 1
        });

        // Seeding order details
        modelBuilder.Entity<Answer>().HasData(
            new Answer { AnswerId = 1, AnswerName = "Bra", QuestionId = 1 },
            new Answer { AnswerId = 2, AnswerName = "Medel", QuestionId = 1 },
            new Answer { AnswerId = 3, AnswerName = "Dåligt", QuestionId = 1 }
        );
    }
}
