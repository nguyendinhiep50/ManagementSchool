namespace School_version1.Models.DTOs
{
    // làm biếng tách ra :)) nào rảnh FIX
    public class AccountResetPassword
    {
        public string AccountEmail { get; set; }
        public string AccountPassword { get; set; }
        public string AccountPasswordNew { get; set; }
        public string AccountName { get; set; }
    }
}
