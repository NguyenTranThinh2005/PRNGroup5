
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using DrugPreventionSystem.DataAccess.Models;
using Models.Users;
using Models.Surveys;
using Models.Courses;
using Models.Quizzes;
using Microsoft.Extensions.Configuration;


namespace DrugPreventionSystem.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; } = null!;
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; } = null!;
        public DbSet<SurveyOption> SurveyOptions { get; set; } = null!;
        public DbSet<UserSurveyResponse> UserSurveyResponses { get; set; } = null!;
        public DbSet<UserSurveyAnswer> UserSurveyAnswers { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;
        public DbSet<LessonResource> LessonResources { get; set; } = null!;
        public DbSet<Quiz> Quizzes { get; set; } = null!;
        public DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
        public DbSet<QuizOption> QuizOptions { get; set; } = null!;
        public DbSet<PracticeExercise> PracticeExercises { get; set; } = null!;
        public DbSet<UserLessonProgress> UserLessonProgresses { get; set; } = null!;
        public DbSet<UserQuizAnswer> UserQuizAnswers { get; set; } = null!;
        public DbSet<UserModuleQuizResult> UserModuleQuizResults { get; set; } = null!;
        public DbSet<CourseCertificate> CourseCertificates { get; set; } = null!;
        public DbSet<UserCourseEnrollment> UserCourseEnrollments { get; set; } = null!;


        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["ConnectionStrings:DefaultConnectionString"];
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure indexes
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
                .IsUnique();
            // Survey có nhiều SurveyQuestions
            modelBuilder.Entity<SurveyQuestion>()
                .HasOne(sq => sq.Survey)
                .WithMany(s => s.SurveyQuestions)
                .HasForeignKey(sq => sq.SurveyId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa khảo sát, các câu hỏi của nó cũng bị xóa

            // SurveyQuestion có nhiều SurveyOptions
            modelBuilder.Entity<SurveyOption>()
                .HasOne(so => so.SurveyQuestion)
                .WithMany(sq => sq.SurveyOptions)
                .HasForeignKey(so => so.QuestionId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa câu hỏi, các lựa chọn của nó cũng bị xóa

            // UserSurveyResponse liên kết với User và Survey
            modelBuilder.Entity<UserSurveyResponse>()
                .HasOne(usr => usr.User)
                .WithMany(u => u.UserSurveyResponses)
                .HasForeignKey(usr => usr.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserSurveyResponse>()
                .HasOne(usr => usr.Survey)
                .WithMany(s => s.UserSurveyResponses)
                .HasForeignKey(usr => usr.SurveyId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserSurveyAnswer liên kết với UserSurveyResponse, SurveyQuestion và SurveyOption
            modelBuilder.Entity<UserSurveyAnswer>()
                .HasOne(usa => usa.UserSurveyResponse)
                .WithMany(usr => usr.UserSurveyAnswers)
                .HasForeignKey(usa => usa.ResponseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserSurveyAnswer>()
                .HasOne(usa => usa.SurveyQuestion)
                .WithMany(sq => sq.UserSurveyAnswers)
                .HasForeignKey(usa => usa.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSurveyAnswer>()
                .HasOne(usa => usa.SurveyOption)
                .WithMany(so => so.UserSurveyAnswers)
                .HasForeignKey(usa => usa.OptionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Lesson có nhiều LessonResources
            modelBuilder.Entity<LessonResource>()
                .HasOne(lr => lr.Lesson)
                .WithMany(l => l.LessonResources)
                .HasForeignKey(lr => lr.LessonId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa Lesson, Resources cũng bị xóa

            // Lesson có một Quiz (One-to-One)
            modelBuilder.Entity<Quiz>()
                .HasOne(q => q.Lesson)
                .WithOne(l => l.Quiz)
                .HasForeignKey<Quiz>(q => q.LessonId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa Lesson, Quiz cũng bị xóa

            modelBuilder.Entity<Quiz>()
                .HasIndex(q => q.LessonId)
                .IsUnique();

            // Quiz có nhiều QuizQuestions
            modelBuilder.Entity<QuizQuestion>()
                .HasOne(qq => qq.Quiz)
                .WithMany(q => q.QuizQuestions)
                .HasForeignKey(qq => qq.QuizId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa Quiz, Questions cũng bị xóa

            // QuizQuestion có nhiều QuizOptions
            modelBuilder.Entity<QuizOption>()
                .HasOne(qo => qo.QuizQuestion)
                .WithMany(qq => qq.QuizOptions)
                .HasForeignKey(qo => qo.QuestionId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa Question, Options cũng bị xóa

            // Lesson có nhiều PracticeExercises
            modelBuilder.Entity<PracticeExercise>()
                .HasOne(pe => pe.Lesson)
                .WithMany(l => l.PracticeExercises)
                .HasForeignKey(pe => pe.LessonId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa Lesson, PracticeExercises cũng bị xóa

            // UserLessonProgress liên kết với User và Lesson
            modelBuilder.Entity<UserLessonProgress>()
                .HasOne(ulp => ulp.User)
                .WithMany(u => u.UserLessonProgresses)
                .HasForeignKey(ulp => ulp.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Không xóa User nếu còn tiến độ bài học
            modelBuilder.Entity<UserLessonProgress>()
                .HasOne(ulp => ulp.Lesson)
                .WithMany(l => l.UserLessonProgresses)
                .HasForeignKey(ulp => ulp.LessonId)
                .OnDelete(DeleteBehavior.Cascade); // Khi xóa Lesson, tiến độ cũng bị xóa

            // UserQuizAnswer liên kết với User, QuizQuestion, QuizOption
            modelBuilder.Entity<UserQuizAnswer>()
                .HasOne(uqa => uqa.User)
                .WithMany(u => u.UserQuizAnswers)
                .HasForeignKey(uqa => uqa.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserQuizAnswer>()
                .HasOne(uqa => uqa.QuizQuestion)
                .WithMany(qq => qq.UserQuizAnswers)
                .HasForeignKey(uqa => uqa.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserQuizAnswer>()
                .HasOne(uqa => uqa.SelectedOption)
                .WithMany(qo => qo.UserQuizAnswers)
                .HasForeignKey(uqa => uqa.SelectedOptionId)
                .OnDelete(DeleteBehavior.Restrict);

            // UserModuleQuizResult liên kết với User và Lesson
            modelBuilder.Entity<UserModuleQuizResult>()
                .HasOne(umqr => umqr.User)
                .WithMany(u => u.UserModuleQuizResults) // Cần thêm Navigation Property này vào User
                .HasForeignKey(umqr => umqr.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserModuleQuizResult>()
                .HasOne(umqr => umqr.Lesson)
                .WithMany(l => l.UserModuleQuizResults) // Cần thêm Navigation Property này vào Lesson
                .HasForeignKey(umqr => umqr.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            // CourseCertificate liên kết với User và Course
            modelBuilder.Entity<CourseCertificate>()
                .HasOne(cc => cc.User)
                .WithMany(u => u.CourseCertificates) // Cần thêm Navigation Property này vào User
                .HasForeignKey(cc => cc.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CourseCertificate>()
                .HasOne(cc => cc.Course)
                .WithMany(c => c.CourseCertificates)
                .HasForeignKey(cc => cc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserCourseEnrollment>()
                .Property(e => e.Status)
                .HasConversion<string>(); // Lưu enum dưới dạng chuỗi trong DB


            modelBuilder.Entity<UserCourseEnrollment>()
                .HasIndex(uce => new { uce.UserId, uce.CourseId })
                .IsUnique();

            // Cấu hình mối quan hệ 1-nhiều giữa User và UserCourseEnrollment
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserCourseEnrollments)
                .WithOne(uce => uce.User)
                .HasForeignKey(uce => uce.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình mối quan hệ 1-nhiều giữa Course và UserCourseEnrollment
            modelBuilder.Entity<Course>()
                .HasMany(c => c.UserCourseEnrollments)
                .WithOne(uce => uce.Course)
                .HasForeignKey(uce => uce.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin", Description = "System Administrator" },
                new Role { RoleId = 2, RoleName = "Manager", Description = "System Manager" },
                new Role { RoleId = 3, RoleName = "Staff", Description = "Staff Member" },
                new Role { RoleId = 4, RoleName = "Consultant", Description = "Professional Consultant" },
                new Role { RoleId = 5, RoleName = "Member", Description = "Registered Member" }
            );
        }
    }
}
