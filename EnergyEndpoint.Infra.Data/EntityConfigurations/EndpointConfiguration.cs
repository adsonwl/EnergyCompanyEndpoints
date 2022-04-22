using EnergyEndpoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyEndpoint.Infra.Data.EntityConfigurations
{
    internal class EndpointConfiguration : IEntityTypeConfiguration<Endpoint>
    {
        public void Configure(EntityTypeBuilder<Endpoint> builder)
        {
            builder.Property(p => p.SerialNumber).HasMaxLength(128).IsRequired();
            builder.Property(p => p.MeterFirmwareVersion).HasMaxLength(128).IsRequired();
            builder.Property(p => p.MeterModelId).IsRequired();
            builder.Property(p => p.MeterNumber).IsRequired();
            builder.Property(p => p.SwitchState).IsRequired();
        }

    }
}
