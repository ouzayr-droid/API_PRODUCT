# Getting Started

Pré-requis

- .NET SDK (6+ recommandé)
- (Optionnel) Visual Studio / Rider / VS Code

Démarrage rapide

1. Ouvrir un terminal dans le dossier `API_PRODUCT.Api`.
2. Restaurer et lancer:

```powershell
cd API_PRODUCT.Api
dotnet restore
dotnet run
```

L'API écoute par défaut sur le port configuré (utilisez la sortie `dotnet run`). Swagger est activé en `Development` (URL: `/swagger`).

Configuration importante

- Variables de configuration JWT: `Jwt:Key`, `Jwt:Issuer`, `Jwt:Audience` (voir `appsettings.json` pour un exemple).
- Chaîne de connexion: `ConnectionStrings:DefaultConnection` (par défaut `Data Source=products.db`).

Notes

- Le projet utilise une implémentation en mémoire pour certains repositories (`InMemoryUserRepository`, `InMemoryOrderRepository`) — vérifier `Infrastructure/` pour personnaliser la persistence.
