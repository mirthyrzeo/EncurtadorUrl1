using Encurtador;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using EncurtadorUrl.Repositories;

[ApiController]
[Route("[controller]")]
public class ShortUrlsController : ControllerBase
{
    private readonly List<ShortUrl> _urls = new List<ShortUrl>();
    private readonly IUrlRepository urlRepository;


    [HttpPost]
    public IActionResult ShortenUrl([FromBody] string fullUrl)
    {
        var shortCode = GenerateShortCode();
        var shortUrl = new ShortUrl { FullUrl = fullUrl, ShortCode = shortCode };
        _urls.Add(shortUrl);
        return Ok(shortUrl);
    }

    [HttpGet("{shortCode}")]
    public IActionResult RedirectShortUrl(string shortCode)
    {
        var url = _urls.FirstOrDefault(u => u.ShortCode == shortCode);
        if (url == null)
        {
            return NotFound();
        }
        return Redirect(url.FullUrl);
    }

    [HttpGet("check/{shortUrl}")]
    public async Task<ActionResult> CheckLink(string shortUrl)
    {
        string longUrl = await urlRepository.GetLongUrlAsync(shortUrl);

        if (string.IsNullOrEmpty(longUrl))
        {
            return BadRequest("URL não encontrada");
        }

        try
        {
            var request = WebRequest.Create(longUrl);
            using var response = await request.GetResponseAsync();
            return Ok("Link está funcionando!");
        }
        catch (WebException ex)
        {
            return BadRequest("Link não está funcionando: " + ex.Message);
        }
    }

    private string GenerateShortCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var shortCode = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        return shortCode;
    }
}
