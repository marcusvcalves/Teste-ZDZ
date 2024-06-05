
## Inicialização do Backend
1. Abra o terminal na pasta backend/Infrastructure.
2. Execute o comando para aplicar as migrações e atualizar o banco de dados SQLite.
```
dotnet ef database update
```
3. Abra o terminal na pasta backend/ApplicationCore.
4. Execute o comando para iniciar o backend.
```
dotnet run
```
5. O backend estará disponível em http://localhost:8080/swagger/index.html.

## Inicialização do Frontend
1. Faça a instalação das dependências na pasta frontend/src:
```
npm install
```
2. Execute o servidor local:
```
npm run dev
```
3. O frontend está disponível em http://localhost:3000
