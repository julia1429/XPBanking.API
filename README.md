Documentação - XP INC API 

1º Método - AssetBalance
Função: Método responsável por comprar e/ou vender produtos de investimento. 
Tem como inputs: 
id (id do usuário)
assetId (id do ativo que será vendido/comprado)
value(valor que será comprado/vendido)
type (tipo de transação, tendo como: 1 - compra; 2 - venda)

Comportamento:
Caso seja do tipo = 1 (compra)
Verifica se o valor a comprar (value) é maior do que o saldo na conta do usuário, retornando erro caso seja e não deixando continuar a execução. 
Caso o usuário tenha o saldo em conta para comprar a ação, a ação é comprada. 

Caso seja do tipo 2 = (venda)
Verifica a ação que o usuário venderá, atualizando o saldo na conta do usuário como valor vendido. 

2º Método - GetConsultInvestment
Função: Retorna todos os investimentos comprados pelo usuário. 
Inputs: id (id do usuário)

3º Método - UserStatment 
Função: Retorna o extrato do usuário. 
Input: id(id do usuário)

Comportamento: 
Retorna todas as movimentações, seja compra ou venda, do usuário por dia. 

4º Método - SendEmail 
Função: Enviar email para todos os usuários que possuem ações perto do vencimento.

Comportamento:
Verifica os investimentos proximos do vencimento, retornando os emails de usuários que o possuem.
Para cada email, será enviado um email de aviso que a ação está perto do vencimento. 

