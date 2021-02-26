using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediKeeper.Persistence.Items.Config
{
    public class ItemConfig : IEntityTypeConfiguration<Domain.Item>
    {
        public void Configure(EntityTypeBuilder<Domain.Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Items", "dbo");

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Cost).IsRequired();
        }
    }
}
