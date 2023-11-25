using CleanArch.Core.Domain.Entities;
using System.Collections;

namespace CleanArch.Core.Domain.Collections.Empresa
{
    public class EmpresasCollection : IEnumerable<EmpresaEntity>
    {
        private readonly IEnumerable<EmpresaEntity> Items;

        public EmpresasCollection(IEnumerable<EmpresaEntity> items)
        {
            Items = items;
        }

        public IEnumerator<EmpresaEntity> GetEnumerator() => Items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
    }
}
