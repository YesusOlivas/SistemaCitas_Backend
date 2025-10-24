# 🩺 Sistema de Gestión de Citas Médicas

API desarrollada con **.NET 8.0** para la gestión y programación de citas médicas.  
Permite administrar clientes, médicos y citas de manera estructurada, optimizando el flujo de atención dentro de una clínica o consultorio.

---

## ⚙️ Tecnologías principales

- 🟣 **.NET 8.0**
- 🐬 **MySQL (Aiven Cloud)**
- 📦 **Entity Framework Core**
- 🧩 **Dapper**
- 🔧 **Pomelo.EntityFrameworkCore.MySql**
- 🧰 **EF Core Power Tools**

---

## 🧱 Estructura del Proyecto

La solución está organizada en una arquitectura **por capas**, donde cada proyecto cumple una responsabilidad específica.

```bash
SistemaCitas/
│
├── SistemaCitas.API/                      → Controladores y configuración de la API
│   ├── Controllers/
│   ├── Extensions/
│   ├── Models/
│   ├── appsettings.json
│   └── Program.cs
│
├── SistemaCitas.BusinessLogic/            → Lógica del negocio (servicios, reglas, validaciones)
│   ├── Services/
│   ├── ServiceConfiguration.cs
│   ├── ServiceResult.cs
│   └── ServiceResultType.cs
│
├── SistemaCitas.DataAccess/               → Acceso a datos y repositorios
│   ├── Context/
│   ├── Repositorios/
│   ├── SistemaCitas_Context.cs
│   └── efpt.config.json
│
├── SistemaCitas.Entities/                 → Entidades y modelos del dominio
│   ├── Entities/
│   └── efpt.config.json
│
└── SistemaCitas.sln                       → Archivo de solución principal
```

---

### 🧱 Diagrama de arquitectura
```markdown
┌──────────────────────────┐
│            API           │
│ (Controllers, ViewMode)  │
└─────────────┬────────────┘
              │
              ▼
┌─────────────────────────┐
│     Business Logic      │
│        (Services)       │
└─────────────────────────┘
             │
             ▼
┌────────────────────────┐
│   Data Access Layer    │
│  (Repositories, EF)    │
└────────────────────────┘
             │
             ▼
┌────────────────────────┐
│        Entities        │
│      (Models, EF)      │
└────────────────────────┘
```
---

### ✨ Autor

Desarrollado por **Jesús Antonio Olivas Flores**  
 - *jesusantonioolivasflores31@gmail.com*
 - Proyecto académico y técnico - 2025  

---
