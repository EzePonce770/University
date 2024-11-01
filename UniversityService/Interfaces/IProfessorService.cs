using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Interfaces
{
    public interface IProfessorService
    {
        public List<ProfessorDTO> GetProfessorCourse();
    }
}
