using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication_JWT_RBAC.Domain {
	public class ApplicationUser : IdentityUser {
        [Required, MaxLength(50)]
        public string Firstname { get; set; } = null!;

        [Required, MinLength(2), MaxLength(50)]
        public string Lastname { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        // Navigation Properties
        [InverseProperty("Author")]
        public IEnumerable<Todo> AuthorTodos { get; set; }

        [InverseProperty("AssignedUser")]
        public IEnumerable<Todo> AssignedTodos { get; set; }
    }
}
