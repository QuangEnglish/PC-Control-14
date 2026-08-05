namespace BAI_6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao mot chuoi: ");
            string chuoiA = Console.ReadLine();

            foreach (char kytu in chuoiA)
            {
                Console.WriteLine(kytu);
            }

            Console.Write("Nhap vao mot chuoi nhieu tu: ");
            string chuoiB = Console.ReadLine();

            string[] cacTu = chuoiB.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string tu in cacTu)
            {
                Console.WriteLine(tu);
            }

            Console.Write("Nhap vao mot chuoi can dem: ");
            string chuoiC = Console.ReadLine();

            string daDem = "";

            for (int i = 0; i < chuoiC.Length; i++)
            {
                char kyTuHienTai = chuoiC[i];

                if (!daDem.Contains(kyTuHienTai.ToString()))
                {
                    int soLan = 0;

                    for (int j = 0; j < chuoiC.Length; j++)
                    {
                        if (chuoiC[j] == kyTuHienTai)
                        {
                            soLan++;
                        }
                    }

                    Console.WriteLine("Ky tu " + kyTuHienTai + " xuat hien: " + soLan + " lan");
                    daDem += kyTuHienTai;
                }
            }

            Console.ReadLine();
        }
    }
}
