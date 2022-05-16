namespace OgrenciProjeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class İlk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),    
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        CityId = c.Int(nullable: false),
                        MotherName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)   //False yap
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Surname = c.String(),
                        CityId = c.Int(nullable: false),
                        MotherName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)    //False yap
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teacher", "CityId", "dbo.City");
            DropForeignKey("dbo.Student", "CityId", "dbo.City");
            DropIndex("dbo.Teacher", new[] { "CityId" });
            DropIndex("dbo.Student", new[] { "CityId" });
            DropTable("dbo.Teacher");
            DropTable("dbo.Student");
            DropTable("dbo.City");
        }
    }
}
