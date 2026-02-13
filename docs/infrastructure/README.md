# Infrastructure

Contient les implémentations concrètes des repositories et la configuration de persistence.

Points importants:

- `DependencyInjection.cs` expose `AddInfrastructure(connectionString)` pour configurer la persistence.
- Implémentations en mémoire disponibles: `InMemoryUserRepository`, `InMemoryOrderRepository`.
- Chaîne de connexion par défaut: `Data Source=products.db` (SQLite file) — configurable via `appsettings.json`.

Conseils

- Remplacer les repositories en mémoire par des implémentations EF Core ou autres selon besoins.
- Externaliser les secrets (JWT key) hors du repository pour la production.
