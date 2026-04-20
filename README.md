# ECommerce

API REST para um sistema de e-commerce com suporte a cadastro de usuários, vendedores, produtos, carrinho, pedidos e pagamentos, com autenticação via JWT.
Desenvolvido como projeto de estudo com foco em Clean Architecture, Domain Driven Design (DDD), CQRS e boas práticas do ecossistema .NET.

## Arquitetura

O projeto segue os princípios da **Clean Architecture** e **DDD**, organizado nas seguintes camadas:

```
ECommerce/
├── src/
│   ├── ECommerce.Domain          # Entidades, interfaces e regras de negócio
│   ├── ECommerce.Application     # Casos de uso e serviços de aplicação
│   ├── ECommerce.Infrastructure  # Repositórios, EF Core, contexto do banco
│   └── ECommerce.Api             # Controllers, middlewares, configuração da API
└── tests/
    └── TBD 🤞
```

## Tecnologias Utilizadas

- [.NET / C#](https://dotnet.microsoft.com/) — plataforma principal da API
- [Entity Framework Core](https://learn.microsoft.com/ef/core/) — ORM para acesso ao banco de dados
- [MediatR](https://github.com/jbogard/MediatR) — implementação do padrão CQRS
- [FluentValidation](https://docs.fluentvalidation.net/) — validação de comandos e requisições
- [ErrorOr](https://github.com/amantinband/error-or) — tratamento de erros sem exceções via padrão Result
- [JWT Bearer](https://learn.microsoft.com/aspnet/core/security/authentication/) — autenticação e autorização via tokens JWT
- [PostgreSQL](https://www.postgresql.org/) — banco de dados relacional
- [Docker](https://www.docker.com/) — containerização do ambiente

## Como Executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado
- [Docker](https://www.docker.com/) instalado

---

### 1. Configurar variáveis de ambiente

Copie o arquivo de exemplo e preencha com seus valores:

```bash
cp .env.example .env
```

---

### 2. Subir os containers

```bash
docker compose up -d
```

Isso irá inicializar tanto a API quanto o banco de dados PostgreSQL.

---

### 3. Executar as migrations

Com o banco de dados acessível, aplique as migrations para criar o schema:

```bash
dotnet ef database update --project src/ECommerce.Infrastructure --startup-project src/ECommerce.Api --connection "<sua connection string>"
```

> **Nota**: A `connection string` é a mesma definida no arquivo `.env`.

Para criar uma nova migration:

```bash
dotnet ef migrations add NomeDaMigration --project src/ECommerce.Infrastructure --startup-project src/ECommerce.Api
```

Para reverter para uma migration anterior:

```bash
dotnet ef database update NomeDaMigrationAnterior --project src/ECommerce.Infrastructure --startup-project src/ECommerce.Api --connection "<sua connection string>"
```

---

### 4. Acessar a API

Com os containers no ar e as migrations aplicadas, a documentação Swagger estará disponível em:

```
http://localhost:8080/swagger
```

ou

```
https://localhost:8081/swagger
```

---

## Licença

Este projeto está licenciado sob a MIT License. Consulte o arquivo [LICENSE](./LICENSE) para mais detalhes.