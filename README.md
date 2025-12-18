# 🛒 RepositoryStoreApi

![.NET](https://img.shields.io/badge/.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-6DB33F?style=for-the-badge&logo=ef&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)

API REST desenvolvida com **Minimal APIs em .NET 10**, responsável pelo **gerenciamento de produtos**, incluindo criação, consulta, atualização e exclusão (CRUD), utilizando **Entity Framework Core** com **SQL Server** e **Repository Pattern**.

---

## 🚀 Tecnologias Utilizadas

* .NET 10
* C#
* Minimal APIs
* Entity Framework Core
* SQL Server
* OpenAPI
* Scalar
* Docker

---

## 🏗️ Estrutura da Solução

```text
RepositoryStoreApi/
├── Data/
│   └── AppDbContext.cs
├── Models/
│   └── Product.cs
├── Repositories/
│   ├── Abstractions/
│   │   └── IProductRepository.cs
│   └── ProductRepository.cs
├── Program.cs
├── RepositoryStoreApi.csproj
└── Dockerfile
```

---

## 📘 Endpoints da API

### 📄 Listar produtos
**GET** `/v1/products`

### 🔍 Obter produto por ID
**GET** `/v1/products/{id}`

### ➕ Criar produto
**POST** `/v1/products`

```json
{
  "title": "Produto exemplo"
}
```

### ✏️ Atualizar produto
**PUT** `/v1/products/{id}`

### 🗑️ Remover produto
**DELETE** `/v1/products/{id}`

---

## 🗃️ Modelo de Dados

```csharp
public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
```

---

## ▶️ Como Executar o Projeto

### Restaurar dependências
```bash
dotnet restore
```

### Aplicar migrations
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialMigration
dotnet ef database update
```

### Executar a aplicação
```bash
dotnet run
```

A API será iniciada em:

```
http://localhost:8080
https://localhost:8081
```

---

## 🐳 Executando com Docker

```bash
docker build -t repository-store-api .
docker run -p 8080:8080 -p 8081:8081 repository-store-api
```

---

## 🧠 Decisões de Arquitetura

* Minimal APIs para simplicidade e performance
* Repository Pattern para desacoplamento do acesso a dados
* Entity Framework Core como ORM
* Injeção de Dependência nativa do .NET
* Versionamento de rotas (`/v1`)
* Uso de `CancellationToken` em operações assíncronas

---

## 📄 Licença

Este projeto está sob a licença **MIT**.  
Veja o arquivo de licença em:  
https://github.com/danhpaiva/repository-store-minimal-api-net-sqlserver/blob/main/LICENSE

---

## 👨‍💻 Autor

**Daniel Paiva**
Desenvolvedor .NET

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/danhpaiva/)
