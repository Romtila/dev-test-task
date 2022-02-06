namespace json_api_test
{
    public interface IStorage
    {
        public Task<string> Upload(byte[] data, string name, CancellationToken ct);
    }

    public class StorageService : IStorage
    {
        public async Task<string> Upload(byte[] data, string name, CancellationToken ct)
        {
            var file = Path.GetTempFileName();
            await File.WriteAllBytesAsync(file, data, ct);

            return file;
        }
    }
}
