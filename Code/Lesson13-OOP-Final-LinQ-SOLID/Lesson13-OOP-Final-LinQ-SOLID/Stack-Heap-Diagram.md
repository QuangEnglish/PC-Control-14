# Stack vs Heap trong C#

## 1. Quy tac chung

```
- Value Type (int, double, bool, struct...)  -> luu tren STACK
- Reference Type (class, string, array...)   -> luu tren HEAP, STACK chi giu dia chi (reference)
```

---

## 2. So do voi code demo hien tai

```csharp
int x = 10;
double score = 8.5;
string name = "An";
var sv1 = new Student { Id = 1, Name = "An", Age = 18, Score = 8.5 };
var sv2 = new Student { Id = 1, Name = "Khac Ten", Age = 99, Score = 0 };
var sv3 = sv1;
```

```
        STACK                                    HEAP
  (bo nho ngan xep)                        (bo nho dong)
 +-------------------+
 |                   |
 |  x = 10           |    (value type - luu truc tiep tren Stack)
 |                   |
 |  score = 8.5      |    (value type - luu truc tiep tren Stack)
 |                   |
 |  name  = 0x300 ---|----------------> +----------------------------+
 |                   |                  | "An"            (0x300)    |
 |                   |                  +----------------------------+
 |                   |
 |  sv1   = 0x100 ---|----------------> +----------------------------+
 |                   |                  | Student Object  (0x100)    |
 |                   |                  |   Id    = 1                |
 |                   |                  |   Name  = 0x300 ---> "An"  |
 |                   |                  |   Age   = 18               |
 |                   |                  |   Score = 8.5              |
 |                   |                  +----------------------------+
 |                   |
 |  sv2   = 0x200 ---|----------------> +----------------------------+
 |                   |                  | Student Object  (0x200)    |
 |                   |                  |   Id    = 1                |
 |                   |                  |   Name  = 0x400 -> "Khac"  |
 |                   |                  |   Age   = 99               |
 |                   |                  |   Score = 0                |
 |                   |                  +----------------------------+
 |                   |
 |  sv3   = 0x100 ---|------+
 |                   |      |  (cung tro den 0x100 voi sv1!)
 +-------------------+      |
                             +--------> +----------------------------+
                                        | Student Object  (0x100)    |
                                        |   (CUNG OBJECT voi sv1)    |
                                        +----------------------------+
```

---

## 3. Giai thich chi tiet

### Value Type (int, double, bool, struct...)

```
 STACK
+------------------+
|  int x = 10      |  <-- Gia tri 10 nam TRUC TIEP tren Stack
|  double d = 8.5  |  <-- Gia tri 8.5 nam TRUC TIEP tren Stack
+------------------+

=> Khi gan: int y = x;
=> y COPY gia tri cua x -> thay doi y KHONG anh huong x

 STACK
+------------------+
|  x = 10          |
|  y = 10          |  <-- Ban sao doc lap
+------------------+
```

### Reference Type (class, array, string...)

```
 STACK                          HEAP
+------------------+
|  sv1 = 0x100  ---|-------->  +--------------------+
+------------------+           | Student Object     |
                               | Id=1, Name="An"    |
                               +--------------------+

=> Khi gan: var sv3 = sv1;
=> sv3 COPY DIA CHI (0x100) -> ca hai tro cung 1 object

 STACK                          HEAP
+------------------+
|  sv1 = 0x100  ---|---+
|  sv3 = 0x100  ---|---+---->  +--------------------+
+------------------+           | Student Object     |
                               | Id=1, Name="An"    |
                               +--------------------+

=> sv3.Score = 10000;  -> sv1.Score cung = 10000 (vi cung object!)
```

---

## 4. Bang tom tat

```
+------------------+------------------+---------------------------+
|                  |    VALUE TYPE    |      REFERENCE TYPE       |
+------------------+------------------+---------------------------+
| Vi du            | int, double,     | class, string,            |
|                  | bool, struct     | array, object             |
+------------------+------------------+---------------------------+
| Luu o dau?       | STACK            | HEAP (Stack giu dia chi)  |
+------------------+------------------+---------------------------+
| Khi gan (=)      | Copy GIA TRI    | Copy DIA CHI (reference)  |
+------------------+------------------+---------------------------+
| == mac dinh      | So sanh gia tri  | So sanh dia chi           |
+------------------+------------------+---------------------------+
| Equals mac dinh  | So sanh gia tri  | So sanh dia chi           |
+------------------+------------------+---------------------------+
| Sau override     | (khong can)      | Equals: theo logic ban    |
| Equals           |                  | ==: van so sanh dia chi   |
+------------------+------------------+---------------------------+
```

---

## 5. Lien he voi demo trong Program.cs

```csharp
var sv3 = sv1;        // sv3 va sv1 cung tro den 1 object tren Heap
sv3.Score = 10000;    // => sv1.Score cung = 10000!

sv1.Equals(sv2)       // True  -> vi override Equals chi so sanh Id
sv1 == sv2            // False -> == van so sanh dia chi (0x100 != 0x200)
sv1 == sv3            // True  -> cung dia chi 0x100
```
