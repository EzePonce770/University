using Microsoft.EntityFrameworkCore;
using Models.DTO;
using RepositoryUniversity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryUniversity
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly UniversityContext _context;
        public ProfessorRepository(UniversityContext context)
        {
            _context = context; 
        }

        public async Task<List<ProfessorDTO>> GetProfessorCouserseName()
        {
            var response =  await _context.Schedules.Include(x => x.Professor)
                                     .Include(x => x.Course)
                                     .Where(x => x.Professor.DepartmentDepartmentId != x.Course.DepartamentId)
                                     .Select(x => new ProfessorDTO
                                     {
                                         ProfessorName = x.Professor.Name,
                                         CourseName = x.Course.Name

                                     }).Distinct()
                                     .ToListAsync();
            return response;

        }
    }
}
