AuthCookieApi

Este é um projeto de exemplo de uma API .NET com autenticação por cookies e integração com MySQL. Ele demonstra como configurar autenticação por cookies em uma aplicação .NET e como proteger endpoints com autenticação.

Pré-requisitos
.NET SDK 8.0

MySQL (ou outro SGBD compatível com o Pomelo.EntityFrameworkCore.MySql)

Git (opcional, para clonar o repositório)

Instalação
Clone o repositório (ou baixe o código fonte):

bash
Copy
git clone https://github.com/seu-usuario/AuthCookieApi.git
cd AuthCookieApi
Instale os pacotes necessários:

O projeto usa os seguintes pacotes NuGet:

Pomelo.EntityFrameworkCore.MySql para MySQL.

Microsoft.AspNetCore.Authentication.Cookies para autenticação por cookies.

Swashbuckle.AspNetCore para documentação da API.

Para instalar os pacotes, execute:

bash
Copy
dotnet restore
Configure o banco de dados:

Atualize a string de conexão no arquivo AppDbContext.cs com as credenciais do seu banco de dados:

csharp
Copy
optionsBuilder.UseMySql("server=localhost;database=AuthCookieDb;user=root;password=sua_senha",
    ServerVersion.AutoDetect("server=localhost;database=AuthCookieDb;user=root;password=sua_senha"));
Execute a aplicação:

No terminal, execute:

bash
Copy
dotnet run
A aplicação estará disponível em http://localhost:5017.

Testando a API
Você pode testar a API usando o Swagger UI.

Swagger UI
Acesse http://localhost:5017/swagger no navegador.

Teste os endpoints:

Login: POST /api/auth/login

Body:

json
Copy
{
  "username": "user",
  "password": "password"
}
Dados Protegidos: GET /api/data (se retornar 200 é porque deu certo)

Logout: POST /api/auth/logout 
