namespace DbCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class İlk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personel",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.PersonelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personel");
        }
    }
}
