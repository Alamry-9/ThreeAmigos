using ThreeAmigos.Domain.Entities;
using ThreeAmigos.Domain.Interfaces.Repositories;
using ThreeAmigos.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeAmigos.Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public async Task AddStudentAsync(Student newStudent)
        {
            await _repository.Add(newStudent);
            await _repository.Save();
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
