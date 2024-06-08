
## Inicialização do Backend
1. Restaure as dependências do backend em ApplicationCore:
```
dotnet restore
```
2. Execute o comando para aplicar as migrações e atualizar o banco de dados SQLite no terminal da pasta Infrastructure:
```
dotnet ef database update
```
3. Inicie o servidor de desenvolvimento em ApplicationCore:
```
dotnet run
```
4. O backend estará disponível em http://localhost:8080/swagger/index.html.

## Inicialização do Frontend
1. Faça a instalação das dependências na pasta frontend/src:
```
npm install
```
2. Execute o servidor local de desenvolvimento:
```
npm run dev
```
3. O frontend está disponível em http://localhost:3000
