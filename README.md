# Anotações de desenvolvimento

## Projeto

Criando projeto Web API com .NET na versão 6.0

```bash
dotnet new webapi --framework net6.0
```

## Pacotes

Instalando pacotes Microsoft.EntityFrameworkCore.Design e Microsoft.EntityFrameworkCore.SqlServer na versão compatível com a versão do .NET do projeto

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.5

dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.5
```

## Migrations

As migrations servem para realizar um mapeamento que transformará as entidades do projeto em tabelas no banco de dados. 

- Adicionando migration para a criação da tabela Contatos
```bash
dotnet-ef migrations add CreatingContactTable
```
- Aplicando a migration
```bash
dotnet-ef database update
```
