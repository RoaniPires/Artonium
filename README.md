# ⚔️ Artonium

> **Sistema de gerenciamento de personagens para Tormenta 20**

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-336791?style=flat-square&logo=postgresql&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat-square&logo=docker&logoColor=white)
[![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat-square&logo=swagger&logoColor=black)](https://swagger.io/)

## 📖 Sobre o Projeto

API REST para gerenciar personagens de RPG do sistema **Tormenta 20**. Desenvolvida em **.NET 8** com **Entity Framework Core** e **PostgreSQL**.

## 🚀 Como Executar

### 1. Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)

### 2. Primeira execução

```powershell
# Clone o repositório
git clone https://github.com/RoaniPires/Artonium.git
cd Artonium

# Inicie o PostgreSQL
docker-compose up -d

# Restaure as dependências
dotnet restore

# Execute a aplicação
dotnet run
```

### 3. Acesse a aplicação
- **API**: http://localhost:5000
- **Swagger**: http://localhost:5000/swagger

## 🛠️ Tecnologias

- **.NET 8** - Framework principal
- **PostgreSQL** - Banco de dados
- **Entity Framework Core** - ORM
- **Docker** - Container para PostgreSQL
- **Swagger** - Documentação da API

## 🐛 Problemas Comuns

### ❌ .NET SDK não encontrado
**Erro**: `'dotnet' is not recognized`
```powershell
# Instale o .NET 8 SDK
# https://dotnet.microsoft.com/download/dotnet/8.0
# Verifique a instalação
dotnet --version
```

### ❌ Docker não encontrado
**Erro**: `'docker' is not recognized`
```powershell
# Instale o Docker Desktop
# https://www.docker.com/get-started
# Verifique se está rodando
docker --version
```

### ❌ PostgreSQL não conecta
**Erro**: `Connection refused` ou `No connection could be made`
```powershell
# Verifique se o PostgreSQL está rodando
docker ps

# Se não estiver, inicie o container
docker-compose up -d

# Aguarde alguns segundos e tente novamente
```

### ❌ Swagger não carrega
**Problema**: Swagger retorna erro 404 ou não carrega
```powershell
# Verifique se está acessando a URL correta
# ✅ Correto: http://localhost:5000/swagger
# ❌ Errado: http://localhost:5000/swagger/index.html

# O Swagger agora funciona em todos os ambientes (Development/Production)
```

### ❌ Porta 5000 já está em uso
**Erro**: `Address already in use`
```powershell
# Execute em outra porta
dotnet run --urls "http://localhost:5001"

# Ou pare outros processos dotnet
taskkill /f /im dotnet.exe
```

### ❌ Dependências não restauradas
**Erro**: Erros de compilação sobre pacotes não encontrados
```powershell
# Limpe e restaure as dependências
dotnet clean
dotnet restore
dotnet build
```

## ✅ Teste Rápido

Após executar `dotnet run`, teste se tudo está funcionando:

```powershell
# 1. Teste o health check
curl http://localhost:5000/

# 2. Teste a API (deve retornar [])
curl http://localhost:5000/api/personagens

# 3. Crie um personagem
curl -X POST http://localhost:5000/api/personagens -H "Content-Type: application/json" -d '{"nome":"Teste"}'

# 4. Abra o Swagger no navegador
start http://localhost:5000/swagger
```

---

<div align="center">

**⚔️ Feito com 💜 para os aventureiros de Arton**

*Sistema em desenvolvimento ativo - contribuições são bem-vindas!*

</div>
