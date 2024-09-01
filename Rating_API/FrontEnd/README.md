				# Projeto de Lista de Filmes - API TMdb

# Pr�-requisitos 

Node.js
NPM
Visual Studio 2022
API .NET Core
GIT


# Configura��o do banco de dados
- Abra o projeto;
- Clique com o bot�o direito em Connected Services;
- V� em add e depois em SQL Server Database;
- Escolha a terceira op��o "SQL Server Database" On-premise;
- Clique em Next;
- Em Connection string name, informe: ConnectionStrings:"DefaultConnection"
- Em Connection string value, clique no bot�o com ...
- Escolha Microsoft SQL Server (Microsoft SqlClient) em data source;
- Em Server name: informe ALAN_S\SQLEXPRESS01;
- Em authentication, escolha Windows Authentication;
- Marque a op��o Trust Server Certificate;
- Escolha " BDR " em Select or enter a database name;
- E clique em OK;
Assim o banco estar� configurado.

# Como testar o Back-end e o Front-end?
- Utilize o ID para teste de User: "21468158";

# Funcionalidades do Back-end
- Desenvolvido com Swagger, a API conta com endpoint's para pesquisar filmes, pesquisar filmes por id, adicionar filmes,
adicionar filmes numa lista de favoritos, consultar favoritos do usu�rio via ID, compartilhar favoritos do usu�rio via link e excluir filmes;
- O bot�o clear serve para limpar a resposta;
- O bot�o cancel serve para cancelar a consulta;
- O bot�o Try it serve para desbloquear o campo, para inserir informa��es;

# Endpoints
- GET /api/Filme/{id}
Clique em Try it out para acessar o campo ID;
Informe um ID e clique em execute a resposta retornar� em Response body;
Se deixar em branco e clicar em execute: Please correct the following validation errors and try again. For 'id': Required field is not provided.

- GET /api/Filme/pesquisar
Clique em Try it out para acessar o campo de consulta;
Informe o nome de um filme ou s�rie no campo e clique em execute;
A resposta retornar� em Response body;
Caso n�o informar nada no campo, retornar�: The consulta field is required (significa que o campo � obrigat�rio).

- POST /api/Filme/adicionar-filme
A��o para adicionar filmes por ID;
Caso n�o informar nada no campo, retornar� erro 404;

- POST /api/Filme/favoritos
A��o para adicionar filmes aos favoritos;
Caso n�o informar nada no campo, retornar� erro 404;

- GET /api/Filme/favoritos/{userId}
A��o para obter filmes favoritos pelo ID do usu�rio;
Caso n�o informar nada no campo, retornar�: Please correct the following validation errors and try again.
For 'userId': Required field is not provided.

- DELETE /api/Filme/favoritos/{movieId}/{userId}
A��o para excluir filme dos favoritos, utilizando ID do filme e ID de usu�rio;
Caso n�o informar nada no campo, retornar�: Please correct the following validation errors and try again. 
For 'movieId': Required field is not provided.For 'userId': Required field is not provided.

- GET /api/Filme/compartilhar/{userId}
A��o para obter filme por ID do usu�rio e compartilhar favoritos via link.
Caso n�o informar nada no campo, retornar�: Please correct the following validation errors and try again.
For 'userId': Required field is not provided.


# Funcionalidades do Front-end
- Desenvolvido em React, conta com interface de lista de filmes, exibi��o de detalhes dos filmes incluindo a nota dos filmes,
gerenciamento da lista de filmes favoritos com a��es para adicionar, atualizar, compartilhar, pesquisar e remover;
- Tabela com detalhes do filme selecionado;
- Campo para pesquisar filme;
- Bot�o para pesquisar o filme;
- Campo para inserir o ID de usu�rio;
- Bot�o para pesquisar o ID de usu�rio;
- Bot�o para compartilhar favoritos, se houver filme favorito � um link � gerado, caso n�o haja favoritos um alerta � emitido
informando que n�o h� favoritos dispon�veis;
- Bot�o para Atualizar Lista, serve para adicionar a listagem de filmes, ap�s adicionar um novo filme.
- N�o � poss�vel adicionar o mesmo filme duas vezes aos favoritos;
- Quando adicionar aos favoritos, um alerta � disparado com a mensagem: O filme foi adicionado aos favoritos com sucesso!
- Quando tentar adicionar novamente, um alerta � disparado com a mensagem: Esse filme j� foi adicionado na sua lista de favoritos!
- O campo de pesquisar favoritos, serve para encontrar filmes pelo nome;
- O bot�o remover dos favoritos, serve para excluir o filme da listagem;
- A nota do filme � destacada na cor vermelha;
- O plano de fundo possui cor preta e a de layout cor aqua;
- O �cone da p�gina representa o logo da empresa;
- Ao deixar o campo de pesquisa em branco e clicar no bot�o Buscar ou Pesquisar ID, uma mensagem retornar�: Por favor, insira o ID de usu�rio antes de buscar filmes.
- Ao informar o UserId no campo e clicar no bot�o para buscar, retornar� a mensagem: Por favor, informe o nome do filme desejado.
- Se pesquisar um nome nos favoritos e n�o encontrar correspond�ncia, a tabela retornar�: Nenhum filme favorito foi encontrado.

# Como testar o Back-end?
- Clique no bot�o verde para compilar o projeto;
- De acordo com o endpoint, preencha com um ID e depois clique em execute;
- Os resultados ser�o exibidos em formato JSON;

# Como testar o Front-end?
- Primeiro, clique no bot�o verde para compilar o projeto Back-end e mantenha-o aberto;
- Volte ao Visual Studio;
- Clique com o bot�o direito na pasta ratingfrondend;
- Clique em "open in terminal";
- Digite "npm start" no PowerShell do Desenvolvedor;
- Se precisar digite: "y" para aceitar a compila��o;

# Tecnologias utilizadas
- React.js
- Axios
- .NET Core
- Visual Studio 2022

<h1>Teste desenvolvido por Alan.</h1>
