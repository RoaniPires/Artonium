# ⚔️ Artonium

> **Sistema de gerenciamento de personagens para Tormenta 20**

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
![MongoDB](https://img.shields.io/badge/MongoDB-7.0-47A248?style=flat-square&logo=mongodb&logoColor=white)
[![Docker](https://img.shields.io/badge/Docker-Enabled-2496ED?style=flat-square&logo=docker&logoColor=white)](https://www.docker.com/)
[![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)](LICENSE)

## 📖 Sobre o Projeto

Artonium é uma **API REST moderna** para gerenciar personagens de RPG do sistema **Tormenta 20**. Permite criar, editar, consultar e excluir personagens com persistência em banco MongoDB.

Desenvolvido em **.NET 8** com **MongoDB.Driver**.

## ⚡ Quick Start

### Pré-requisitos
- [Docker](https://www.docker.com/get-started) instalado

### Executando o projeto

```bash
# Clone o repositório
git clone https://github.com/RoaniPires/Artonium.git
cd Artonium

# Execute com Docker (API + MongoDB)
docker-compose up --build
```

### Acessando a aplicação

Após executar, a aplicação estará disponível em:

- **🌐 API**: http://localhost:5000
- **📚 Documentação Swagger**: http://localhost:5000/swagger
- **🍃 MongoDB**: localhost:27017

## 🚀 Funcionalidades Atuais

### ⚔️ **Gerenciamento de Personagens**
- ✅ **Criar personagens** com nome e data de criação
- ✅ **Listar todos** os personagens
- ✅ **Buscar por ID** específico
- ✅ **Atualizar** informações do personagem
- ✅ **Excluir** personagens

### 🛠️ **Recursos Técnicos**
- ✅ **Hot Reload** - Mudanças aplicadas automaticamente
- ✅ **Persistência** - Dados salvos em MongoDB
- ✅ **Validações** - Nome obrigatório, tamanho máximo
- ✅ **Documentação** - Swagger UI automática
- ✅ **Docker** - Ambiente completo containerizado

## 📋 Endpoints da API

| Método | Endpoint | Descrição | Exemplo |
|--------|----------|-----------|---------|
| `GET` | `/api/personagens` | Lista todos os personagens | `[]` ou `[{...}]` |
| `GET` | `/api/personagens/{id}` | Busca personagem por ID | `{"id":1,"nome":"..."}` |
| `POST` | `/api/personagens` | Cria novo personagem | Body: `{"nome":"Arthag"}` |
| `PUT` | `/api/personagens/{id}` | Atualiza personagem | Body: `{"id":1,"nome":"..."}` |
| `DELETE` | `/api/personagens/{id}` | Remove personagem | Status: `204 No Content` |

## 🛠️ Tecnologias

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![MongoDB](https://img.shields.io/badge/MongoDB-7.0-47A248?style=flat-square&logo=mongodb&logoColor=white)](https://www.mongodb.com/)
[![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat-square&logo=docker&logoColor=white)](https://www.docker.com/)
[![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat-square&logo=swagger&logoColor=black)](https://swagger.io/)

## 🐳 Comandos Docker Úteis

```bash
# Subir aplicação
docker-compose up -d

# Ver logs
docker-compose logs -f artonium-api

# Parar aplicação
docker-compose down

# Reconstruir containers
docker-compose up --build --force-recreate

# Acessar container da API
docker exec -it artonium-api bash

# Acessar banco MongoDB
docker exec -it artonium-mongo mongosh
```

---

<div align="center">

**⚔️ Feito com 💜 para os aventureiros de Arton**

*Sistema em desenvolvimento ativo - contribuições são bem-vindas!*

</div>
