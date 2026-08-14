namespace HospitalStaffManagement.Interfaces
{
    public interface IWorkable
    {
        bool CheckIn();
        bool CheckOut();
        void TakeLeave();
    }
}