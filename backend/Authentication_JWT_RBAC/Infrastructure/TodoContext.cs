using Authentication_JWT_RBAC.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Authentication_JWT_RBAC.Infrastructure
{
	public class TodosContext : IdentityDbContext<ApplicationUser>
	{
        public TodosContext(DbContextOptions<TodosContext> options) : base(options) {}

		public DbSet<Todo> Todos { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
