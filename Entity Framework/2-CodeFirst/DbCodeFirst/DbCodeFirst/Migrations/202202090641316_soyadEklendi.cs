namespace DbCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class soyadEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personel", "Soyad", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personel", "Soyad");
        }
    }
}
