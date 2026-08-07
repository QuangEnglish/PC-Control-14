# Nguyen tac thiet ke SOLID trong C#

SOLID la 5 nguyen tac thiet ke huong doi tuong giup code de bao tri, mo rong va tai su dung.

```
S - Single Responsibility Principle   (Nguyen tac don nhiem vu)
O - Open/Closed Principle             (Nguyen tac dong/mo)
L - Liskov Substitution Principle     (Nguyen tac thay the Liskov)
I - Interface Segregation Principle   (Nguyen tac phan tach Interface)
D - Dependency Inversion Principle    (Nguyen tac dao nguoc phu thuoc)
```

---

## 1. S - Single Responsibility Principle (SRP)

> Moi class chi nen co MOT nhiem vu duy nhat, MOT ly do duy nhat de thay doi.

### SAI - 1 class lam nhieu viec

```csharp
// Class Student vua chua data, vua in, vua luu database -> qua nhieu nhiem vu!
public class Student
{
    public string Name { get; set; }
    public double Score { get; set; }

    public void PrintStudent()           // Nhiem vu 1: Hien thi
    {
        Console.WriteLine($"{Name} - {Score}");
    }

    public void SaveToDatabase()         // Nhiem vu 2: Luu database
    {
        // INSERT INTO Students ...
    }

    public string ExportToPdf()          // Nhiem vu 3: Xuat PDF
    {
        return "pdf content";
    }
}
```

### DUNG - Tach rieng tung nhiem vu

```csharp
// Class Student: chi chua du lieu
public class Student
{
    public string Name { get; set; }
    public double Score { get; set; }
}

// Class rieng: chi lo hien thi
public class StudentPrinter
{
    public void Print(Student student)
    {
        Console.WriteLine($"{student.Name} - {student.Score}");
    }
}

// Class rieng: chi lo luu database
public class StudentRepository
{
    public void Save(Student student)
    {
        // INSERT INTO Students ...
    }
}

// Class rieng: chi lo xuat PDF
public class StudentExporter
{
    public string ExportToPdf(Student student)
    {
        return "pdf content";
    }
}
```

**Loi ich:** Khi thay doi cach hien thi, chi sua `StudentPrinter`, khong anh huong den database hay PDF.

---

## 2. O - Open/Closed Principle (OCP)

> Class nen MO cho viec mo rong (extension), nhung DONG cho viec sua doi (modification).
> => Them tinh nang moi ma KHONG sua code cu.

### SAI - Moi lan them hinh, phai sua class cu

```csharp
public class AreaCalculator
{
    public double Calculate(string shape, double a, double b)
    {
        if (shape == "Rectangle")
            return a * b;
        else if (shape == "Circle")       // Them hinh tron -> phai sua method nay
            return Math.PI * a * a;
        else if (shape == "Triangle")     // Them tam giac -> lai phai sua tiep!
            return a * b / 2;
        return 0;
    }
}
```

### DUNG - Mo rong bang cach them class moi, khong sua code cu

```csharp
public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea() => Width * Height;
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea() => Math.PI * Radius * Radius;
}

// Them hinh tam giac? Chi can them class moi, KHONG sua code cu!
public class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public override double CalculateArea() => Base * Height / 2;
}

// Su dung: khong can biet cu the la hinh gi
public class AreaCalculator
{
    public double Calculate(Shape shape)
    {
        return shape.CalculateArea(); // Goi chung, khong can if/else
    }
}
```

**Loi ich:** Them hinh moi = them class moi. Code cu khong bi thay doi -> khong bi loi.

---

## 3. L - Liskov Substitution Principle (LSP)

> Class con phai thay the duoc class cha ma khong lam sai logic chuong trinh.

### SAI - Class con pha vo logic class cha

```csharp
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Dang bay...");
    }
}

public class Penguin : Bird  // Chim canh cut KHONG bay duoc!
{
    public override void Fly()
    {
        throw new Exception("Chim canh cut khong bay duoc!");  // Vi pham LSP!
    }
}

// Code su dung:
void MakeBirdFly(Bird bird)
{
    bird.Fly();  // Neu truyen Penguin vao -> CRASH!
}
```

### DUNG - Tach rieng kha nang bay

```csharp
public abstract class Bird
{
    public abstract void Eat();
}

public interface IFlyable
{
    void Fly();
}

public class Sparrow : Bird, IFlyable   // Chim se: bay duoc
{
    public override void Eat() => Console.WriteLine("Chim se dang an...");
    public void Fly() => Console.WriteLine("Chim se dang bay...");
}

public class Penguin : Bird              // Chim canh cut: khong can Fly
{
    public override void Eat() => Console.WriteLine("Chim canh cut dang an...");
}
```

