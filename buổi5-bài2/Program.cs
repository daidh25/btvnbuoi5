using System.Globalization;
using System.Text;

internal class Program
{
    public struct Product
    {
        public string ProDuctName {  get; set; }
        public double ProDuctPrice { get; set; }
        public DateTime ExpiredDate { get; set; }
        public Product(string productName, double productPrice,DateTime expiredDate)
        {
            ProDuctName = productName;
            ProDuctPrice = productPrice;
            ExpiredDate = expiredDate;
        }
        public bool IsExpired()
        {
            TimeSpan remainingTime = ExpiredDate - DateTime.Today;
            return remainingTime.TotalDays < 180;
        }
    }
    public static void NhapTTSP(List<Product> ds)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Nhập số lượng sản phẩm: ");
        int n = int.Parse(Console.ReadLine());
        while (n <= 0)
        {
            Console.WriteLine("Vui lòng nhập số nguyên dương !!!");
            n= int.Parse(Console.ReadLine());
        }
        for(int i = 0;i<n;i++)
        {
            Console.WriteLine("Nhập sản phẩm thứ: "+(i+1));
            Console.Write("Nhập ProductName: ");
            string ProDuctName = Console.ReadLine();
            while(string.IsNullOrEmpty(ProDuctName))
            {
                Console.Write("Vui lòng nhập ProductName.Không được để trống ! ");
                ProDuctName = Console.ReadLine();
            }
            Console.Write("Nhập ProductPrice: ");
            double ProDuctPrice = Convert.ToDouble(Console.ReadLine());
            while (ProDuctPrice < 0)
            {
                Console.WriteLine("Gía sản phẩm không âm.Vui lòng nhập lại !!");
                ProDuctPrice = Convert.ToDouble(Console.ReadLine());
            }
            Console.Write("Nhập ExpiredDate theo dạng (dd/mm/yyyy): ");
            DateTime ExpiredDate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ExpiredDate))
            {
                Console.Write("Ngày sản phẩm hết hạn nhập vào không hợp lệ. Vui lòng nhập lại theo định dạng dd/MM/yyyy: ");
            }
            Console.WriteLine();
            Product x = new Product( ProDuctName, ProDuctPrice, ExpiredDate);
            ds.Add(x);
        }
    }
    private static void Main(string[] args)
    {
        List<Product> ds = new List<Product>();
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=====================Hiển Thị Thông Tin Sản Phẩm ====================");
        NhapTTSP(ds);
        Console.WriteLine("\nCác sản phẩm có ngày hết hạn trong vòng 30 ngày:");
        for (int i = 0; i < ds.Count; i++)
        {
            if (ds[i].IsExpired())
            {
                Console.WriteLine($"Tên sản phẩm: {ds[i].ProDuctName}, Giá sản phẩm: {ds[i].ProDuctPrice}, Ngày hết hạn: {ds[i].ExpiredDate:dd/MM/yyyy}");
            }
        }

       
        Console.WriteLine("\nCác sản phẩm có tên sản phẩm dài hơn 10 ký tự:");
        for (int i = 0; i < ds.Count; i++)
        {
            if (ds[i].ProDuctName.Length > 10)
            {
                Console.WriteLine($"Tên sản phẩm: {ds[i].ProDuctName}, \nGiá sản phẩm: {ds[i].ProDuctPrice}, \nNgày hết hạn: {ds[i].ExpiredDate:dd/MM/yyyy}");
            }
            else
            {
                Console.WriteLine("Không có sản phẩm nào kí tự dài hơn 10...");
            }
        }
    }
}
