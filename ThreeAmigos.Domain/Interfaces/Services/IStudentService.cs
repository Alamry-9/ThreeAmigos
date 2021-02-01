using ThreeAmigos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeAmigos.Domain.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task AddStudentAsync(Student newStudent);
    }
}
