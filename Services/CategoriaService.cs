using SistemaInventario.Interfaces.Repositories;
using SistemaInventario.Interfaces.Services;
using SistemaInventario.Models.Dto;
using SistemaInventario.Models.Entities;


namespace SistemaInventario.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<VerCategoriaDto>> GetAllCategoriaAsync()
        {
            var categoria = await _categoriaRepository.GetAllCategoriaAsync();

            var categoriaDto = categoria.Select(c => new VerCategoriaDto
            {
                Id = c.Id,
                Nombre = c.Nombre
            });

            return categoriaDto;
        }

        public async Task<VerCategoriaDto> GetCategoriaByIdAsync(int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return null;
            }
            return new VerCategoriaDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre
            };
        }

        public async Task<VerCategoriaDto> CreateCategoriaAsync(CrearCategoriaDto crearCategoriaDto)
        {
            var categoria = new Categoria
            {
                Nombre = crearCategoriaDto.Nombre
            };

            var result = await _categoriaRepository.CreateCategoriaAsync(categoria);

            if (result)
            {
                return new VerCategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre
                };
            }

            return null;
        }

        public async Task<VerCategoriaDto> UpdateCategoriaAsync(int id, CrearCategoriaDto crearCategoriaDto)
        {
            var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return null;
            }

            categoria.Nombre = crearCategoriaDto.Nombre;

            var result = await _categoriaRepository.UpdateCategoriaAsync(categoria);

            if (result)
            {
                return new VerCategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre
                };
            }

            return null;
        }

        public async Task<VerCategoriaDto> DeleteCategoriaAsync(int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return null;
            }

            var result = await _categoriaRepository.DeleteCategoriaAsync(id);

            if (result)
            {
                return new VerCategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre
                };
            }

            return null;
        }
    }
}
