# Variação de Ativo API 

Este é o teste para desenvolvedor back-end fornecendo uma API para consultar a variação do preço de um ativo a sua escolha nos últimos 30 pregões utilizando a API Yahoo Finance https://finance.yahoo.com/ 

## Como rodar o projeto?

1. Abrir o projeto no Visual Studio, clicar com direito no projeto "Yahoo.Variacao.Ativo.API" e clicar em "Manage User Secrets/Gerenciar Segredos do Usuário".
2. No arquivo json que abrir, adicione as seguintes informações:

```
{
  "Ativos:YahooFinancasApi": "https://query2.finance.yahoo.com/v8/finance/",
  "Ativos:ConnectionString": "Server=db;Database=master;User=sa;Password=SenhaP@drao123;"
}
```

3. Agora basta definir o `docker-compose` como projeto inicial, clicando com o direito do mouse em cima dele e escolhendo a opção `Set as StartUp Project/Definir como projeto inicial`.
4. Clicar no botão de `Play` na barra superior do Visual Studio para iniciar a aplicação.

## Utilizando o swagger

1. Ao iniciar a solução, o navegador com o Swagger irá abrir;
2. Clicar no endpoint GET `/api/Ativos`;
3. Clicar no botão `Try it out`;
4. Preencher o parâmetro com o nome do ativo `Ex: PETR4.SA`;
5. Clicar em `Executar`;
6. O endpoint deve retornar os valores conforme solicitado, caso o nome do ativo informado seja válido.