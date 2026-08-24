# 💰 CashFlow API

API REST desenvolvida em **.NET 8** para gerenciamento de despesas pessoais, utilizando princípios de **Domain-Driven Design (DDD)** e uma arquitetura organizada em camadas, com foco em manutenibilidade, testes e boas práticas de desenvolvimento.

O projeto permite cadastrar, consultar, atualizar e remover despesas, além de gerar **relatórios em PDF e Excel**, proporcionando uma visão mais completa dos dados financeiros.

---

## 📌 Sobre o projeto

O **CashFlow** foi desenvolvido com o objetivo de criar uma API para controle de despesas pessoais, permitindo registrar informações como:

* Título da despesa
* Descrição
* Data e hora
* Valor
* Tipo de pagamento

Os dados são persistidos em um banco de dados **MySQL** e disponibilizados através de uma API REST.

A aplicação utiliza uma arquitetura baseada em **Domain-Driven Design (DDD)**, buscando separar responsabilidades e manter o domínio da aplicação independente de detalhes de infraestrutura.

A API também possui integração com **Swagger**, permitindo visualizar, documentar e testar os endpoints diretamente pelo navegador.

---

## 🚀 Funcionalidades

* ✅ Cadastro de despesas
* ✅ Consulta de despesas
* ✅ Consulta de despesa por ID
* ✅ Atualização de despesas
* ✅ Exclusão de despesas
* ✅ Validação de dados
* ✅ Persistência com Entity Framework Core
* ✅ Geração de relatórios em **PDF**
* ✅ Geração de relatórios em **Excel**
* ✅ Documentação interativa com Swagger
* ✅ Testes automatizados
* ✅ Arquitetura baseada em DDD
* ✅ Separação entre domínio, aplicação e infraestrutura

---

## 🏗️ Arquitetura

O projeto utiliza conceitos de **Domain-Driven Design (DDD)** para organizar as responsabilidades da aplicação.

A estrutura foi pensada para manter as regras de negócio desacopladas dos detalhes de infraestrutura:

```text
CashFlow
│
├── CashFlow.Api
│   ├── Controllers
│   ├── Filters
│   └── Extensions
│
├── CashFlow.Application
│   ├── UseCases
│   ├── Services
│   ├── Validators
│   └── AutoMapper
│
├── CashFlow.Communication
│   ├── Requests
│   └── Responses
│
├── CashFlow.Domain
│   ├── Entities
│   ├── Repositories
│   └── Enums
│
├── CashFlow.Infrastructure
│   ├── DataAccess
│   ├── Repositories
│   ├── Reports
│   └── Extensions
│
└── CashFlow.Tests
    └── UnitTests
```

Essa separação facilita a evolução do sistema e permite que cada camada tenha uma responsabilidade bem definida.

---

## 🛠️ Tecnologias utilizadas

### Backend

* **C#**
* **.NET 8**
* **ASP.NET Core**
* **Entity Framework Core**
* **MySQL**
* **REST API**
* **Swagger / OpenAPI**

### Bibliotecas

* **AutoMapper** — Mapeamento entre entidades, requests e responses.
* **FluentValidation** — Validação das regras de entrada da aplicação.
* **FluentAssertions** — Asserções mais legíveis nos testes automatizados.
* **Entity Framework Core** — ORM utilizado para comunicação com o banco de dados.
* **MigraDoc / PDFsharp** — Geração dos relatórios em PDF.
* **ClosedXML** — Geração dos relatórios em Excel.

---

## 📊 Relatórios

Uma das funcionalidades do projeto é a geração de relatórios das despesas cadastradas.

Os relatórios podem ser exportados em:

* 📄 **PDF**
* 📊 **Excel**

Isso permite utilizar os dados da aplicação tanto para visualização quanto para análises financeiras externas.

---

## 🧪 Testes

O projeto possui testes automatizados para validar as principais regras e comportamentos da aplicação.

Para tornar os testes mais legíveis, é utilizado o **FluentAssertions**, permitindo escrever as verificações de forma mais próxima de uma linguagem natural.

Exemplo:

```csharp
result.Should().NotBeNull();
result.Id.Should().Be(1);
```

---

## 📖 Documentação da API

A API utiliza **Swagger / OpenAPI** para disponibilizar uma documentação interativa dos endpoints.

Após executar a aplicação, acesse:

```text
https://localhost:<porta>/swagger
```

Através do Swagger é possível visualizar os endpoints, seus parâmetros, respostas e também realizar requisições diretamente pela interface.

---

## ⚙️ Pré-requisitos

Antes de executar o projeto, certifique-se de possuir instalado:

* **.NET 8 SDK**
* **MySQL Server**
* **Visual Studio 2022+** ou **Visual Studio Code**
* **Git**

O projeto pode ser executado em:

* Windows
* Linux
* macOS

---

## 📥 Instalação

### 1. Clone o repositório

```bash
git clone https://github.com/JuanFila/CashFlow.git
```

### 2. Acesse o diretório

```bash
cd CashFlow
```

### 3. Configure o banco de dados

Configure as informações de conexão com o MySQL no arquivo:

```text
appsettings.Development.json
```

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CashFlow;Uid=root;Pwd=sua_senha;"
  }
}
```

> Ajuste os valores de acordo com a configuração do seu ambiente.

### 4. Execute as migrations

Caso o projeto utilize migrations:

```bash
dotnet ef database update
```

### 5. Execute a aplicação

```bash
dotnet run
```

Após iniciar a aplicação, utilize o Swagger para explorar e testar os endpoints.

---

## 📁 Principais endpoints

| Método   | Endpoint            | Descrição                   |
| -------- | ------------------- | --------------------------- |
| `POST`   | `/expenses`         | Cadastrar uma despesa       |
| `GET`    | `/expenses`         | Listar despesas             |
| `GET`    | `/expenses/{id}`    | Buscar despesa por ID       |
| `PUT`    | `/expenses/{id}`    | Atualizar uma despesa       |
| `DELETE` | `/expenses/{id}`    | Excluir uma despesa         |
| `GET`    | `/reports/expenses` | Gerar relatório de despesas |

> Os endpoints podem variar de acordo com a versão atual da aplicação. Consulte o Swagger para a documentação completa.

---

## 🎯 Objetivos do projeto

Além de implementar um sistema funcional de controle financeiro, o projeto foi desenvolvido para aplicar conceitos importantes do desenvolvimento backend, como:

* Arquitetura em camadas
* Domain-Driven Design
* Princípios SOLID
* Injeção de Dependência
* Repository Pattern
* Unit of Work
* DTOs
* Validação de dados
* Entity Framework Core
* Testes automatizados
* Geração de arquivos
* APIs RESTful
* Documentação com Swagger

---

## 👨‍💻 Autor

**Juan Fila**

Desenvolvedor Full Stack com foco em **C# / .NET, APIs REST, SQL e React**.

[GitHub](https://github.com/JuanFila)

---

## 📄 Licença

Este projeto foi desenvolvido para fins de estudo, prática e portfólio.
