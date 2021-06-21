using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KabadaAPI.Controllers
{
  [Authorize]
  [Route("api/files")]
  [ApiController]
  public class UserFileController : KController
  {

    public UserFileController(ILogger<KController> logger, IConfiguration configuration) : base(logger, configuration) {}


    [HttpPost, DisableRequestSizeLimit]
   // [AllowAnonymous]
    public async Task<IActionResult> UploadFile([FromForm]List<IFormFile> files){ return await prun<List<IFormFile>>(_UploadFile, files); }
    private async Task<IActionResult> _UploadFile([FromForm]List<IFormFile> files){
#if XX
      return Ok(new { count = files?.Count, rq = Request.Form.Files?.Count });
#endif
      try
      {
        //var userId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value.ToString()); // TODO
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value.ToString();
        var formCollection = await Request.ReadFormAsync();
        _logger.LogInformation($"-- UploadFile -- Files={formCollection.Files?.Count} -- user={userId}");
        var f = formCollection.Files.First();

        if (f.Length > 0)
        {
          _logger.LogInformation($"-- UploadFile {f.FileName} {f.Length}");
          using (var ms = new System.IO.MemoryStream())
          using (var db = new DAcontext(_config))
          {
            await f.CopyToAsync(ms);
            _logger.LogInformation($"-- {ms.Length}");

            var r = new KabadaAPIdao.UserFile { Name = f.FileName, UserId = null, Content = ms.ToArray() };
            await db.UserFiles.AddAsync(r);
            await db.SaveChangesAsync();

            return Ok(r.Id);
          }
        }
        else
        {
          return BadRequest();
        }
      }
      catch (Exception e)
      {
        return StatusCode(500, $"Internal server error: {e}");
      }
    }

    /// <summary>
    /// Deletes a specific file from DB.
    /// </summary>
    /// <param name="id">guid string</param>
    [HttpDelete("{id}")]
   // [AllowAnonymous]
    public async Task<IActionResult> DeleteFile(string id){ return await prun<string>(_DeleteFile, id); }
    private async Task<IActionResult> _DeleteFile(string id){
      _logger.LogInformation($"-- DeleteFile {id}");
      try
      {
        if (string.IsNullOrEmpty(id))
        {
          return BadRequest();
        }

        var fileId = Guid.Parse(id);
        using (var db = new DAcontext(_config))
        {
          var r = db.UserFiles.FirstOrDefault(r => r.Id == fileId);
          if (r != null)
          {
            db.UserFiles.Remove(r);
            await db.SaveChangesAsync();
          }
          return Ok(r?.Name);
        }
      }
      catch (Exception e)
      {
        return StatusCode(500, $"Internal server error: {e}");
      }
    }


    [HttpGet("{id}")]
    [AllowAnonymous]
    public IActionResult DownloadFile(string id) { return prun<string>(_DownloadFile, id); }
    private IActionResult _DownloadFile(string id) {
      _logger.LogInformation($"-- DownloadFile {id}");
      try
      {
        if (string.IsNullOrEmpty(id))
        {
          return BadRequest();
        }

        //var userId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value.ToString());
        //Guid? userId = null;

        var fileId = Guid.Parse(id);
        using (var db = new DAcontext(_config))
        {
          var r = db.UserFiles.FirstOrDefault(r => r.Id == fileId);
          if (r != null)
          {
            string mimeType = "application/octet-stream"; // TODO
            return File(r.Content, mimeType, r.Name);
          }
          return NotFound();
        }
      }
      catch (Exception e)
      {
        return StatusCode(500, $"Internal server error: {e}");
      }
    }


    [HttpGet("byname/{name}")]
    [AllowAnonymous]
    public IActionResult DownloadFileByName(string name){ return prun<string>(_DownloadFileByName, name); }
    private IActionResult _DownloadFileByName(string name){
      _logger.LogInformation($"-- DownloadFileByName {name}");
      try
      {
        if (string.IsNullOrEmpty(name))
        {
          return BadRequest();
        }

        //var userId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value.ToString());
        //Guid? userId = null;

        using (var db = new DAcontext(_config))
        {
          var r = db.UserFiles.FirstOrDefault(r => r.Name == name);
          if (r != null)
          {
            string mimeType = "application/octet-stream"; // TODO
            return File(r.Content, mimeType, r.Name);
          }
          return NotFound();
        }
      }
      catch (Exception e)
      {
        return StatusCode(500, $"Internal server error: {e}");
      }
    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> test() { return await grun(_test); }
    private async Task<IActionResult> _test() {
      _logger.LogInformation("-- all files");
      using (var db = new DAcontext(_config))
      {
        var r = await db.UserFiles.Select(r => new { r.Id, r.UserId, r.Name, r.Content.Length }).ToListAsync();
        return Ok(r);
      }
    }

  }
}
