# Auth API

Base route: `/api/auth`

Endpoints

- POST `/api/auth/register`
  - Description: Crée un nouvel utilisateur.
  - Body: `RegisterRequest`
    - `Email` (string)
    - `Nom` (string)
    - `Prenom` (string)
    - `Password` (string)
  - Response: `200 OK` — message de confirmation

- POST `/api/auth/login`
  - Description: Authentifie un utilisateur et retourne un token JWT.
  - Body: `LoginRequest`
    - `Email` (string)
    - `Password` (string)
  - Response: `200 OK` — `{ "Token": "<jwt>" }`

Notes de sécurité

- La clé JWT actuelle est lue depuis configuration (`Jwt:Key`). En production, utilisez un secret sécurisé (KeyVault, variables d'environnement) et ne commitez pas de clés en clair.
- Le controller `AuthController` contient une clé hardcodée (`THIS_IS_A_SUPER_SECRET_KEY_12345`) — préférer la configuration centrale (`appsettings.json` / secrets).
