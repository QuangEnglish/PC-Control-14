namespace ConsoleApp4;

public class StaffManager
{
    private List<Staff> _staffList = new List<Staff>();

    public void AddStaff(Staff staff)
    {
        _staffList.Add(staff);
    }
    public void RemoveStaff(Staff staff)
    {
        _staffList.Remove(staff);
    }

    public Staff? FindStaff(string staffId)
    {
        return _staffList.FirstOrDefault(staff => staff.StaffId == staffId);
    }
    

    public List<Staff> GetAllStaff()
    {
        return _staffList;
    }
    
    public List<T> GetStaffByType<T>() where T : Staff
    {
        return _staffList.OfType<T>().ToList();
    }

    public void CheckInAll()
    {
        _staffList.ForEach(staff => staff.CheckIn());
    }

    public void CheckOutAll()
    {
        _staffList.ForEach(staff => staff.CheckOut());
    }

    public List<Staff> PrintAllRoles()
    {
        return _staffList;
    }




}