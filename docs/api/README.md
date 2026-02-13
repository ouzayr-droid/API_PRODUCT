# API — vue d'ensemble

Base path: `/api`

Controllers documentés:

- `ProductsController` -> `api/products` (CRUD produits + changement de prix)
- `AuthController` -> `api/auth` (inscription / authentification JWT)
- `OrderController` -> `api/orders` (création et lecture de commande)

Voir les fichiers détaillés:

- `api/products.md`
- `api/auth.md`
- `api/orders.md`

Authentification

La plupart des routes sont protégées par JWT (`[Authorize]`). Obtenir un token via `POST /api/auth/login` puis ajouter l'en-tête:

```
Authorization: Bearer <token>
```
