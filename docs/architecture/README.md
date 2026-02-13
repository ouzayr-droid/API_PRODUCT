# Architecture — Vue d'ensemble

Résumé

L'application est organisée en plusieurs projets:

- `API_PRODUCT.Api` — Web API (controllers, configuration, Swagger)
- `API_PRODUCT.Application` — services applicatifs, DTOs
- `API_PRODUCT.Domain` — entités et interfaces métier
- `API_PRODUCT.Infrastructure` — implémentation des repositories, DI

Diagramme simplifié (Mermaid)

```mermaid
flowchart LR
  API[API (Controllers)] -->|calls| App[Application Services]
  App -->|uses| Domain[Domain Entities]
  App -->|persists| Infra[Infrastructure / Repositories]
  Infra --> DB[(SQLite / storage)]
```

Points clés

- Authentification via JWT (configurable dans `appsettings.json`).
- Dépendances sont enregistrées dans `Program.cs` via `AddScoped` et `AddInfrastructure`.
- Certaines implémentations (`InMemory*Repository`) servent d'exemple et de démarrage rapide.
