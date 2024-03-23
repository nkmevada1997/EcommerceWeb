using System.Text;

namespace EcommerceWeb.Utility.Decode
{
    public class DecodeBase
    {
        public static string DecodeBase64(string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
    }
}
