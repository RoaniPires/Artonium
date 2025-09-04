# ⚔️ Artonium

> **Sistema de gerenciamento de personagens para Tormenta 20**

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![Docker](https://img.shields.io/badge/Docker-Enabled-2496ED?style=flat-square&logo=docker&logoColor=white)](https://www.docker.com/)
[![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)](LICENSE)

## 📖 Sobre o Projeto

Artonium é uma API REST moderna para gerenciar personagens de RPG do sistema **Tormenta 20**. O projeto permite criar, editar e acompanhar personagens com todos os seus atributos, níveis, itens, tibares e muito mais.

Desenvolvido em **.NET 8**.

## ⚡ Quick Start

### Pré-requisitos
- [Docker](https://www.docker.com/get-started) instalado

### Executando o projeto

```bash
# Clone o repositório
git clone https://github.com/RoaniPires/Artonium.git
cd Artonium

# Execute com Docker
docker-compose up --build
```

### Testando a API

Após executar, a API estará disponível em:

- **🌐 API**: http://localhost:5000
- **📚 Documentação**: http://localhost:5000/swagger

#### Endpoint inicial
```bash
GET http://localhost:5000/api/hello
# Resposta: "👋 Olá! Esta é sua primeira API em .NET 8!"
```

## 🚀 Funcionalidades Futuras

- ⚔️ Gerenciamento completo de personagens
- 📊 Sistema de atributos (FOR, DES, CON, INT, SAB, CAR)
- 🎲 Cálculo automático de modificadores
- 💰 Controle de tibares
- 🎒 Inventário de itens e equipamentos
- 📈 Progressão de níveis e pontos de experiência
- 🛡️ Defesas e resistências
- ⚡ Habilidades e talentos

## 🛠️ Tecnologias

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat-square&logo=docker&logoColor=white)](https://www.docker.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-512BD4?style=flat-square&logo=dotnet)](https://docs.microsoft.com/aspnet/core/)
[![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=flat-square&logo=swagger&logoColor=black)](https://swagger.io/)

---

<div align="center">

**⚔️ Feito com 💜 para os aventureiros de Tormenta 20**

*Contribuições são bem-vindas! Abra uma issue ou pull request.*

</div>
