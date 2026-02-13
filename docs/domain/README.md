# Domain — Entités et règles métier

Principales entités (dans `API_PRODUCT.Domain/Entities`):

- `Product` — représente un produit: Id, Name, Price, IsActive
- `Order` — commande composée de `OrderLine`
- `OrderLine` — ligne de commande (product ref, quantity, price)
- `User` — utilisateur du système

Règles métier observées

- `ChangePriceRequest` valide que le prix est >= 0.01.
- Les services applicatifs (ex: `ProductService`, `OrderService`) encapsulent la logique d'utilisation des repositories.

Pour étendre le domaine

- Ajouter des Value Objects pour des concepts comme Money.
- Ajouter des invariants et exceptions métier dans `Domain/Exceptions`.
