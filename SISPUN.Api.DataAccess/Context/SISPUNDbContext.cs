using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minedu.Comun.Data;

namespace SISPUN.Api.DataAccess.Context
{
    public partial class SISPUNDbContext : DbContext, IDbContext
    {
        private readonly string _connstr;
        public SISPUNDbContext(string connstr)
        {
            this._connstr = connstr;
        }
        public SISPUNDbContext(DbContextOptions<SISPUNDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(this._connstr))
            {
                optionsBuilder.UseSqlServer(this._connstr);
            }
        }

    }
}
