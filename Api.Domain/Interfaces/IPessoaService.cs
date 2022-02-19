using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPessoaService
    {
        Task<Pessoa> Get(Guid id);
        Task<IEnumerable<Pessoa>> GetAll();

        Task<Pessoa> Post(Pessoa p);
        Task<Pessoa> Put(Pessoa p);

        Task<bool> Delete(Guid id);
    }
}
