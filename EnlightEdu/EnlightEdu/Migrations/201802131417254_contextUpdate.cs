namespace EnlightEdu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contextUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Student_Id", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Subject_Id" });
            DropIndex("dbo.Subjects", new[] { "Student_Id" });
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentRefId = c.Int(nullable: false),
                        CourseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentRefId, t.CourseRefId })
                .ForeignKey("dbo.Students", t => t.StudentRefId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.CourseRefId, cascadeDelete: true)
                .Index(t => t.StudentRefId)
                .Index(t => t.CourseRefId);
            
            DropColumn("dbo.Students", "Subject_Id");
            DropColumn("dbo.Subjects", "Student_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Student_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Subject_Id", c => c.Int());
            DropForeignKey("dbo.StudentCourse", "CourseRefId", "dbo.Subjects");
            DropForeignKey("dbo.StudentCourse", "StudentRefId", "dbo.Students");
            DropIndex("dbo.StudentCourse", new[] { "CourseRefId" });
            DropIndex("dbo.StudentCourse", new[] { "StudentRefId" });
            DropTable("dbo.StudentCourse");
            CreateIndex("dbo.Subjects", "Student_Id");
            CreateIndex("dbo.Students", "Subject_Id");
            AddForeignKey("dbo.Subjects", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}
