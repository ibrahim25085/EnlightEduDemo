namespace EnlightEdu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdEduDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RegNo = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.DepartmentId)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.DepartmentId)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Subjects", new[] { "Student_Id" });
            DropIndex("dbo.Subjects", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "Subject_Id" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
        }
    }
}
