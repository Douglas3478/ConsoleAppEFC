using ConsoleAppEFC.Contexts;
using ConsoleAppEFC.Entities;

namespace ConsoleAppEFC.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
