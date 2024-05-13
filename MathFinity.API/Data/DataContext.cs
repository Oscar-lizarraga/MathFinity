using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MathFinity.API;


public class DataContext: IdentityDbContext
{
    public DataContext(DbContextOptions<DataContext> options): base (options)
    {

    }
}
