# WineHub Reference Implementation – Trin 1

Referenceprojekt til undervisning i C#, ASP.NET Core, arkitektur og GitHub Copilot.

## Trin 1

Vi starter bevidst simpelt:

```text
Vue.js
   |
   | HTTP GET /api/orders
   v
OrdersController
   |
   v
OrderManager
   |
   v
IOrderRepository
   |
   v
InMemoryOrderRepository
   |
   v
List<Order>
```

## Teknologier

- ASP.NET Core Web API / .NET 10
- Controller-based API
- Vue 3 + Vite
- CORS
- Dependency Injection
- Repository Pattern
- In-memory static list

## Kør API'et

Fra `WineHub.Api`:

```bash
dotnet run --launch-profile http
```

API'et kører på:

`http://localhost:5000`

Test endpoint:

`http://localhost:5000/api/orders`

## Kør Vue

Fra `winehub-web`:

```bash
npm install
npm run dev
```

Åbn:

`http://localhost:5173`

## Undervisningspointer

### Controller

Modtager HTTP-request og returnerer HTTP-response. Controlleren indeholder ikke forretningslogik.

### Manager

Koordinerer use casen. I denne første version er koordineringen meget simpel.

### Repository

Skjuler, hvor data kommer fra. Lige nu er data en List<Order>. Senere kan implementationen udskiftes med SQL Server uden at Controlleren behøver ændres.

### Vue

Er en separat frontend. Den kender kun API'ets HTTP-kontrakt og ikke C#-klassernes interne struktur.

## Næste trin

1. POST /api/orders
2. Opret OrderRequest/DTO
3. Flyt forretningslogik ind i Manager
4. Introducer en Service
5. Unit tests med xUnit
6. Opdel i Domain/Application/Infrastructure
7. Vertical Slices
8. JWT/OIDC med Keycloak
9. YARP
10. Docker og senere Kubernetes
