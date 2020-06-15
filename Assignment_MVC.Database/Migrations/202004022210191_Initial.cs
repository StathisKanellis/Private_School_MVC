namespace Assignment_MVC.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        Description = c.String(nullable: false, maxLength: 60),
                        SubTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60),
                        Stream = c.String(nullable: false, maxLength: 60),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        PhotoUrl = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Telephone = c.String(),
                        Email = c.String(),
                        Country = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.MarkAssignments",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                        MarkCode = c.String(),
                        TotalMark = c.Int(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.AssignmentId })
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        DateOfBirth = c.DateTime(nullable: false),
                        Salary = c.Double(nullable: false),
                        PhotoUrl = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                        Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainerId);
            
            CreateTable(
                "dbo.TutionFees",
                c => new
                    {
                        TutionFeesId = c.Int(nullable: false),
                        CodeCourse = c.String(),
                        Cost = c.Double(nullable: false),
                        Vat = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TutionFeesId)
                .ForeignKey("dbo.Courses", t => t.TutionFeesId)
                .Index(t => t.TutionFeesId);
            
            CreateTable(
                "dbo.CourseAssignments",
                c => new
                    {
                        Course_CourseId = c.Int(nullable: false),
                        Assignment_AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_CourseId, t.Assignment_AssignmentId })
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Assignments", t => t.Assignment_AssignmentId, cascadeDelete: true)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Assignment_AssignmentId);
            
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        Trainer_TrainerId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainer_TrainerId, t.Course_CourseId })
                .ForeignKey("dbo.Trainers", t => t.Trainer_TrainerId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Trainer_TrainerId)
                .Index(t => t.Course_CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TutionFees", "TutionFeesId", "dbo.Courses");
            DropForeignKey("dbo.TrainerCourses", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.TrainerCourses", "Trainer_TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.MarkAssignments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.MarkAssignments", "AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseAssignments", "Assignment_AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.CourseAssignments", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.TrainerCourses", new[] { "Course_CourseId" });
            DropIndex("dbo.TrainerCourses", new[] { "Trainer_TrainerId" });
            DropIndex("dbo.CourseAssignments", new[] { "Assignment_AssignmentId" });
            DropIndex("dbo.CourseAssignments", new[] { "Course_CourseId" });
            DropIndex("dbo.TutionFees", new[] { "TutionFeesId" });
            DropIndex("dbo.MarkAssignments", new[] { "AssignmentId" });
            DropIndex("dbo.MarkAssignments", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "CourseId" });
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.CourseAssignments");
            DropTable("dbo.TutionFees");
            DropTable("dbo.Trainers");
            DropTable("dbo.MarkAssignments");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
