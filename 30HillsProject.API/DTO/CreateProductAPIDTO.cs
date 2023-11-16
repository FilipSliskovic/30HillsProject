using _30HillsProject.Application.UseCases.DTO;

namespace _30HillsProject.API.DTO
{
    public class CreateProductAPIDTO : CreateProductDTO
    {
        public ICollection<IFormFile> Images { get; set; }
    }
}
