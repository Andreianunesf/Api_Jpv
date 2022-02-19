using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PessoaService : IPessoaService
    {
        private IRepository<Pessoa> _table;

        public PessoaService(IRepository<Pessoa> repository)
        {
            _table = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _table.DeleteAsync(id);
        }

        public async Task<Pessoa> Get(Guid id)
        {
            return await _table.SelectAsync(id);
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _table.SelectAsync();
        }

        public async Task<Pessoa> Post(Pessoa p)
        {
            return await _table.InsertAsync(p);
        }

        public async Task<Pessoa> Put(Pessoa p)
        {
            return await _table.UpdateAsync(p);
        }
    }
}
