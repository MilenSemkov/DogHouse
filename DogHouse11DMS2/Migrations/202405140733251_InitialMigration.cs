namespace DogHouse11DMS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.String(),
                        RegisterOn = c.DateTime(nullable: false),
                        BreedsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedsId, cascadeDelete: true)
                .Index(t => t.BreedsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogs", "BreedsId", "dbo.Breeds");
            DropIndex("dbo.Dogs", new[] { "BreedsId" });
            DropTable("dbo.Dogs");
            DropTable("dbo.Breeds");
        }
    }
}
