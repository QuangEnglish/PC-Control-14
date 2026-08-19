# PROJECT LUYỆN TẬP OOP TRONG C#

## - MỤC TIÊU DỰ ÁN

Xây dựng **Hệ thống Quản lý Nhân viên Bệnh viện** (Hospital Staff Management System) bằng Console Application, áp dụng đầy đủ 4 tính chất của OOP:

| Tính chất                    | Áp dụng trong project                                             |
| ---------------------------- | ----------------------------------------------------------------- |
| **Encapsulation** (Đóng gói) | Private fields, Public properties, Validation trong setter        |
| **Inheritance** (Kế thừa)    | Class cha `Staff`, các class con `Doctor`, `Nurse`, `Pharmacist`  |
| **Polymorphism** (Đa hình)   | Override method `GetRole()`, `CheckIn()`, `CheckOut()`            |
| **Abstraction** (Trừu tượng) | Abstract class `Staff`, Interface `IWorkable`                     |

---

## - ĐỀ BÀI CHI TIẾT

### PHẦN 1: TẠO CẤU TRÚC CLASS

#### 1.1. Tạo Interface `IWorkable`

Interface này định nghĩa các hành động làm việc mà nhân viên có thể thực hiện.

**Yêu cầu:**

- Method `CheckIn()` - Nhân viên vào ca, trả về `bool`
- Method `CheckOut()` - Nhân viên ra ca, trả về `bool`
- Method `TakeLeave()` - Xin nghỉ phép, trả về `void`

---

#### 1.2. Tạo Abstract Class `Staff` (Class cha)

Đây là class cơ sở cho tất cả nhân viên, **implement interface `IWorkable`**.

**Yêu cầu về Fields (private):**

- `_staffId` : string - Mã nhân viên
- `_fullName` : string - Họ tên nhân viên
- `_department` : string - Khoa/Phòng ban
- `_isOnDuty` : bool - Trạng thái đang trực hay không
- `_hireDate` : DateTime - Ngày vào làm

**Yêu cầu về Properties (public):**

- Tất cả fields trên đều có Property tương ứng
- Property `StaffId`: chỉ cho phép **đọc** (get), không cho sửa từ bên ngoài
- Property `FullName`: có **validation** - không được để trống
- Property `IsOnDuty`: chỉ cho phép **đọc** từ bên ngoài

**Yêu cầu về Constructor:**

- Nhận 3 tham số: `staffId`, `fullName`, `department`
- Tự động gán `_hireDate = DateTime.Now`
- Tự động gán `_isOnDuty = false`

**Yêu cầu về Methods:**

- `GetRole()` : **abstract** method, trả về `string` - Mỗi loại nhân viên sẽ override khác nhau
- `GetInfo()` : **virtual** method, trả về `string` - Thông tin cơ bản của nhân viên
- `CheckIn()` : Implement từ interface, set `_isOnDuty = true`, return `true`
- `CheckOut()` : Implement từ interface, set `_isOnDuty = false`, return `true`
- `TakeLeave()` : Implement từ interface, gọi `CheckOut()` rồi in ra "Nhân viên đã xin nghỉ phép"

---

#### 1.3. Tạo Class `Doctor` (Kế thừa từ Staff)

Đại diện cho bác sĩ trong bệnh viện.

**Yêu cầu về Fields riêng:**

- `_specialty` : string - Chuyên khoa (Nội, Ngoại, Tim mạch, Thần kinh...)
- `_patientCount` : int - Số bệnh nhân đang phụ trách
- `_maxPatients` : int - Số bệnh nhân tối đa có thể nhận
- `_licenseNumber` : string - Số giấy phép hành nghề

**Yêu cầu về Properties:**

- Tất cả fields có Property tương ứng
- Property `PatientCount`: có **validation** - không được âm và không vượt quá `MaxPatients`

**Yêu cầu về Constructor:**

- Gọi constructor của class cha (base)
- Nhận thêm các tham số: `specialty`, `maxPatients`, `licenseNumber`
- Gán `_patientCount = 0`

**Yêu cầu về Methods:**

- **Override** `GetRole()`: Trả về chuỗi dạng `"Bác sĩ [specialty]: patientCount/maxPatients bệnh nhân (Đang trực/Nghỉ)"`
- **Override** `GetInfo()`: Gọi `base.GetInfo()` + thêm thông tin riêng của Doctor
- `AcceptPatient()`: Tăng `PatientCount` lên 1, trả về `bool` (false nếu đã đầy)
- `DischargePatient()`: Giảm `PatientCount` đi 1, trả về `bool` (false nếu đang 0)

---

#### 1.4. Tạo Class `Nurse` (Kế thừa từ Staff)

Đại diện cho y tá/điều dưỡng.

**Yêu cầu về Fields riêng:**

- `_ward` : string - Khu vực phụ trách (Khu A, Khu B, ICU...)
- `_shiftType` : string - Loại ca trực (Sáng, Chiều, Đêm)
- `_totalHoursWorked` : double - Tổng số giờ đã làm trong tháng

**Yêu cầu về Properties:**

