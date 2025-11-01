# PulseHub 🧠

**Микросервисный учебный проект на .NET 8**, демонстрирующий промышленную архитектуру и интеграцию нескольких сервисов.

## 🏗️ Архитектура

| Сервис | Назначение |
|---------|-------------|
| `AuthService` | Авторизация (JWT, Refresh Tokens) |
| `CatalogService` | Каталог товаров (Category, Product, Supplier) |
| `OrderService` | Заказы (Order, OrderItem) |
| `Shared` | Общие типы и конфигурации |
| `Tests` | Unit + Integration Tests |

## 🧰 Технологии

- .NET 8, ASP.NET Core
- PostgreSQL + EF Core
- JWT Auth
- Docker + Compose
- Redis, RabbitMQ
- xUnit + FluentAssertions
- Clean Architecture + SOLID

## 🚀 Быстрый старт

```bash
docker compose up -d --build
