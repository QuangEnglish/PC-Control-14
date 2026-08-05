namespace BAI_TAP_BUOI_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bai1();
            Bai2();
            Bai3();
            Bai4();
            Bai5();
            Bai6();
            Bai7();
            Bai8();
            Bai9();
            Bai10();
        }


        static void Bai1()
        {

            Console.WriteLine("Nhap mot so nguyen: ");
            int so = Convert.ToInt32(Console.ReadLine());
            if (so == 0)
            {
                Console.WriteLine("so khong");
            }
            else if (so > 0)
            {
                Console.WriteLine("so duong");
            }
            else if (so < 0)
            {
                Console.WriteLine("so am");
            }
        }
        static void Bai2()
        {
            Console.WriteLine("Nhap mot so nguyen tu 1-7: ");
            int so2 = Convert.ToInt32(Console.ReadLine());
            if (so2 > 7 || so2 < 1)
            {
                Console.WriteLine("khong hop le");
            }
            else
            {
                switch (so2)
                {
                    case 1: Console.WriteLine("Chu Nhat"); break;
                    case 2: Console.WriteLine("Thu Hai"); break;
                    case 3: Console.WriteLine("Thu Ba"); break;
                    case 4: Console.WriteLine("Thu Tu"); break;
                    case 5: Console.WriteLine("Thu Nam"); break;
                    case 6: Console.WriteLine("Thu Sau"); break;
                    case 7: Console.WriteLine("Thu Bay"); break;
                }
            }

        }
        static void Bai3()
        {
            int i = 1;
            while (i <= 10)
            {
                Console.WriteLine(i);
                i++;
            }
        }
        static void Bai4()
        {
            Console.WriteLine("Nhap mot so nguyen n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int tong = 0;
            for (int i1 = 1; i1 <= n; i1++)

            {
                tong = tong + i1;
            }
            Console.WriteLine(tong);
        }
        static void Bai5()
        {
            int[] mang = new int[5];
            for (int i5 = 0; i5 < mang.Length; i5++)

            {
                Console.Write($"Nhap phan tu thu {i5 + 1}: ");
                mang[i5] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Cac phan tu trong mang la: ");
            for (int i5 = 0; i5 < mang.Length; i5++)
            {
                Console.WriteLine(mang[i5]);
            }
        }
        static void Bai6()
        {
            Console.WriteLine("Nhap so luong phan tu n: ");
            int so6 = Convert.ToInt32(Console.ReadLine());
            int soduong = 0;
            int soam = 0;
            int sokhong = 0;
            for (int i6 = 0; i6 <= so6; i6++)
            {
                if (i6 > 0)
                {
                    soduong++;
                }
                else if (i6 < 0)
                {
                    soam++;
                }
                else
                {
                    sokhong++;
                }
            }



            Console.WriteLine("So luong so duong: " + soduong);
            Console.WriteLine("So luong so am: " + soam);
            Console.WriteLine("So luong so bang 0: " + sokhong);

        }
        static void Bai7()
        {
            Console.Write("Nhap so a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap so b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhap phep toan (+, -, *, /): ");
            char phepToan = Convert.ToChar(Console.ReadLine());
            switch (phepToan)
            {
                case '+':
                    Console.WriteLine($"Ket qua: {a + b}");
                    break;
                case '-':
                    Console.WriteLine($"Ket qua: {a - b}");
                    break;
                case '*':
                    Console.WriteLine($"Ket qua: {a * b}");
                    break;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("Loi: Khong the chia cho 0!");
                    }
                    else
                    {
                        Console.WriteLine($"Ket qua:  {a / b}");
                    }
                    break;
                default:
                    Console.WriteLine("Phep toan khong hop le!");
                    break;
            }
        }
    

    static void Bai8()
        {
            int tongLeDuong = 0;

            while (true)
            {
                Console.Write("Nhap mot so nguyen: ");
                int so8 = Convert.ToInt32(Console.ReadLine());

                if (so8 < 0)
                {
                    break;
                }

                if (so8 % 2 == 0)
                {
                    continue;
                }

                tongLeDuong = tongLeDuong + so8;
            }

            Console.WriteLine("Tong cac so le duong la: " + tongLeDuong);
        }
        static void Bai9()
        {
            Console.Write("Nhap so luong phan tu cua mang: ");
            int n9 = Convert.ToInt32(Console.ReadLine());

            int[] arrNumber = new int[n9];

            for (int i9 = 0; i9 < arrNumber.Length; i9++)
            {
                Console.Write($"Nhap phan tu thu {i9 + 1}: ");
                arrNumber[i9] = Convert.ToInt32(Console.ReadLine());
            }

            int max = arrNumber[0];
            int min = arrNumber[0];
            double tong = 0;

            for (int i9 = 0; i9 < arrNumber.Length; i9++)
            {
                if (arrNumber[i9] > max)
                {
                    max = arrNumber[i9];
                }

                if (arrNumber[i9] < min)
                {
                    min = arrNumber[i9];
                }

                tong = tong + arrNumber[i9];
            }

            double trungBinhCong = tong / n9;

            Console.WriteLine("So lon nhat: " + max);
            Console.WriteLine("So nho nhat: " + min);
            Console.WriteLine("Trung binh cong: " + trungBinhCong);

            Console.WriteLine("Cac phan tu theo thu tu nguoc lai:");
            for (int i9 = arrNumber.Length - 1; i9 >= 0; i9--)
            {
                Console.Write(arrNumber[i9] + " ");
            }
            Console.WriteLine();
        }
        static void Bai10()
        {
            Console.Write("Nhap so luong hoc sinh n: ");
            int n10 = Convert.ToInt32(Console.ReadLine());

            double[] arrDiem = new double[n10];

            for (int i10 = 0; i10 < arrDiem.Length; i10++)
            {
                Console.Write($"Nhap diem cua hoc sinh thu {i10 + 1}: ");
                arrDiem[i10] = Convert.ToDouble(Console.ReadLine());
            }

            int demGioi = 0;
            int demKha = 0;
            int demTrungBinh = 0;
            int demYeu = 0;

            for (int i10 = 0; i10 < arrDiem.Length; i10++)
            {
                if (arrDiem[i10] >= 8)
                {
                    demGioi++;
                }
                else if (arrDiem[i10] >= 6.5)
                {
                    demKha++;
                }
                else if (arrDiem[i10] >= 5)
                {
                    demTrungBinh++;
                }
                else
                {
                    demYeu++;
                }
            }
            Console.WriteLine("So hoc sinh Gioi: " + demGioi);
            Console.WriteLine("So hoc sinh Kha: " + demKha);
            Console.WriteLine("So hoc sinh Trung binh: " + demTrungBinh);
            Console.WriteLine("So hoc sinh Yeu: " + demYeu);
        }

    }
    }
    

    

