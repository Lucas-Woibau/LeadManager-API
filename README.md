# Rodando a API .NET localmente (Kestrel) com Swagger
## 1. Abrir a solução

Abra o Visual Studio 2022.

Vá em File > Open > Project/Solution.

Abra a solução que contém o projeto LeadManager.API.

## 2. Definir o projeto inicial

No Solution Explorer, clique com o botão direito no projeto LeadManager.API.

Selecione Set as Startup Project.

Certifique-se de que o perfil selecionado é LeadManager (não IIS Express).

## 3. Configurar a string de conexão

Abra o arquivo appsettings.json.

Configure a string de conexão para o SQL Server:

{
  "ConnectionStrings": {
    "Default": "Server=localhost\\SQLEXPRESS; Database=LeadManagerDb; Integrated Security=True; TrustServerCertificate=true"
  }
}


O Entity Framework criará automaticamente o banco LeadManagerDb na primeira execução caso ele não exista.

## 4. Rodar a API

Clique em Play (F5) ou Ctrl + F5 no Visual Studio.

A API será executada localmente pelo Kestrel, sem IIS Express.

URLs onde a API ficará acessível:

HTTPS: https://localhost:7229
HTTP : http://localhost:5275


O navegador abrirá automaticamente no Swagger (/swagger) para você testar todos os endpoints de forma visual.

## 5. Testar a API via Swagger

Na página do Swagger (https://localhost:7229/swagger) você verá todos os endpoints disponíveis:

GET /api/leads – listar leads.

GET /api/leads/{id} – buscar lead por ID.

POST /api/leads – criar lead.

PUT /api/leads – atualizar lead.

PUT /api/leads/{id}/accept – aceitar lead.

PUT /api/leads/{id}/decline – recusar lead.

DELETE /api/leads/{id} – excluir lead.

Você pode executar os endpoints direto do Swagger sem precisar de Postman ou outro cliente HTTP
