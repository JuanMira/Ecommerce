namespace Ecommerce.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }

        // testing
        public override string ToString()
        {
            return $"{RoleName}";
        }
    }
}