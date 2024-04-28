using Api.Domain.Interfaces;
using Api.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;



namespace Api.Controllers;

[ApiController]
[Route("api/")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpGet, Route("users")]
    public async Task<IActionResult> GetAllUser()
    {
        var result = await _userService.GetAllUser();
        return Ok(result);
    }

    [HttpGet, Route("user/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = await _userService.GetUserById(id);
        return Ok(result);
    }

    [HttpGet, Route("user/cpf/{cpf}")]
    public async Task<IActionResult> GetUserByCpf(string cpf)
    {
        var result = await _userService.GetUserByCpf(cpf);
        return Ok(result);
    }

    [HttpGet, Route("user/cnpj/{cnpj}")]
    public async Task<IActionResult> GetUserByCnpj(string cnpj)
    {
        var result = await _userService.GetUserByCnpj(cnpj);
        return Ok(result);
    }

    [HttpPost, Route("user")]
    [SwaggerOperation(Summary = "Adiciona um novo usuário")]
    [SwaggerResponse(StatusCodes.Status200OK, "Retorna o usuário adicionado", typeof(UserModel))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
    public async Task AddUserModel([FromBody] UserModel request)
    {
        var usermodel = new UserModel
        {
            Nome = request.Nome,

            Cpf = request.Cpf,

            Cnpj = request.Cnpj,

            Email = request.Email,

            Telefone = request.Telefone
        };

        await _userService.AddUserModel(usermodel);
    }

    [HttpPut, Route("user/{id}")]
    [SwaggerOperation(Summary = "Atualize um novo usuário")]
    [SwaggerResponse(StatusCodes.Status200OK, "Retorna o usuário adicionado", typeof(UserModel))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
    public async Task UpdateUserModel([FromBody] UserModel request, int id)
    {
        var usermodel = new UserModel
        {
            Nome = request.Nome,

            Cpf = request.Cpf,

            Cnpj = request.Cnpj,

            Email = request.Email,

            Telefone = request.Telefone
        };

        await _userService.UpdateUserModel(usermodel, id);
    }


    [HttpDelete, Route("users/{id}")]
    public async Task DeleteUserModel(int id)
    {
        await _userService.DeleteUserModel(id);
    }

    [HttpDelete, Route("user/{cpf}")]
    public async Task DeleteUserModel(string cpf)
    {
        await _userService.DeleteUserModel(cpf);
    }
}
