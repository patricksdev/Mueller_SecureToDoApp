namespace Authentication_JWT_RBAC.Domain.DTOs.ToDo {
    public class TodoDTO {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public string? Information { get; set; }

        public string AuthorId { get; set; } = null!;
        public string? AssignedUserId { get; set; }
    }
}
