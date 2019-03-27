# SampleHttpClientAccessTokenApi
Web API with ASP.NET Core MVC - Exemplo de backend para obter token de acesso


Neste tutorial, foi adicionado e alterado os seguintes itens:

+ Chaves de acesso no arquivo de configurações: appsettings.json

"EndpointSettings": {
    "UrlCredentials": "",
    "ClientId": "",
    "ClientSecret": ""
  }

+ Modelo de classe:
AccesModel.cs

+ Interface: ITokenClient.cs 
com o método:
Task<AccessToken> GetToken();

+ Client: TokenClient.cs

+ No arquivo Startup.cs - adiconar as injeções de dependência.

no método abaixo:
public void ConfigureServices(IServiceCollection services)
{
  ...

Exemplo de injeção de dependência do client:
services.AddHttpClient<ITokenClient, TokenClient>();


+ Controller: TokenController.cs
Configurar roteamento e caminhos de URL:
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
  ...
  
Método de retorno:

[HttpPost]
public async Task<IActionResult> Post()
{
    var resultToken = await _token.GetToken();

    return Ok(resultToken);
}


+ Rodando o Serviço:


+ Chamada da web API com Postman.





