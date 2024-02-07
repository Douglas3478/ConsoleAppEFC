using ConsoleAppEFC.Contexts;
using ConsoleAppEFC.Entities;

namespace ConsoleAppEFC.Repositories;

internal class RoleRepository : Repo<RoleEntity>
{
    public RoleRepository(DataContext context) : base(context)
    {
    }
}
