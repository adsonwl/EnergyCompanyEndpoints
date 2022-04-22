using EnergyEndpoint.Domain.Entities;

namespace EnergyEndpoint.Infra.Data.Repository
{
    public class EndpointRepository : Repository<Endpoint>
    {
        public EndpointRepository(EnergyEndpointDbContext context) : base(context) { }
    }
}
