## Contexte
CE projet est un projet simple CRUD réalisé avec .NET dans le cadre du cours de développement avancé à 3il-Ingénieurs pour s'exercer sur les bonnes pratiques de développement.

## Documentation — API_PRODUCT

Ce répertoire `docs/` contient la documentation du projet organisée par topics.

Navigation rapide

- Getting started: getting environement et démarrage rapide (`getting-started/README.md`).
- API: routes et schemas (`api/`).
- Architecture: vue d'ensemble et diagrammes (`architecture/`).
- Domain: entités et règles métier (`domain/`).
- Infrastructure: persistence, DI, configuration (`infrastructure/`).
- Tests: guide pour tests unitaires (`tests/`).
- Contribuer: guide contribution et PR (`contributing.md`).
- Changelog: historique des changements (`changelog.md`).

Pour générer ou mettre à jour la doc, éditez les fichiers dans `docs/`.

## Architecture
![image](./archi_api.png) Architecture d'une API interne

## Démarrage rapide
Ce guide explique comment démarrer localement l'API et lancer les tests rapidement.

### Prérequis
- .NET SDK 7.0 ou supérieur (vérifiez la version cible dans API_PRODUCT.Api.csproj).
- (Optionnel) dotnet-ef si vous utilisez les migrations EF Core :
```
dotnet tool install --global dotnet-ef
```
- Un éditeur (Visual Studio, Rider, VS Code) et Git.

Ouvrir le projet

1. Cloner le dépôt et ouvrir la solution :
```
git clone <repo-url>
cd API_PRODUCT
code .   # ou ouvrir la solution dans Rider/Visual Studio
```
2. Restaurer et compiler
```
dotnet restore
dotnet build --configuration Debug
```
3. Configurer l'environnement
- Le projet utilise les fichiers appsettings.json et appsettings.Development.json. Pour lancer en mode développement, définissez :
```
$env:ASPNETCORE_ENVIRONMENT = "Development"
```
(en PowerShell) ou
```
export ASPNETCORE_ENVIRONMENT=Development
```

(sur macOS/Linux).

- Vérifiez launchSettings.json pour connaître les ports et profils de lancement.
Appliquer les migrations (si EF Core)
Si le dossier Migrations/ est présent et que vous utilisez EF Core :
```
# depuis la racine du repo
dotnet ef database update --project API_PRODUCT.Infrastructure --startup-project API_PRODUCT.Api
```
Remplacez les noms de projets si nécessaire.

4. Lancer l'API
Depuis la racine :
```
dotnet run --project API_PRODUCT.Api
```
ou pour forcer l'URL :
```
dotnet run --project API_PRODUCT.Api --urls "http://localhost:5000"
```
L'API répondra à l'URL affichée dans la console (par défaut Kestrel).

5. Tester l'API
- Collection HTTP : le fichier API_PRODUCT.http à la racine contient des requêtes exemple (utilisez l'extension REST Client dans VS Code ou Postman).
- Tests unitaires :
```
dotnet test API_PRODUCT.Tests
```
6. Authentification
- Voir Security et AuthController.cs pour le flux d'authentification (JWT).
- Placez les secrets ou clés nécessaires dans appsettings.Development.json ou gérez-les via variables d'environnement.

7. Débogage
- Ouvrez la solution dans Rider/Visual Studio et lancez le profil API_PRODUCT.Api (launchSettings).
- Ajoutez des points d'arrêt dans Controllers/ ou Services/.

8. Commandes utiles
- Nettoyer et reconstruire :
```
dotnet clean
dotnet build
```
- Lancer un seul test (par nom) :
```
dotnet test API_PRODUCT.Tests --filter "FullyQualifiedName~Namespace.MyTest"
```

9. Problèmes courants
- Erreur "SDK not found" → installez la version requise du .NET SDK.
- Migrations non appliquées → exécutez dotnet ef database update.
- Port occupé → changez l'URL avec --urls ou libérez le port.

10. Liens et docs
- Documentation complète dans docs (API, architecture, domain, infrastructure, tests).
- Voir contributing.md pour les règles de contribution.