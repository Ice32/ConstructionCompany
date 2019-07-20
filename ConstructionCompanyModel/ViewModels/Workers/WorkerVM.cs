using ConstructionCompanyModel.ViewModels.Users;

namespace ConstructionCompanyModel.ViewModels.Workers
{
    public class WorkerVM: IUserType
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserVM User { get; set; }
        public string JobDescription { get; set; }
        public string TelephoneNumber { get; set; }
        
        public override bool Equals(object obj)
        {
            var item = obj as WorkerVM;

            if (item == null)
            {
                return false;
            }

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}