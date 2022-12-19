using DemoApplication.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DemoApplication.Database.Configurations
{
    public class SiteColorConfigurations : IEntityTypeConfiguration<SiteColor>
    {
        public void Configure(EntityTypeBuilder<SiteColor> builder)
        {
            builder
               .ToTable("SiteColors");
        }
    }
}
