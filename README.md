# GrantoApi

Desenvolvimento de uma API para controle de oportunidades de venda e usuarios.

##  Começando

O projeto foi desenvolvido utilizando  C#, .Net e o framework Entity em sua versão 6 para realizar as conexoes e requisições com o banco de dados

###  Pré-requisitos

Para a execução do projeto são necessarias as seguintes ferramentas.

.Net 6
Microsoft.EntityFrameworkCore.Proxies,
Microsoft.EntityFrameworkCore,
Microsoft.EntityFrameworkCore.Tools,
  -> Framework que realiza o controle de rotas da API
  
AutoMapper.Extensions.Microsoft.DependencyInjection,
  -> utilizado para mapear as requisições passando as informações para o DTo respojnsavel 

NewtonSoft.Json,
  ->fazer a Serilização e deserilização dos JSON recebidos na s requisiçoes
Pomelo.EntityFrameworkCore.Mysql,
  ->Responsavel por realizar a conexaõ com o Banco de dados
System.Net.Http.Json
Swashbuckle.AspNetCore


```
Classes
```
Oportunidades: para receber as oportunidades lançadas
User: Recebe os usuarios do sistema


### 🔧 DTOs

São classes Auxiliares que são utilizadas para mandas as informações para o banco de dados, elas servem tanto para enviar informações quanto para recupera-las,
assim pode selecionar quais dados deseja enviar para o banco ou recuperar, alem de ser possivel adicionar novos dados na recuperação


```
Controllers
```

São as classes responsaveis por contrlar as requisições dos usuarios atravez das rotas, e em conjunto com as classes e suas DTOs, gravar e recuperar dasos do banco

```
Explicação
```
Ao realizar uma solicitação para a API o usuario consegue inserir novo usuario, para essa inserção são necessarios apenas os dados basicos da pessoa, apos a inserção é possivel cadastrar uma nova oportuinidade, ao cadastrar essa oportunidade automaticamente o sistema ira vincular esse usuario a uma nova oportunidade que seja a mesma de sua região. ALem de solicitar é possivel consultar os usuarios com suas respectivas negociaçoes cadastradas, a ordem da resposta é mostrada com as negociações no inicio e o usuario ao final da consulta.

