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

## Requisitos para executar

Instale previamente:

- Git;
- .NET 10 SDK;
- SQL Server LocalDB;
- Visual Studio 2026 com a carga de trabalho **ASP.NET e desenvolvimento Web**.

O SQL Server LocalDB normalmente é instalado junto com o Visual Studio.

## Clonar o projeto

No terminal, execute:

    git clone --branch Feature-Atribuicao-Microrregiao https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2026-2-e2-proj-int-t2-rota-rural.git
    cd pmv-ads-2026-2-e2-proj-int-t2-rota-rural

## Restaurar as dependências

    dotnet restore

## Configurar o banco de dados

O projeto utiliza inicialmente o SQL Server LocalDB:

    (localdb)\MSSQLLocalDB

A connection string está localizada em:

    src/RotaRural/appsettings.json

Para criar ou atualizar o banco de dados usando as migrations, execute:

    dotnet ef database update --project src/RotaRural/RotaRural.csproj

Caso o comando `dotnet ef` não esteja disponível, instale a ferramenta:

    dotnet tool install --global dotnet-ef

Também é possível atualizar o banco pelo Visual Studio:

1. Abra a solução `RotaRural.slnx`;
2. Acesse **Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes**;
3. Execute:

    Update-Database

A aplicação pode consultar dados externos para carregar os municípios. Portanto, é recomendável ter conexão com a internet na primeira execução.

## Executar pelo terminal

Na raiz do repositório, execute:

    dotnet run --project src/RotaRural/RotaRural.csproj

A aplicação normalmente ficará disponível em:

    https://localhost:7223

ou:

    http://localhost:5146

Como esses endereços utilizam `localhost`, a aplicação estará acessível somente no computador que estiver executando o projeto.

## Executar pelo Visual Studio

1. Abra o arquivo `RotaRural.slnx`;
2. Defina `RotaRural` como projeto de inicialização;
3. Escolha o perfil `https` ou `http`;
4. Pressione `F5` ou selecione **Depurar > Iniciar sem Depuração**;
5. O navegador será aberto automaticamente.

## Fluxo principal da aplicação

1. O usuário cria uma conta como produtor ou comprador;
2. Seleciona seu município;
3. O produtor cadastra produtos e controla seu estoque;
4. O comprador acessa a vitrine;
5. A vitrine apresenta produtos disponíveis de produtores da mesma região;
6. O comprador adiciona os produtos ao carrinho;
7. O carrinho permite ajustar quantidades, remover itens e visualizar o total.

## Observações importantes

- O banco de dados é local e não é compartilhado pelo GitHub;
- Cada pessoa que executar o projeto terá seu próprio banco LocalDB;
- O carrinho é armazenado na sessão do navegador;
- O carrinho pode ser perdido quando a sessão expirar ou quando o usuário trocar de navegador;
- A finalização de pedido, pagamento e baixa definitiva do estoque ainda não fazem parte do escopo atual;
- A aplicação ainda não possui hospedagem pública;
- Não é possível acessar o endereço `localhost` de outro computador;
- Não inclua senhas, tokens, chaves de API ou outros dados sensíveis no repositório.

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

Uma futura versão hospedada poderá ser adicionada para permitir o acesso direto pelo navegador sem a necessidade de clonar e executar o projeto localmente.

## Integrantes

- Augusto César Queiroz de Lima;
- Bruno Savelli Brandão Gomes;
- Emilly Sara Felicio Amorin;
- Gustavo Gomes Evangelista;
- João Pedro de Andrade Oliveira;
- Weslley Henrique Ribeiro Cavalcante.

## Orientador

- José Wilson da Costa.

## Status da aplicação

A aplicação ainda não está hospedada publicamente.

Enquanto não houver uma versão online, é necessário clonar o repositório e executar o projeto localmente seguindo as instruções deste documento.

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
