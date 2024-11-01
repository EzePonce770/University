using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Interfaces
{
    public interface IArticleService
    {
        public Task<List<ArticlesResponse>> GetResultHttp();
    }
}
