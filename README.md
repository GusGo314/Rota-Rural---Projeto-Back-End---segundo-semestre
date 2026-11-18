# Rota Rural

> Em progresso — aplicação ainda não hospedada publicamente.

`Análise e Desenvolvimento de Sistemas`

`Projeto: Desenvolvimento de uma Aplicação Interativa`

`Eixo 2`

## Sobre o projeto

O Rota Rural é uma aplicação web desenvolvida para aproximar produtores rurais e compradores de uma mesma região. A plataforma permite que produtores cadastrem seus produtos e que compradores encontrem itens disponíveis de produtores do mesmo município.

O projeto foi desenvolvido como parte do curso de Análise e Desenvolvimento de Sistemas, utilizando ASP.NET Core e .NET 10.

Atualmente, a aplicação é executada localmente. Uma versão hospedada publicamente poderá ser disponibilizada futuramente.

## Funcionalidades atuais

### Autenticação e usuários

- Cadastro de produtores;
- Cadastro de compradores;
- Login e logout;
- Autenticação por cookies;
- Separação de permissões por perfil;
- Validação de CPF;
- Associação dos usuários a um município ou microrregião.

### Produtores

- Cadastro de produtos;
- Edição de produtos;
- Remoção lógica de produtos;
- Controle de estoque;
- Cadastro de preço e unidade de medida;
- Cadastro de categoria;
- Upload de imagem do produto;
- Definição de formas de retirada e entrega;
- Controle de disponibilidade dos produtos.

### Compradores

- Visualização de produtos da própria região;
- Filtro de produtos pelo município;
- Visualização do produtor responsável;
- Visualização de preço e estoque;
- Adição de produtos ao carrinho;
- Alteração de quantidade;
- Remoção de itens;
- Limpeza do carrinho;
- Cálculo de subtotais e total da compra.

## Tecnologias utilizadas

- C#;
- .NET 10;
- ASP.NET Core MVC;
- Views Razor;
- Entity Framework Core;
- SQL Server LocalDB;
- Bootstrap;
- HTML;
- CSS;
- JavaScript;
- Git e GitHub.

## Estrutura principal

    src/RotaRural
    ├── Controllers
    ├── Data
    ├── Helpers
    ├── Migrations
    ├── Models
    ├── Services
    ├── ViewModels
    ├── Views
    ├── wwwroot
    ├── Program.cs
    └── appsettings.json

## Link para acesso
https://rotarural-pucminas-hgg8d6d4fhcfg9ca.brazilsouth-01.azurewebsites.net/



## Projeto como portfólio

O repositório demonstra conhecimentos em:

- Desenvolvimento web com ASP.NET Core;
- Arquitetura MVC;
- Autenticação e autorização;
- Entity Framework Core;
- Migrations;
- Consultas com LINQ;
- Integração entre usuários, regiões e produtos;
- Controle de estoque;
- Utilização de sessões;
- Criação de interfaces com Razor, HTML e CSS.


## Integrantes

- Augusto César Queiroz de Lima;
- Bruno Savelli Brandão Gomes;
- Emilly Sara Felicio Amorin;
- Gustavo Gomes Evangelista;
- João Pedro de Andrade Oliveira;
- Weslley Henrique Ribeiro Cavalcante.

## Orientador

- José Wilson da Costa.

# Documentação

<ol>
<li><a href="docs/01-Documentação de Contexto.md"> Documentação de Contexto</a></li>
<li><a href="docs/02-Especificação do Projeto.md"> Especificação do Projeto</a></li>
<li><a href="docs/03-Metodologia.md"> Metodologia</a></li>
<li><a href="docs/04-Projeto de Interface.md"> Projeto de Interface</a></li>
<li><a href="docs/05-Arquitetura da Solução.md"> Arquitetura da Solução</a></li>
<li><a href="docs/06-Template Padrão da Aplicação.md"> Template Padrão da Aplicação</a></li>
<li><a href="docs/07-Programação de Funcionalidades.md"> Programação de Funcionalidades</a></li>
<li><a href="docs/08-Plano de Testes de Software.md"> Plano de Testes de Software</a></li>
<li><a href="docs/09-Registro de Testes de Software.md"> Registro de Testes de Software</a></li>
<li><a href="docs/10-Plano de Testes de Usabilidade.md"> Plano de Testes de Usabilidade</a></li>
<li><a href="docs/11-Registro de Testes de Usabilidade.md"> Registro de Testes de Usabilidade</a></li>
<li><a href="docs/12-Apresentação do Projeto.md"> Apresentação do Projeto</a></li>
<li><a href="docs/13-Referências.md"> Referências</a></li>
</ol>

# Código

O código da aplicação está localizado no diretório [`src`](src).

# Apresentação

<li><a href="docs/12-Apresentação do Projeto.md"> Apresentação do Projeto</a></li>
