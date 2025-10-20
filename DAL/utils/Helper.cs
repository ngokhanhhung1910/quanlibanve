namespace DAL.utils
{
    public static class Helper
    {
        public static string HashPassword(string password)
        {
            // Simple hash for demo, use a secure hash in production
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return System.BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
