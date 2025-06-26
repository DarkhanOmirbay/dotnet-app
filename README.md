# Asp.Net Core Web

swagger:http://localhost:5000/swagger

dotnet add package Swashbuckle.AspNetCore for install swagger lib

# Run

dotnet build

dotnet run

# Project structure

MyApi/

├── Controllers/           # REST API контроллеры (например, TodoController)

├── Models/                # DTO, Entity, ViewModel классы

├── Services/              # Бизнес-логика (например, TodoService)

├── Interfaces/            # Интерфейсы для DI (например, ITodoService)

├── Repositories/          # Доступ к данным (если используешь паттерн Repository)

├── Middleware/            # Кастомные middleware (например, ErrorHandlingMiddleware)

├── Helpers/               # Утилиты, JWT-генераторы, мапперы и т.д.

│

├── Program.cs             # Точка входа, конфигурация DI и middleware

├── appsettings.json       # Конфигурация по умолчанию

├── appsettings.Development.json  # Конфигурация для dev-окружения

├── MyApi.csproj           # Файл проекта

├── MyApi.sln              # Файл решения (если создавался)

├── MyApi.http             # HTTP-запросы для тестирования (REST Client)

├── Properties/

│   └── launchSettings.json  # Профили запуска

├── bin/                   # Скомпилированные файлы (авто)

├── obj/                   # Временные сборочные файлы (авто)

├── README.md              # Описание проекта (этот файл)

# CRUD

Add todo - post method

Get todo by id - get method

Update fully todo by id - put method

Update todo partially for attr IsCompleted (true/false) - patch method

Delete todo by id - delete method
