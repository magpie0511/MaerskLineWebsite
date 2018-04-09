namespace MaerskLineWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'398513dd-7e39-403e-b640-5cdc0d70d749', N'admin@maersk.com', 0, N'AM5m9oCf/XnB8jmH9MF7TxHjcGsPWnQRYNUJ5/Eup2I4wr/HpzVdcUtaOMls3N3yMw==', N'0b9bc204-efb4-419b-a5a7-a47d348b1de7', NULL, 0, 0, NULL, 1, 0, N'admin@maersk.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4697385a-ca98-4b2d-8781-05952db360ec', N'Admin')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'398513dd-7e39-403e-b640-5cdc0d70d749', N'4697385a-ca98-4b2d-8781-05952db360ec')

");

        }
        
        public override void Down()
        {
        }
    }
}
