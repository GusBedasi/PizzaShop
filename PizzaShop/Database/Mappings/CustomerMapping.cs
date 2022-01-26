using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaShop.Domain;

namespace PizzaShop.Database.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(60).IsRequired();

            builder.HasMany(x => x.Orders).WithOne(x => x.Customer);
        }
    }
}