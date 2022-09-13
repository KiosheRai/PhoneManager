using Microsoft.EntityFrameworkCore;
using PhoneManager.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneManager.Application.Interfaces
{
    public interface IPhoneManagerDbContext
    {
        DbSet<Phone> Phones { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
