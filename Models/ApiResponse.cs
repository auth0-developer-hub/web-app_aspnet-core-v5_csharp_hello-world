namespace App.Models
{
    public class ApiResponse
    {
        public Message message { get; set; }
        public object error { get; set; }

        public bool IsSuccessful()
        {
            return message != null;
        }
    }
}
