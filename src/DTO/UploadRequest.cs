using System.ComponentModel.DataAnnotations;

namespace json_api_test.DTO
{
    public class UploadRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public byte[] Json { get; set; } = Array.Empty<byte>();

        [Required]
        public byte[] File { get; set; } = Array.Empty<byte>();
    }
}
