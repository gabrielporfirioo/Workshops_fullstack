# Sistema de Gestão de Workshops e Colaboradores

Este projeto é um sistema completo para a gestão de workshops e colaboradores. Ele permite:
- **CRUD completo** (criar, ler, atualizar, excluir) de workshops e colaboradores.
- **Associação de colaboradores** a workshops.
- Interface web moderna utilizando Angular.
- Backend robusto e escalável com .NET Core.

## Requisitos do Sistema

Antes de começar, certifique-se de que sua máquina possui:
- [Node.js](https://nodejs.org/) (versão 18 ou superior)
- [Angular CLI](https://angular.io/cli) (versão 15 ou superior)
- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)
- [MySQL Server](https://dev.mysql.com/downloads/)

## Configuração do Projeto

 ### Como Rodar o Projeto
  1. **Clone o repositório**:
      ```bash
      git clone https://github.com/seuusuario/seurepositorio.git
      ```
  2. **Siga as instruções no README.md para configurar o ambiente.**

  3. **Execute o backend e o frontend localmente.**

<br/><br/>

# 1. Configuração do Backend (.NET Core)

1. **Acesse o diretório do backend**:
   ```bash
   cd backend
   cd WebApplication1_api
   ```
2. **Crie o arquivo .env para variáveis sensíveis: Crie um arquivo .env na raiz do diretório backend com o seguinte conteúdo**:
```bash
 DB_CONNECTION_STRING=Server=localhost;Database=nome_do_banco;User=root;Password=senha_do_banco;
```

3. **Restaure as dependências**:
```bash
 dotnet restore
```

4. **Execute as migrações do banco de dados: Certifique-se de que o MySQL está rodando e execute**:
  ```bash
  dotnet ef database update
  ```

5. **Inicie o servidor**:
  ```bash
  dotnet run
  ```
6. **Testando o backend**:

- Acesse o Swagger em:
  [http://localhost:5212/swagger](http://localhost:5212/swagger)

<br/><br/>

# 2. Configuração do Frontend (Angular)

1. **Acesse o diretório do frontend**:
  ```bash
cd frontend
cd workshop
  ```

2. **Instale as dependências**:
```bash
npm install
```

3. **Atualize a URL base da API no arquivo de configuração: Abra src/environments/environment.ts e configure a URL base**:
  ```bash
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5212/api'
};
  ```

4. **Inicie o servidor Angular**:
  ```bash
    ng serve
  ```

5. **Acesse o frontend**:

- O sistema estará disponível em:
  [http://localhost:4200](http://localhost:4200)

<br/><br/>

# 3. Screenshots

1. **Colaboradores**:

   <img src="/Fast_prints/colaboradores.png">
   <img src="/Fast_prints/colaboradores_add.png">

2. **Workshops**:

   <img src="/Fast_prints/workshop_list.png">
   <img src="/Fast_prints/workshop_list2.png">
   <img src="/Fast_prints/worskhop_add.png">

3. **Database**:
   <img src="/Fast_prints/bd.png">


   <br/><br/>

# 4. Dúvidas
- Caso tenha dúvidas, entre em contato pelo e-mail: gabrielporfirio@gmail.com


