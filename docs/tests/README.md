# Tests

Emplacement: `API_PRODUCT.Tests`

- Contient tests unitaires (vérifier `API_PRODUCT.Tests/TestsUnit`).
- Commande pour lancer les tests:

```powershell
cd API_PRODUCT.Tests
dotnet test
```

Conseils

- Ajouter tests pour `ProductService`, `OrderService` et `AuthService`.
- Utiliser des fakes ou moqueries pour les repositories pour isoler la logique.
