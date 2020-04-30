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
  public class AccountController : ControllerBase
  {
    private readonly ILogger<AccountController> _logger;
    private readonly UnitOfWork _unitOfWork;

    public AccountController(ILogger<AccountController> logger, UnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        await _unitOfWork.Account.DeleteAsync(id);
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
      return Ok(await _unitOfWork.Account.SelectAsync());
    }

    [HttpGet("{id")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        return Ok(await _unitOfWork.Account.SelectAsync(id));
      }
      catch
      {
        return NotFound(id);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(AccountModel account)
    {
      try
      {
        await _unitOfWork.Account.InsertAsync(account);
        await _unitOfWork.CommitAsync();

        return Accepted(account);
      }
      catch
      {
        return BadRequest(account);
      }
    }

    [HttpPut]
    public async Task<IActionResult> Put(AccountModel account)
    {
      try
      {
        _unitOfWork.Account.Update(account);
        await _unitOfWork.CommitAsync();

        return Accepted(account);
      }
      catch
      {
        return BadRequest(account);
      }
    }
  }
}
