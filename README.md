# 🎬 TMD_API - Gerenciador de Filmes com API TMDB

**Uma aplicação web Full-Stack completa desenvolvida com ASP.NET Core e React. O sistema consome a API do TMDB (The Movie Database) para permitir a busca de títulos, exibição de detalhes e gerenciamento avançado de uma lista de filmes favoritos com persistência de dados.**

---

## 🛠️ Tecnologias Utilizadas

* **Back-End:** .NET Core / C# (Web API com documentação Swagger)
* **Front-End:** React.js, JavaScript, HTML5, CSS3
* **Estilização & Requisições:** Bootstrap & Axios
* **Banco de Dados:** SQL Server (Modelagem relacional para listas e usuários)
* **IDE/Ferramentas:** Visual Studio 2022 & Node.js (NPM)

---

## 📌 Funcionalidades Principais

### 🚀 Back-End (API REST)
* **Busca Global:** Endpoints para pesquisar filmes por nome ou ID diretamente na base do TMDB.
* **Persistência de Favoritos:** Endpoints para adicionar, listar por usuário (ID) e remover títulos da lista de desejos.
* **Compartilhamento:** Geração de links exclusivos para compartilhamento de listas de favoritos de usuários específicos.

### 💻 Front-End (Interface React)
* **Busca e Detalhes:** Barra de pesquisa para encontrar títulos com retorno em tabela detalhada e notas destacadas.
* **Gerenciamento de Lista:** Sistema inteligente que impede a duplicação de filmes nos favoritos e emite alertas dinâmicos de sucesso/erro.
* **Compartilhamento Dinâmico:** Botão dedicado que gera o link direto da lista ou alerta o usuário caso ela esteja vazia.

---

## ⚙️ Configuração do Banco de Dados

Siga os passos abaixo no Visual Studio 2022 para preparar seu banco de dados local:

1. Acesse a pasta `ConfigBanco`, abra o arquivo `bancoconfig.sql` e copie todo o seu conteúdo.
2. Abra o **SQL Server Management Studio (SSMS)** e conecte-se ao seu servidor local.
3. Crie um novo banco de dados chamado **BDR** e execute o script SQL copiado nele.
4. Volte ao Visual Studio, abra o arquivo `appsettings.json` (e também o `appsettings.Development.json`) e insira sua string de conexão:
   ```json
   "ConnectionStrings": { 
     "DefaultConnection": "Data Source=SEU_SERVIDOR;Initial Catalog=BDR;Integrated Security=True;Trust Server Certificate=True" 
   }
   ```
5. Clique com o botão direito em **Connected Services** > **Add** > **SQL Server Database**.
6. Selecione a opção *On-premise*, configure o nome da Connection String como `ConnectionStrings:DefaultConnection`.
7. Conecte ao seu servidor usando *Windows Authentication*, marque *Trust Server Certificate*, aponte para o banco **BDR** e clique em OK.

---

## 🔑 Como obter seu UserID e a Chave API do TMDB

Esta aplicação necessita de credenciais ativas da plataforma TMDB para realizar as consultas:
1. Crie uma conta gratuita no portal oficial do [The Movie Database Developer](https://themoviedb.org).
2. Solicite uma **API Key** preenchendo as informações do seu ambiente de desenvolvimento.

---

## 🏃‍♂️ Como Executar e Testar o Projeto

### 🔌 Inicializando o Back-End (API)
1. Compile e execute o projeto principal no Visual Studio 2022.
2. A página do **Swagger** será aberta automaticamente. Use a opção **Try it out** nos endpoints para habilitar os campos e realizar testes manuais via JSON.

### 🎨 Inicializando o Front-End (React)
Com o Back-end já rodando, configure a interface web seguindo os comandos abaixo:

```bash
# 1. Acesse o diretório do front-end via terminal do VS Code ou PowerShell
cd ratingfrontend

# 2. Instale os pacotes e dependências do React
npm install

# 3. Inicialize o servidor de desenvolvimento local
npm start
```
*Caso o terminal solicite permissão extra para rodar em uma porta alternativa, digite `y` para aceitar.*

---

## 👤 Desenvolvedor

* **Nome:** Alan Santos
* **LinkedIn:** [://linkedin.com](https://www.linkedin.com/in/alan-s-5866a619a/)
