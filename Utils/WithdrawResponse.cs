using Bank.Model;

namespace Bank.Utils
{
    public class WithdrawResponse
    {
        public Status status { get; set; }
        public string? message { get; set; } = null;
        public Account? account { get; set; } = null;
    }
}