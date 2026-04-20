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

Para criar uma nova migration:
```bash
dotnet ef migrations add NomeDaMigration --project src/ECommerce.Infrastructure --startup-project src/ECommerce.Api
```

Para reverter a última migration aplicada:
```bash
dotnet ef database update NomeDaMigrationAnterior --project src/ECommerce.Infrastructure --startup-project src/ECommerce.Api --connection "<sua connection string>"
```

Com o banco de dados configurado e acessível, aplique as migrations para criar o schema, informando a connection string:
```bash
dotnet ef database update --project src/ECommerce.Infrastructure --startup-project src/ECommerce.Api --connection "<sua connection string>"
```

> **Nota**: A ``connection string`` é a mesma que está no arquivo ``.env``

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
