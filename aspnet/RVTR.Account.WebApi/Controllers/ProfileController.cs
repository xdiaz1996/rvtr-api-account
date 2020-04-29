using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Account.DataContext.Repositories;
using RVTR.Account.ObjectModel.Models;

namespace RVTR.Account.WebApi.Controllers
{
  [ApiController]
  [EnableCors()]
  [Route("api/[controller]")]
  public class ProfileController : ControllerBase
  {
    private readonly ILogger<ProfileController> _logger;
    private readonly UnitOfWork _unitOfWork;

    public ProfileController(ILogger<ProfileController> logger, UnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        await _unitOfWork.Profile.DeleteAsync(id);
        await _unitOfWork.CommitAsync();

        return Ok();
      }
      catch
      {
        return NotFound(id);
      }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _unitOfWork.Profile.SelectAsync());
    }

    [HttpGet("{id")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        return Ok(await _unitOfWork.Profile.SelectAsync(id));
      }
      catch
      {
        return NotFound(id);
      }
    }

    public async Task<IActionResult> Post(ProfileModel profile)
    {
      if (profile == null)
      {
        return BadRequest(profile);
      }

      await _unitOfWork.Profile.InsertAsync(profile);
      await _unitOfWork.CommitAsync();

      return Accepted(profile);
    }

    [HttpPut]
    public async Task<IActionResult> Put(ProfileModel profile)
    {
      if (profile == null)
      {
        return BadRequest(profile);
      }

      _unitOfWork.Profile.Update(profile);
      await _unitOfWork.CommitAsync();

      return Accepted(profile);
    }
  }
}
