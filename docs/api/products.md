# Products API

Base route: `/api/products`

Endpoints

- GET `/api/products`
  - Description: Récupère la liste des produits.
  - Auth: requis (JWT)
  - Response: `200 OK` — `List<ProductDto>`

- GET `/api/products/{id}`
  - Description: Récupère un produit par `id`.
  - Auth: requis
  - Response: `200 OK` — `ProductDto` ou `404 NotFound`

- POST `/api/products`
  - Description: Crée un produit.
  - Auth: requis
  - Body: `CreateProductRequest`
    - `Name` (string)
    - `Price` (decimal)
    - `IsActive` (bool, default true)
  - Response: `200 OK` (implémentation actuelle) — adapter selon besoins

- PUT `/api/products/{id}/price`
  - Description: Change le prix d'un produit.
  - Auth: requis
  - Body: `ChangePriceRequest`
    - `NewPrice` (decimal, >= 0.01)
  - Response: `200 OK`

- DELETE `/api/products/{id}`
  - Description: Supprime un produit.
  - Auth: requis
  - Response: `200 OK`

Schemas (DTOs)

- `ProductDto`
  - `Id` (Guid)
  - `Name` (string)
  - `Price` (decimal)
  - `IsActive` (bool)

- `CreateProductRequest`
  - `Name`, `Price`, `IsActive`

- `ChangePriceRequest`
  - `NewPrice` (decimal)

Exemples (curl)

Créer un produit:

```bash
curl -X POST "http://localhost:5000/api/products" \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer <token>" \
  -d '{"Name":"Chaise","Price":49.99,"IsActive":true}'
```
