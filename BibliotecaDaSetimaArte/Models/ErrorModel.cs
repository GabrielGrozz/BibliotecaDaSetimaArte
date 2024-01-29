using System.Text.Json;

namespace BibliotecaDaSetimaArte.Models
{
    public class ErrorModel
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Trance { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
