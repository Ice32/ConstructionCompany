namespace ConstructionCompany.BR
{
    public interface ICRUDService<T, TSearch> : IService<T, TSearch>

    {

        T Insert(T request);



        T Update(int id, T request);

    }
}