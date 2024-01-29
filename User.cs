using Part4;

namespace Part4
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}