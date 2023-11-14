

namespace _30HillsProject.Domain
{
    public class Category : Entity
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }



        public ICollection<Category> ChildCategories { get; set; } = new List<Category>();
        public Category? ParentCategory { get; set; }
    }
}