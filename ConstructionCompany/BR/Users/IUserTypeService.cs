namespace ConstructionCompany.BR.Users
{
    public interface IUserTypeService<T>: IService<T, UserSearch>
    {
        T Insert(T user, string password);
        T Update(T user, string password);
    }
}
