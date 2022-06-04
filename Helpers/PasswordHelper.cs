using System.Text;
namespace Ecommerce.Helpers
{
    public class PasswordHelper
    {

        public static string EncryptPassword(string password)
        {
            try
            {
                byte[] encData = new byte[password.Length];
                encData = Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData);
                return encodedData;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private static string DescryptPassword(string password)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode = Convert.FromBase64String(password);
            int charCount = utf8Decode.GetCharCount(todecode, 0, todecode.Length);
            char[] decoded = new char[charCount];
            utf8Decode.GetChars(todecode, 0, todecode.Length, decoded, 0);
            string result = new String(decoded);
            return result;
        }

        public static bool Compare(string password, string dbPassword)
        {
            string decoded = DescryptPassword(dbPassword);
            return password.Equals(decoded);
        }
    }
}