- Tất cả fields có Property tương ứng
- Property `TotalHoursWorked`: có **validation** - không được âm và không vượt quá 300 giờ/tháng

**Yêu cầu về Constructor:**

- Gọi constructor của class cha (base)
- Nhận thêm các tham số: `ward`, `shiftType`
- Gán `_totalHoursWorked = 0`

**Yêu cầu về Methods:**

- **Override** `GetRole()`: Trả về `"Điều dưỡng [name]: Ca shiftType - Khu ward (Đang trực/Nghỉ)"`
- **Override** `GetInfo()`: Gọi `base.GetInfo()` + thêm thông tin khu vực, ca trực
- **Override** `CheckIn()`: Gọi `base.CheckIn()` + in ra ca trực hiện tại
- **Override** `CheckOut()`: Gọi `base.CheckOut()` + cộng 8 giờ vào `TotalHoursWorked`
- `ChangeShift(string newShift)`: Đổi ca trực, có validation (chỉ nhận "Sáng", "Chiều", "Đêm")

---

#### 1.5. Tạo Class `Pharmacist` (Kế thừa từ Staff)

Đại diện cho dược sĩ.

**Yêu cầu về Fields riêng:**

- `_pharmacyBranch` : string - Chi nhánh nhà thuốc (Nhà thuốc chính, Nhà thuốc cấp cứu...)
- `_certificateLevel` : string - Bằng cấp (Dược sĩ Đại học, Dược sĩ Cao đẳng...)
- `_prescriptionCount` : int - Số đơn thuốc đã xử lý trong ngày
- `_isLicenseValid` : bool - Giấy phép còn hiệu lực không

**Yêu cầu về Properties:**

- Tất cả fields có Property tương ứng
- Property `PrescriptionCount`: có **validation** - không được âm
- Property `IsLicenseValid`: chỉ cho phép **đọc** từ bên ngoài

**Yêu cầu về Constructor:**

- Gọi constructor của class cha (base)
- Nhận thêm các tham số: `pharmacyBranch`, `certificateLevel`
- Gán `_prescriptionCount = 0`
- Gán `_isLicenseValid = true`

**Yêu cầu về Methods:**

- **Override** `GetRole()`: Trả về `"Dược sĩ [certificateLevel]: branch - prescriptionCount đơn đã xử lý (Đang trực/Nghỉ)"`
- **Override** `GetInfo()`: Gọi `base.GetInfo()` + thêm thông tin chi nhánh, bằng cấp
- `ProcessPrescription()`: Tăng `PrescriptionCount` lên 1, in thông báo. Chỉ xử lý được khi `IsLicenseValid = true`
- `RenewLicense()`: Set `_isLicenseValid = true`, in thông báo
- **Override** `CheckIn()`: Chỉ vào ca được khi `IsLicenseValid = true`, nếu hết hạn thì return `false`

---

#### 1.6. Tạo Class `StaffManager`

Class quản lý danh sách tất cả nhân viên.

**Yêu cầu về Fields:**

- `_staffList` : `List<Staff>` - Danh sách nhân viên

**Yêu cầu về Methods:**

- `AddStaff(Staff staff)`: Thêm nhân viên vào danh sách
- `RemoveStaff(string staffId)`: Xóa nhân viên theo ID
- `FindStaff(string staffId)`: Tìm nhân viên theo ID, trả về `Staff` hoặc `null`
- `GetAllStaff()`: Trả về danh sách tất cả nhân viên
- `GetStaffByType<T>()`: Trả về danh sách nhân viên theo loại (dùng Generic)
- `CheckInAll()`: Tất cả nhân viên vào ca
- `CheckOutAll()`: Tất cả nhân viên ra ca
- `PrintAllRoles()`: In vai trò tất cả nhân viên (dùng **Polymorphism** - gọi GetRole())

---

### PHẦN 2: VIẾT CHƯƠNG TRÌNH CHÍNH (Program.cs)

Tạo menu console với các chức năng:

```
========================================
   HOSPITAL STAFF MANAGEMENT SYSTEM
========================================
1. Hiển thị tất cả nhân viên
2. Hiển thị vai trò nhân viên
3. Thêm nhân viên mới
4. Tìm kiếm nhân viên theo ID
5. Vào ca (Check In)
6. Ra ca (Check Out)
7. Tất cả vào ca
8. Tất cả ra ca
9. Tiếp nhận / Xuất viện bệnh nhân (Doctor)
10. Đổi ca trực (Nurse)
11. Xử lý đơn thuốc (Pharmacist)
0. Thoát
========================================
Chọn chức năng: _
```

---

### PHẦN 3: KẾT QUẢ MONG ĐỢI

#### 3.1. Khi chọn "1. Hiển thị tất cả nhân viên":

