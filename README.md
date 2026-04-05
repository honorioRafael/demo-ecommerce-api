# 🛒 Demo ECommerce

Projeto de estudo de uma API REST para um sistema de e-commerce, desenvolvido com foco em boas práticas de arquitetura e organização de código.

## 🏗️ Arquitetura

O projeto segue os princípios da **Clean Architecture**, organizado nas seguintes camadas:

```
ECommerce/
├── src/
│   ├── ECommerce.Domain          # Entidades, interfaces e regras de negócio
│   ├── ECommerce.Application     # Casos de uso e serviços de aplicação
│   ├── ECommerce.Infrastructure  # Repositórios, EF Core, contexto do banco
│   └── ECommerce.Api             # Controllers, middlewares, configuração da API
└── tests/
```

## 🚀 Tecnologias

- [.NET / C#](https://dotnet.microsoft.com/) — plataforma principal da API
- [PostgreSQL](https://www.postgresql.org/) — banco de dados relacional
- [Docker](https://www.docker.com/) — containerização do ambiente

## ⚙️ Como executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado
- [Docker](https://www.docker.com/) instalado

---

### 1. Configurar variáveis de ambiente

Copie o arquivo de exemplo e preencha com seus valores:

```bash
cp .env.example .env
```

Exemplo de `.env`:

```env
ConnectionStrings__DefaultConnection=Host=db;Database=ecommerce_db;Username=postgres;Password=postgres
```

---

### 2. Subir os containers

```bash
docker compose up -d
```

Isso irá inicializar tanto a API quanto o banco de dados PostgreSQL.

---

### 3. Executar as migrations

> **Atenção:** o `dotnet ef` roda fora do Docker e não lê o `.env` diretamente. Por isso, é necessário configurar a connection string no arquivo `src/ECommerce.Api/appsettings.Development.json` antes de rodar as migrations.

Crie ou edite o arquivo `appsettings.Development.json` (já incluso no `.gitignore`):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=ecommerce_db;Username=postgres;Password=postgres"
  }
}
```

Em seguida, execute:

```bash
dotnet ef database update --project src/ECommerce.Infrastructure --startup-project src/ECommerce.Api
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

## 📄 Licença

Este projeto é de uso livre para fins educacionais e de portfólio.
