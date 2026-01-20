# 🚀 C# – Design Pattern


## 🎯 Objetivo

- **C# moderno**
- **SOLID**
- **Clean Architecture**

---

## 🧱 Arquitetura

O projeto segue uma abordagem de **Clean Architecture com DDD light**, organizada em camadas:

```

src
├── Domain          -> regras de negócio
├── Application     -> Casos de uso
├── Infrastructure  -> Base de dados, ficheiros, serviços externos
└── App (Console)   -> Interface com o utilizador

```

### 🔁 Regra de Dependência

> As dependências **sempre apontam para dentro**.

```

App
↓
Application
↓
Domain

```

O **Domain não depende de nada**.

---

## 📦 Camadas

### 🟦 Domain
Contém:
- **Entities** (ex: User, Product)
- **Value Objects** (ex: Email, Price)
- **Regras de negócio**
- **Exceções de domínio**

📌 Decisões importantes do sistema.

---

### 🟨 Application
Contém:
- **Casos de uso**
- **Interfaces (ports)**
- **Orquestração da lógica**
- **DTOs (quando necessário)**

📌 Não contém regras de negócio puras, apenas coordenação.

---

### 🟥 Infrastructure
Contém:
- Implementações de repositórios
- Persistência
- Logs
- Serviços externos

📌 Detalhes técnicos que podem mudar.

---

### 🟩 App (Console)
Contém:
- Entrada da aplicação
- Configuração do `Host`
- Injeção de dependências
- Interação com o utilizador

📌 UI é apenas um cliente da Application.

---

## 🧠 Conceitos Aplicados

- ✅ Dependency Injection (Microsoft.Extensions.Hosting)
- ✅ Interfaces e inversão de dependência
- ✅ Records e imutabilidade
- ✅ Async / Await moderno
- ✅ Logging estruturado
- ✅ SOLID aplicado de forma prática

---

## 📚 Roadmap

### ✔️ Fase 1 – Fundamentos Modernos
- Program.cs
- Host & Services
- Lifetimes
- Interfaces
- Records
- Async / Await
- Logging

### 🔄 Fase 2 – Arquitetura (em progresso)
- Clean Architecture
- DDD light
- Entities & Value Objects
- Repositories (ports)
- DTO vs Entity
- Validação

### 🔜 Fase 3 – UI como Cliente
- Console profissional
- WPF (MVVM moderno)
- MAUI

### 🔜 Fase 4 – Produção
- Configurações
- Environments
- Native AOT
- Performance
- Testes automatizados

---