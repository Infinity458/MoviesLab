using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenderService
    {
        public Task<ICollection<Gender>> GetAllGenders();

        public Task<Gender> GetGenderById(int genderId);

        public Task<ICollection<Actor>> GetActorsByGenderId(int genderId);
        public Task<ICollection<Director>> GetDirectorsByGenderId(int genderId);
    }
}
