namespace OgrenciProjeCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MotherNamedegistir : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "MotherName", c => c.String());
            AlterColumn("dbo.Teacher", "MotherName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teacher", "MotherName", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "MotherName", c => c.Int(nullable: false));
        }
    }
}
