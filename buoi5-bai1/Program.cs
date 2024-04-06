using System.Globalization;
using System.Text;

internal class Program
{
    public struct NhanVien
    {
        public string MaNV { get; set; }
        public string HoDem { get; set; }
        public string Ten {  get; set; }
        public DateTime NgayThangNamSinh { get; set; }
        public DateTime NgayVaoLamViec { get; set; }
        public NhanVien(string maNV, string hoDem,string ten, DateTime ngayThangNamSinh, DateTime ngayVaoLamViec)
        {
            MaNV = maNV;
            HoDem = hoDem;
            Ten = ten;
            NgayThangNamSinh = ngayThangNamSinh;
            NgayVaoLamViec = ngayVaoLamViec;
        }
        public int SoNamLamViec()
        {
            DateTime ngayHienTai = DateTime.Now;
            int soNam = ngayHienTai.Year - NgayVaoLamViec.Year;
            if (ngayHienTai.Month < NgayVaoLamViec.Month || (ngayHienTai.Month == NgayVaoLamViec.Month && ngayHienTai.Day < NgayVaoLamViec.Day))
                soNam--;
            return soNam;
        }

    }
    
    public static void NhapDS(List<NhanVien> ds)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Nhập số lượng nhân viên: ");
        int n = int.Parse(Console.ReadLine());
        while (n <= 0)
        {
            Console.WriteLine("Vui lòng nhập số nguyên dương !!!!");
            n = int.Parse(Console.ReadLine());
        }
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Nhập nhân viên thứ: " + (i + 1));
            Console.Write("Nhập mã nhân viên: ");
            string MaNV = Console.ReadLine();
            while (string.IsNullOrEmpty(MaNV))
            {
                Console.WriteLine("Mã nhân viên không được để trống. Vui lòng nhập lại !!!");
                MaNV = Console.ReadLine();
            }
            Console.Write("Nhập họ đệm: ");
            string HoDem = Console.ReadLine();
            while (string.IsNullOrEmpty(HoDem))
            {
                Console.WriteLine("Họ đệm không được để trống. Vui lòng nhập lại !!!");
            }
            Console.Write("Nhập tên: ");
            string Ten = Console.ReadLine();
            while (string.IsNullOrEmpty(Ten))
            {
                Console.WriteLine("Tên không được để trống. Vui lòng nhập lại !!!");
            }
            Console.Write("Nhập ngày tháng năm sinh theo định dạng (dd/mm/yyyy):");
            DateTime NgayThangNamSinh;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out NgayThangNamSinh))
            {
                Console.Write("Ngày tháng năm sinh nhập vào không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy: ");
            }
            Console.Write("Nhập ngày vào làm: ");
            DateTime NgayVaoLam;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out NgayVaoLam))
            {
                Console.Write("Ngày vào làm nhập vào không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy: ");
            }
            NhanVien x = new NhanVien(MaNV, HoDem, Ten, NgayThangNamSinh, NgayVaoLam);
            ds.Add(x);

        }
        

    }
    public static void HienThiDS(List<NhanVien> ds)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("\n\nHiện Thị Danh Sách:");
        for(int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine("Mã nhân viên: " + ds[i].MaNV);
            Console.WriteLine("Họ đệm: " + ds[i].HoDem);
            Console.WriteLine("Tên  nhân viên: " + ds[i].Ten);
            Console.WriteLine("Ngày tháng năm sinh: " + ds[i].NgayThangNamSinh);
            Console.WriteLine("Ngày vào làm: " + ds[i].NgayVaoLamViec);
            Console.WriteLine("--------------------------------------------------");
        }

    }
    public static void SapXepTheoNgaySinhGiam(List<NhanVien> ds)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("\n\nDanh sách nhân viên sắp xếp ngày sinh theo thứ tự giảm dần ");
        ds.Sort((x, y) => y.NgayThangNamSinh.CompareTo(x.NgayThangNamSinh));
    }
    public static void KinhNghiemLamViec(List<NhanVien> ds)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("\n\nDanh Sách Các Nhân Viên Có Số Năm Làm Việc Lớn Hơn Hoặc Bằng 5:");
        for (int i = 0; i < ds.Count; i++)
        {
            int soNamLamViec = ds[i].SoNamLamViec();
            if (soNamLamViec >= 5)
            {
                Console.WriteLine("Mã nhân viên: " + ds[i].MaNV);
                Console.WriteLine("Họ đệm: " + ds[i].HoDem);
                Console.WriteLine("Tên  nhân viên: " + ds[i].Ten);
                Console.WriteLine("Ngày tháng năm sinh: " + ds[i].NgayThangNamSinh);
                Console.WriteLine("Ngày vào làm: " + ds[i].NgayVaoLamViec);
                Console.WriteLine("Số năm làm việc: " + soNamLamViec);
                Console.WriteLine("--------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Không có nhân viên nào kinh nghiệm >=5.!!!");
            }
            
        }
    }
    private static void Main(string[] args)
    {
        List<NhanVien> ds = new List<NhanVien>();
        NhapDS(ds);
        HienThiDS(ds);
        SapXepTheoNgaySinhGiam(ds);
        HienThiDS(ds);
        KinhNghiemLamViec(ds);

    }
}