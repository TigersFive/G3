namespace CarInsuranceManage.Models
{
    public class PaymentResponseModel
    {
        public int Id { get; set; } // Định nghĩa khóa chính
        public string TransactionId { get; set; }
        public string PaymentMethod { get; set; }
        public bool Success { get; set; }
        public string PaymentId { get; set; } = Guid.NewGuid().ToString(); // Đảm bảo PaymentId không null
        public string PayerId { get; set; }
    }
}