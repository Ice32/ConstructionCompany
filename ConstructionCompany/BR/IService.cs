using System.Collections.Generic;

namespace ConstructionCompany.BR
{
    public interface IService<T, TSearch>

    {

        List<T> Get(TSearch search);



        T GetById(int id);

    }
}