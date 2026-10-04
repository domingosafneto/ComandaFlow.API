# ComandaFlow.API

API para consulta de comandas, desenvolvida em ASP.NET Core com .NET 10 e organizada em camadas de API, aplicação, domínio e infraestrutura.

## Funcionalidade disponível

- Listagem de comandas por meio de `GET /api/Comandas`.
- Parâmetro opcional `filtro`, do tipo caractere, com valor padrão `T`.
- Consulta ao SQL Server com Dapper e Microsoft.Data.SqlClient, executando a stored procedure `dbo.pr_ListarComandas`.
- Registro do caso de uso e do repositório com tempo de vida scoped por meio de `AddApplication()` e `AddInfrastructure()`.
- Documento OpenAPI disponível no ambiente `Development`.

## Estrutura

| Projeto | Responsabilidade |
| --- | --- |
| `ComandaFlow.API` | Controllers, configuração e inicialização da API. |
| `ComandaFlow.Application` | Caso de uso `ListarComandasUseCase` e registro dos serviços de aplicação. |
| `ComandaFlow.Domain` | Entidade `Comanda` e contrato `IComandaRepository`. |
| `ComandaFlow.Infrastructure` | Repositório SQL Server, acesso com Dapper e registro dos serviços de infraestrutura. |

## Pré-requisitos

- SDK do .NET 10.
- SQL Server acessível pela aplicação.
- Stored procedure `dbo.pr_ListarComandas` existente no banco configurado, aceitando o parâmetro `@Filtro` e retornando colunas compatíveis com `IdComanda`, `Numero` e `Disponivel`.

O banco de dados utilizado pela API é o do projeto [ComandaFlow.Legacy](https://github.com/domingosafneto/ComandaFlow.Legacy). Consulte esse repositório para os scripts e as orientações de configuração do banco.

Este repositório não inclui scripts para criação do banco ou da procedure. Os valores de filtro aceitos e suas regras são definidos pela procedure.

## Configuração do banco

A aplicação utiliza a chave `ConnectionStrings:DefaultConnection`. O arquivo `ComandaFlow.API/appsettings.Example.json` apresenta um modelo de conexão com valores de exemplo; ele não é carregado automaticamente.

Para desenvolvimento, configure a conexão com User Secrets, executando na raiz do repositório:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=SEU_SERVIDOR\SUA_INSTANCIA;Database=SEU_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True;" --project ComandaFlow.API
```

Também é possível fornecer a conexão por variável de ambiente:

```powershell
$env:ConnectionStrings__DefaultConnection = "Server=SEU_SERVIDOR\SUA_INSTANCIA;Database=SEU_BANCO;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True;"
```

Substitua os valores de exemplo pelos dados do seu ambiente. Mantenha credenciais fora dos arquivos versionados. O `.gitignore` ignora `.env` e `.env.*`, mas a aplicação não possui carregamento automático desses arquivos.

Se a chave de conexão não estiver configurada, a inicialização lança a mensagem `Connection string não configurada.`.

## Executar localmente

Na raiz do repositório:

```powershell
dotnet restore ComandaFlow.slnx
dotnet build ComandaFlow.slnx
dotnet run --project ComandaFlow.API --launch-profile https
```

O perfil `https` executa em `Development`, com HTTPS em `https://localhost:7287` e HTTP em `http://localhost:5082`. A aplicação utiliza redirecionamento para HTTPS.

O documento OpenAPI pode ser consultado em `https://localhost:7287/openapi/v1.json` durante o desenvolvimento.

## Listar comandas

```http
GET https://localhost:7287/api/Comandas?filtro=T
```

Quando `filtro` é omitido, a API utiliza `T`. O valor recebido é encaminhado ao parâmetro `@Filtro` da procedure.

Exemplo ilustrativo de resposta `200 OK`:

```json
[
    {
        "idComanda": 1,
        "numero": 101,
        "disponivel": true
    }
]
```

Os registros retornados dependem dos dados e das regras da procedure no banco configurado.
