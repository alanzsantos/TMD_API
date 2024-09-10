				# Projeto de Lista de Filmes - API TMdb

# Pré-requisitos 

Node.js
NPM
Visual Studio 2022
API .NET Core
GIT

# Para executar o projeto:
- Clique com o botão direito na pasta FrontEnd;
- Clique em Open in terminal;
- Digite npm install (para instalar os componentes do React)
- Depois digite npm start (para executar o projeto)

# Configuração do banco de dados
- Abra o Visual Studio 2022;
- Vá na pasta ConfigBanco;
- Abra o arquivo bancoconfig.sql e copie tudo;
- Abra o SQL Server Management Studio;
- Conecte-se no seu servidor;
- Clique com o botão direito na pasta Banco de Dados e adicione um novo banco de dados;
- Nomeie como BDR e clique em Ok;
- Faça uma nova consulta e cole o arquivo que você copiou de bancoconfig.sql;
- Clique em executar;
- Volte ao Visual Studio 2022;
- Abra o appsettings.json e substitua o Data Source, pelo servidor de seu banco SQL Server e salve o arquivo;
- Exemplo:
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=seu\\servidor01;Initial Catalog=Nome_do_banco;Integrated Security=True;Trust Server Certificate=True"
  }
- Abra appsettingss.jsonDevelopment e faça a mesma coisa;
- Clique com o botão direito em Connected Services;
- Vá em add e depois em SQL Server Database;
- Escolha a terceira opção "SQL Server Database" On-premise;
- Clique em Next;
- Em Connection string name, informe: ConnectionStrings:"DefaultConnection"
- Em Connection string value, clique no botão com ...
- Escolha Microsoft SQL Server (Microsoft SqlClient) em data source;
- Em Server name: informe seu\servidor01;
- Em authentication, escolha Windows Authentication;
- Marque a opção Trust Server Certificate;
- Escolha " BDR " em Select or enter a database name;
- E clique em OK;
Assim o banco estará configurado.

# Como obter meu UserID e a chave API?
- Você precisará criar uma conta em https://developer.themoviedb.org/reference/search-movie
- Você precisará solicitar uma API Key no site, preenchendo alguns dados;

# Funcionalidades do Back-end
- Desenvolvido com Swagger, a API conta com endpoint's para pesquisar filmes, pesquisar filmes por id, adicionar filmes,
adicionar filmes numa lista de favoritos, consultar favoritos do usuário via ID, compartilhar favoritos do usuário via link e excluir filmes;
- O botão clear serve para limpar a resposta;
- O botão cancel serve para cancelar a consulta;
- O botão Try it serve para desbloquear o campo, para inserir informações;

# Endpoints
- GET /api/Filme/{id}
Clique em Try it out para acessar o campo ID;
Informe um ID e clique em execute a resposta retornará em Response body;
Se deixar em branco e clicar em execute: Please correct the following validation errors and try again. For 'id': Required field is not provided.

- GET /api/Filme/pesquisar
Clique em Try it out para acessar o campo de consulta;
Informe o nome de um filme ou série no campo e clique em execute;
A resposta retornará em Response body;
Caso não informar nada no campo, retornará: The consulta field is required (significa que o campo é obrigatório).

- POST /api/Filme/adicionar-filme
Ação para adicionar filmes por ID;
Caso não informar nada no campo, retornará erro 404;

- POST /api/Filme/favoritos
Ação para adicionar filmes aos favoritos;
Caso não informar nada no campo, retornará erro 404;

- GET /api/Filme/favoritos/{userId}
Ação para obter filmes favoritos pelo ID do usuário;
Caso não informar nada no campo, retornará: Please correct the following validation errors and try again.
For 'userId': Required field is not provided.

- DELETE /api/Filme/favoritos/{movieId}/{userId}
Ação para excluir filme dos favoritos, utilizando ID do filme e ID de usuário;
Caso não informar nada no campo, retornará: Please correct the following validation errors and try again. 
For 'movieId': Required field is not provided.For 'userId': Required field is not provided.

- GET /api/Filme/compartilhar/{userId}
Ação para obter filme por ID do usuário e compartilhar favoritos via link.
Caso não informar nada no campo, retornará: Please correct the following validation errors and try again.
For 'userId': Required field is not provided.


# Funcionalidades do Front-end
- Desenvolvido em React, conta com interface de lista de filmes, exibição de detalhes dos filmes incluindo a nota dos filmes,
gerenciamento da lista de filmes favoritos com ações para adicionar, atualizar, compartilhar, pesquisar e remover;
- Tabela com detalhes do filme selecionado;
- Campo para pesquisar filme;
- Botão para pesquisar o filme;
- Campo para inserir o ID de usuário;
- Botão para pesquisar o ID de usuário;
- Botão para compartilhar favoritos, se houver filme favorito é um link é gerado, caso não haja favoritos um alerta é emitido
informando que não há favoritos disponíveis;
- Botão para Atualizar Lista, serve para adicionar a listagem de filmes, após adicionar um novo filme.
- Não é possível adicionar o mesmo filme duas vezes aos favoritos;
- Quando adicionar aos favoritos, um alerta é disparado com a mensagem: O filme foi adicionado aos favoritos com sucesso!
- Quando tentar adicionar novamente, um alerta é disparado com a mensagem: Esse filme já foi adicionado na sua lista de favoritos!
- O campo de pesquisar favoritos, serve para encontrar filmes pelo nome;
- O botão remover dos favoritos, serve para excluir o filme da listagem;
- A nota do filme é destacada na cor vermelha;
- O plano de fundo possui cor preta e a de layout cor aqua;
- O ícone da página representa o logo da empresa;
- Ao deixar o campo de pesquisa em branco e clicar no botão Buscar ou Pesquisar ID, uma mensagem retornará: Por favor, insira o ID de usuário antes de buscar filmes.
- Ao informar o UserId no campo e clicar no botão para buscar, retornará a mensagem: Por favor, informe o nome do filme desejado.
- Se pesquisar um nome nos favoritos e não encontrar correspondência, a tabela retornará: Nenhum filme favorito foi encontrado.

# Como testar o Back-end?
- Clique no botão verde para compilar o projeto;
- De acordo com o endpoint, preencha com um ID e depois clique em execute;
- Os resultados serão exibidos em formato JSON;

# Como testar o Front-end?
- Primeiro, clique no botão verde para compilar o projeto Back-end e mantenha-o aberto;
- Volte ao Visual Studio;
- Clique com o botão direito na pasta ratingfrondend;
- Clique em "open in terminal";
- Digite "npm start" no PowerShell do Desenvolvedor;
- Se precisar digite: "y" para aceitar a compilação;

# Tecnologias utilizadas
- React.js
- Axios
- .NET Core
- Visual Studio 2022

<h1>Teste desenvolvido por Alan.</h1>
