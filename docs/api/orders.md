# Orders API

Base route: `/api/orders`

Endpoints

- POST `/api/orders`
  - Description: Crée une commande.
  - Auth: requis
  - Body: `CreateOrderRequest`
    - `Lines`: liste de `CreateOrderLineDto`
      - `ProductId` (Guid)
      - `ProductName` (string)
      - `UnitPrice` (decimal)
      - `Quantity` (int)
  - Response: `201 Created` — en-tête `Location` vers `GET /api/orders/{id}`

- GET `/api/orders/{id}`
  - Description: Récupère les détails d'une commande.
  - Auth: requis
  - Response: `200 OK` — objet commande ou `404 NotFound`

Exemple (curl)

```bash
curl -X POST "http://localhost:5000/api/orders" \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer <token>" \
  -d '{"Lines":[{"ProductId":"00000000-0000-0000-0000-000000000000","ProductName":"Chaise","UnitPrice":49.99,"Quantity":2}] }'
```
