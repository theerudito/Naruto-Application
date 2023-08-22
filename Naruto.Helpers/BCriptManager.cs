namespace Naruto.Helpers
{
    public static class BCriptManager
    {
        public static string _Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static bool _Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
