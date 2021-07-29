## Using command below to generate the migration script
``` bash
Add-Migration InitialCreate -Project Shoes-Website.Infrastructure -Context UserDbContext

Add-Migration InitialCreate -Project Shoes-Website.Infrastructure -Context ShoesWebsiteDbContext

Update-Database -Contex ShoesWebsiteDbContext
```