```
=== DANH SÁCH NHÂN VIÊN ===

[1] DOCTOR - BS001
    Họ tên: Nguyễn Văn An
    Khoa: Tim mạch
    Chuyên khoa: Tim mạch | GPHM: BS-2024-001
    Bệnh nhân: 0/20
    Ngày vào làm: 10/08/2026

[2] NURSE - DD001
    Họ tên: Trần Thị Bình
    Khoa: Nội tổng hợp
    Khu vực: ICU | Ca trực: Sáng
    Giờ làm tháng này: 0 giờ
    Ngày vào làm: 10/08/2026

[3] PHARMACIST - DS001
    Họ tên: Lê Văn Cường
    Khoa: Dược
    Chi nhánh: Nhà thuốc chính | Bằng cấp: Dược sĩ Đại học
    Đơn đã xử lý hôm nay: 0
    Ngày vào làm: 10/08/2026

Tổng: 3 nhân viên
```

#### 3.2. Khi chọn "2. Hiển thị vai trò":

```
=== VAI TRÒ NHÂN VIÊN ===

BS001: Bác sĩ Tim mạch: 0/20 bệnh nhân (Nghỉ)
DD001: Điều dưỡng Trần Thị Bình: Ca Sáng - Khu ICU (Nghỉ)
DS001: Dược sĩ Dược sĩ Đại học: Nhà thuốc chính - 0 đơn đã xử lý (Nghỉ)
```

#### 3.3. Khi tiếp nhận bệnh nhân:

```
Nhập ID Bác sĩ: BS001
>> Bác sĩ Nguyễn Văn An đã tiếp nhận bệnh nhân!
>> Số bệnh nhân hiện tại: 1/20
```

#### 3.4. Khi xử lý đơn thuốc:

```
Nhập ID Dược sĩ: DS001
>> Đang xử lý đơn thuốc...
>> Dược sĩ Lê Văn Cường đã xử lý đơn thuốc thành công!
>> Tổng đơn hôm nay: 1
```

---

## - CẤU TRÚC THƯ MỤC PROJECT

```
HospitalStaffManagement/
│
├── Interfaces/
│   └── IWorkable.cs
│
├── Models/
│   ├── Staff.cs            (Abstract class)
│   ├── Doctor.cs            (Kế thừa Staff)
│   ├── Nurse.cs             (Kế thừa Staff)
│   └── Pharmacist.cs        (Kế thừa Staff)
│
├── Services/
│   └── StaffManager.cs
│
└── Program.cs
```

---

## - CHECKLIST ĐÁNH GIÁ

Học viên tự kiểm tra đã hoàn thành các yêu cầu sau:

### Encapsulation (Đóng gói)

- [ ] Tất cả fields đều là `private`
- [ ] Sử dụng Properties để truy cập fields
- [ ] Có validation trong setter của ít nhất 3 properties
- [ ] Có property chỉ cho đọc (get only)

### Inheritance (Kế thừa)

- [ ] Class `Doctor`, `Nurse`, `Pharmacist` kế thừa từ `Staff`
- [ ] Sử dụng từ khóa `base` để gọi constructor cha
- [ ] Sử dụng `base.MethodName()` để gọi method của class cha

### Polymorphism (Đa hình)

- [ ] Method `GetRole()` được override ở tất cả class con
- [ ] Method `GetInfo()` được override và gọi `base.GetInfo()`
- [ ] `StaffManager.PrintAllRoles()` gọi `GetRole()` và mỗi loại nhân viên hiển thị khác nhau

### Abstraction (Trừu tượng)

- [ ] Class `Staff` là abstract class
- [ ] Method `GetRole()` là abstract method
- [ ] Interface `IWorkable` được implement bởi class `Staff`

### Khác

- [ ] Code có comment giải thích đầy đủ
- [ ] Chương trình chạy không lỗi
- [ ] Menu console hoạt động đúng

---

## - GỢI Ý TRIỂN KHAI

### Thứ tự code:

1. Tạo `IWorkable.cs` trước
2. Tạo `Staff.cs` (abstract class)
3. Tạo `Doctor.cs`, `Nurse.cs`, `Pharmacist.cs`
4. Tạo `StaffManager.cs`
5. Viết `Program.cs`

### Lưu ý:

- Mỗi file một class/interface
- Comment bằng tiếng Việt cho dễ hiểu
- Test từng class trước khi ghép lại

---

## - KIẾN THỨC CẦN NHỚ

### 1. Cú pháp Abstract Class & Method

```csharp
public abstract class Staff
{
    public abstract string GetRole();  // Không có body
}
```

### 2. Cú pháp Override

```csharp
public override string GetRole()
{
    return "...";  // Phải có body
}
```

### 3. Cú pháp Interface

```csharp
public interface IWorkable
{
    bool CheckIn();
    bool CheckOut();
}
```

### 4. Cú pháp Property với Validation

```csharp
private int _patientCount;
public int PatientCount
{
    get { return _patientCount; }
    set
    {
        if (value < 0 || value > _maxPatients)
            throw new ArgumentException("Số bệnh nhân không hợp lệ!");
        _patientCount = value;
    }
}
```

### 5. Gọi Constructor cha

```csharp
public Doctor(string id, string name, string department, string specialty)
    : base(id, name, department)  // Gọi constructor của Staff
{
    _specialty = specialty;
}
```
