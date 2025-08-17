namespace ZaraE2E.Core.Utils
{
    public static class FileHelper
    {
        public static void EnsureDir(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        public static void WriteProductInfo(string artifactsPath, string name, string price)
        {
            EnsureDir(artifactsPath);
            var file = Path.Combine(artifactsPath, "ProductInfo.txt");
            File.WriteAllText(file, $"Ürün: {name}{Environment.NewLine}Fiyat: {price}");
        }
    }
}