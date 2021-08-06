using System.IO;

namespace Shoes_Website.Application.Products.Common
{
    public static class ProductConstant
    {
        public const string INVALID_PRODUCT_COMMAND = "Invalid Request for {0}. Try again later";

        public const string folderName = "Image_Files";

        public static string folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
    }
}