**Loi ich:** Bat ky cho nao dung `Bird`, truyen class con vao deu hoat dong dung, khong bi loi bat ngo.

---

## 4. I - Interface Segregation Principle (ISP)

> Khong nen ep class implement nhung method ma no KHONG CAN.
> => Tach interface lon thanh nhieu interface nho.

### SAI - Interface qua lon, ep class implement thua

```csharp
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

// Robot chi can Work, nhung bi ep phai implement Eat va Sleep!
public class Robot : IWorker
{
    public void Work() => Console.WriteLine("Robot dang lam viec");
    public void Eat() => throw new NotImplementedException();   // Vo nghia!
    public void Sleep() => throw new NotImplementedException(); // Vo nghia!
}
```

### DUNG - Tach thanh nhieu interface nho

```csharp
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

// Nhan vien: can ca 3
public class Human : IWorkable, IEatable, ISleepable
{
    public void Work() => Console.WriteLine("Nhan vien dang lam viec");
    public void Eat() => Console.WriteLine("Nhan vien dang an");
    public void Sleep() => Console.WriteLine("Nhan vien dang ngu");
}

// Robot: chi can Work
public class Robot : IWorkable
{
    public void Work() => Console.WriteLine("Robot dang lam viec");
}
```

**Loi ich:** Moi class chi implement nhung gi no thuc su can.

---

## 5. D - Dependency Inversion Principle (DIP)

> Module cap cao KHONG nen phu thuoc vao module cap thap.
> Ca hai nen phu thuoc vao ABSTRACTION (interface).

### SAI - Phu thuoc truc tiep vao class cu the

```csharp
// Class cap thap
public class MySqlDatabase
{
    public void Save(string data) => Console.WriteLine($"Luu '{data}' vao MySQL");
}

// Class cap cao phu thuoc TRUC TIEP vao MySqlDatabase
public class StudentService
{
    private MySqlDatabase _db = new MySqlDatabase();  // Dinh chet vao MySQL!

    public void SaveStudent(string name)
    {
        _db.Save(name);
    }
}

// Neu doi sang SQL Server? -> Phai sua StudentService!
```

### DUNG - Phu thuoc vao interface (abstraction)

```csharp
// Interface (abstraction)
public interface IDatabase
{
    void Save(string data);
}

// Implement cu the: MySQL
public class MySqlDatabase : IDatabase
{
    public void Save(string data) => Console.WriteLine($"Luu '{data}' vao MySQL");
}

// Implement cu the: SQL Server
public class SqlServerDatabase : IDatabase
{
    public void Save(string data) => Console.WriteLine($"Luu '{data}' vao SQL Server");
}

// Class cap cao chi phu thuoc vao IDatabase (interface)
public class StudentService
{
    private readonly IDatabase _db;

    public StudentService(IDatabase db)   // Truyen tu ben ngoai (Dependency Injection)
    {
        _db = db;
    }

    public void SaveStudent(string name)
    {
        _db.Save(name);
    }
}

// Su dung:
var service1 = new StudentService(new MySqlDatabase());      // Dung MySQL
var service2 = new StudentService(new SqlServerDatabase());  // Doi sang SQL Server
// => KHONG can sua StudentService!
```

**Loi ich:** De dang doi database, doi thanh phan ma khong sua code logic chinh.

---

## Bang tom tat

```
+-------+------------------------------------+--------------------------------------+
| Chu   | Ten                                | Y nghia ngan gon                     |
+-------+------------------------------------+--------------------------------------+
|   S   | Single Responsibility              | 1 class = 1 nhiem vu                 |
+-------+------------------------------------+--------------------------------------+
|   O   | Open/Closed                        | Mo rong = them class moi,            |
|       |                                    | KHONG sua code cu                    |
+-------+------------------------------------+--------------------------------------+
|   L   | Liskov Substitution                | Class con thay the class cha         |
|       |                                    | ma khong lam sai chuong trinh        |
+-------+------------------------------------+--------------------------------------+
|   I   | Interface Segregation              | Tach interface nho,                  |
|       |                                    | khong ep implement thua              |
+-------+------------------------------------+--------------------------------------+
|   D   | Dependency Inversion               | Phu thuoc vao interface,             |
|       |                                    | khong phu thuoc class cu the         |
+-------+------------------------------------+--------------------------------------+
```
