using System.IO;

namespace Shoes_Website.Application.Products.Common
{
    public static class ProductConstant
    {
        public const string INVALID_PRODUCT_COMMAND = "Invalid Request for {0}. Try again later";

        public const string FOLDER_NAME = "Image_Files";

        public static string FOLDER_PATH = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME);
    }
}
