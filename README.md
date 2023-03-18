# variacao-ativo

-> Favor executar a aplicação localmente pelo Visual Studio, a instância do Docker na Azure está apresentando problemas. (imagem do docker: alexondei/variacaoativo:dev);

-> Banco de dados está hospedado na Azure, não é preciso executar script de criação;

-> O Ativo a ser pesquisado está parametrizado no arquivo appsettings.json, através da prorpiedade AppSettings > Ativo;

-> Executar primeiramente o endpoint POST /variacaoativo/update: ele irá recuperar os dados do ativo da API do Yahoo Finance (da data atual até 30 dias atrás),
   e irá inserir no banco de dados;

-> Para consultar os dados inseridos no banco de dados, basta executar o endpoint GET /variacaoativo.
