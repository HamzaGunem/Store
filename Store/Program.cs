using Store.Products;

namespace Store
{
    internal class Program
    {
        public static void Main()
        {
            var onlineStore = new OnlineStore();
            onlineStore.Start();
        }
    }
}
