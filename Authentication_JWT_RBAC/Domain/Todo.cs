using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication_JWT_RBAC.Domain {
    public class Todo {

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public string? Information { get; set; }
        public bool Done { get; set; } = false;


        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public string? AssignedUserId { get; set; }
        public ApplicationUser? AssignedUser { get; set; }
    }
}
