using json_api_test.DTO;
using Microsoft.AspNetCore.Mvc;

namespace json_api_test.Controllers
{
    [ApiController]
    [Route("api/test/[action]")]
    public class TestController : ControllerBase
    {
        private readonly IStorage _storage;

        public TestController(IStorage storage)
        {
            _storage = storage;
        }

        [RequestSizeLimit(1_000_000_000)]
        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] UploadRequest request, CancellationToken ct)
        {
            var name = request.Name;

            var contentTask = _storage.Upload(request.File, name, ct);

            var json = request.Json;

            var dataTask = _storage.Upload(json, ".json", ct);
            
            var r = await Task.WhenAll(contentTask, dataTask);

            return Ok(new
            {
                name,
                data = r[1],
                content = r[0]
            });
        }
    }
}
