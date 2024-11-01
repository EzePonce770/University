using Models.DTO;
using RepositoryUniversity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Interfaces;

namespace UniversityService
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _repository;
        public ProfessorService(IProfessorRepository repository)
        {
           _repository = repository;
        }

        public List<ProfessorDTO> GetProfessorCourse() 
        {
            return _repository.GetProfessorCouserseName().Result;
        }
    }
}
