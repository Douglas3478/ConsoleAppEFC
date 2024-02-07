using ConsoleAppEFC.Contexts;
using ConsoleAppEFC.Entities;

namespace ConsoleAppEFC.Repositories;

internal class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
