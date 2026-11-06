# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="04-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.

```mermaid
classDiagram
    class Usuario {
        -id: int
        -nome: string
        -email: string
        -senha: string
        +login(email, senha) bool
        +cadastrar() void
        +atualizarPerfil() void
    }

    class Produtor {
        -cpf: string
        -nomeUnidadeFamiliar: string
        -CAF: string
        -IMA: string
        -statusAprovacao: string
        +cadastrarProduto(produto) void
        +editarProduto(produto) void
        +removerProduto(produto) void
        +vizualizarPedidos() List~Pedido~
        +atualizarStatusPedido(pedido, status) void
        +enviarMensagem(comprador, conteudo) void
    }

    class Comprador {
        -endereco: string
        +buscarProduto(filtro) List~Produto~
        +realizarPedido(itens) Pedido
        +avaliarProdutor(produtor, nota, comentario) void
        +favoritar(item) void
        +historicoCompras() List~Pedido~
        +enviarMensagem(produtor, conteudo) void
    }

    class Administrador {
        +aprovarCadastro(produtor) void
        +recusarCadastro(produtor, motivo) void
        +gerarRelatorio(filtro) Relatorio
    }

    class Relatorio {
        -periodoInicio: DateTime
        -periodoFim: DateTime
        -totalVendas: decimal
        -totalPedidos: int
    }

    class Microrregiao {
        -id: int
        -nome: string
    }

    class Avaliacao {
        -id: int
        -nota: int
        -comentario: string
        -data: DateTime
    }

    class Mensagem {
        -id: int
        -conteudo: string
        -dataEnvio: DateTime
        -lida: bool
        +enviar() void
        +marcarLida() void
    }

    class Pedido {
        -id: int
        -data: DateTime
        -status: string
        -formaEntrega: string
        -dataEntregaAgendada: DateTime
        +confirmar() void
        +recusar() void
        +calcularTotal() decimal
        +atualizarStatus(status) void
    }

    class Produto {
        -id: int
        -nome: string
        -categoria: string
        -preco: decimal
        -quantidade: int
        -foto: string
        -disponibilidadeEntrega: string
        +atualizarEstoque(quantidade) void
        +atualizarDisponibilidade(status) void
    }

    class ItemPedido {
        -id: int
        -quantidade: int
        -precoUnitario: decimal
        +calcularSubtotal() decimal
    }

    Usuario <|-- Produtor
    Usuario <|-- Comprador
    Usuario <|-- Administrador

    Produtor "*" -- "1" Microrregiao
    Produtor "1" -- "*" Avaliacao
    Produtor "*" -- "*" Mensagem
    Produtor "1" -- "*" Pedido
    Produtor "1" -- "*" Produto

    Comprador "1" -- "*" Avaliacao
    Comprador "*" -- "*" Mensagem
    Comprador "1" -- "*" Pedido

    Pedido "1" -- "*" ItemPedido
    Produto "1" -- "*" ItemPedido

    Administrador ..> Relatorio : gera
```

## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

Sugestão de ferramentas para geração deste artefato: LucidChart e Draw.io.

A referência abaixo irá auxiliá-lo na geração do artefato “Modelo ER”.

> - [Como fazer um diagrama entidade relacionamento | Lucidchart](https://www.lucidchart.com/pages/pt/como-fazer-um-diagrama-entidade-relacionamento)

```mermaid
---
config:
    layout: elk
---
graph LR
    classDef derivado stroke-dasharray: 5 5

    USUARIO[USUARIO]
    IDU((<u>id</u>))
    NOMEU((nome))
    EMAIL((email))
    SENHA((senha))
    PERFIL((perfil))
    USUARIO --- IDU
    USUARIO --- NOMEU
    USUARIO --- EMAIL
    USUARIO --- SENHA
    USUARIO --- PERFIL

    VENDEDOR[VENDEDOR]
    CPF((<u>cpf</u>))
    NOMEUNI((nomeUnidade))
    CAF((numeroCAF))
    IMA((registroIMA))
    STATUS((statusAprovacao))
    ENDEV((endereço))
    VENDEDOR --- CPF
    VENDEDOR --- NOMEUNI
    VENDEDOR --- CAF
    VENDEDOR --- IMA
    VENDEDOR --- STATUS
    VENDEDOR --- ENDEV
    LOGRA((logradouro))
    MUNI((município))
    CEPS((CEP))
    ENDEV --- LOGRA
    ENDEV --- MUNI
    ENDEV --- CEPS

    COMPRADOR[COMPRADOR]
    CPFC((<u>cpf</u>))
    ENDEC((endereço))
    COMPRADOR --- CPFC
    COMPRADOR --- ENDEC

    USUARIO --- D((d))
    D --- VENDEDOR
    D --- COMPRADOR
    linkStyle 16,17,18 stroke:#222,stroke-width:3px

    MICRORREGIAO[MICRORREGIAO]
    CODM((<u>codigo</u>))
    NOMEM((nome))
    REGIAO((regiao))
    MICRORREGIAO --- CODM
    MICRORREGIAO --- NOMEM
    MICRORREGIAO --- REGIAO

    AGRUPA{AGRUPA}
    MICRORREGIAO ---|"(1,1)"| AGRUPA
    AGRUPA ---|"(1,N)"| VENDEDOR

    PRODUTO[PRODUTO]
    CODP((<u>codigo</u>))
    NOMEP((nome))
    CATEG((categoria))
    PRECO((preco))
    QTD((quantidade))
    FOTOS(((fotos)))
    PRODUTO --- CODP
    PRODUTO --- NOMEP
    PRODUTO --- CATEG
    PRODUTO --- PRECO
    PRODUTO --- QTD
    PRODUTO --- FOTOS

    POSSUI{POSSUI}
    VENDEDOR ---|"(1,1)"| POSSUI
    POSSUI ---|"(1,N)"| PRODUTO

    PEDIDO[PEDIDO]
    IDP((<u>id</u>))
    DATA((data))
    STATUSP((status))
    FENT((formaEntrega))
    DENT((dataEntrega))
    VTOT((valorTotal))
    PEDIDO --- IDP
    PEDIDO --- DATA
    PEDIDO --- STATUSP
    PEDIDO --- FENT
    PEDIDO --- DENT
    PEDIDO --- VTOT
    class VTOT derivado

    FAZ{FAZ}
    COMPRADOR ---|"(1,N)"| FAZ
    FAZ ---|"(1,1)"| PEDIDO
    RECEBE{RECEBE}
    VENDEDOR ---|"(1,N)"| RECEBE
    RECEBE ---|"(1,1)"| PEDIDO

    ITEM_PEDIDO[[ITEM_PEDIDO]]
    NUM((<u>numero</u>))
    QTDIT((quantidade))
    PUNIT((precoUnitario))
    ITEM_PEDIDO --- NUM
    ITEM_PEDIDO --- QTDIT
    ITEM_PEDIDO --- PUNIT

    COMPOSTO{COMPOSTO POR}
    PEDIDO ---|"(1,N)"| COMPOSTO
    COMPOSTO ---|"(1,1)"| ITEM_PEDIDO
    REFERENCIA{REFERENCIA}
    ITEM_PEDIDO ---|"(N,1)"| REFERENCIA
    REFERENCIA ---|"(1,1)"| PRODUTO

    AVALIA{AVALIA}
    COMPRADOR ---|"(0,N)"| AVALIA
    AVALIA ---|"(0,N)"| VENDEDOR
    AVALIACAO[AVALIACAO]
    NOTA((nota))
    COMENT((comentario))
    DATAA((data))
    AVALIACAO --- NOTA
    AVALIACAO --- COMENT
    AVALIACAO --- DATAA
    AVALIA --- AVALIACAO

    FAVPROD{FAVORITA PRODUTO}
    COMPRADOR ---|"(0,N)"| FAVPROD
    FAVPROD ---|"(0,N)"| PRODUTO
    FAVVEN{FAVORITA VENDEDOR}
    COMPRADOR ---|"(0,N)"| FAVVEN
    FAVVEN ---|"(0,N)"| VENDEDOR
    FAVORITO[FAVORITO]
    DATAF((data))
    FAVORITO --- DATAF
    FAVPROD --- FAVORITO
    FAVVEN --- FAVORITO
```

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.

```mermaid 
erDiagram
    Microrregiao {
        int id PK
        varchar_100 nome
    }

    Usuario {
        int id PK
        varchar_100 nome
        varchar_150 email
        varchar_255 senha
    }

    Produtor {
        int idUsuario "PK, FK"
        varchar_14 cpf
        varchar_150 nomeUnidadeFamiliar
        varchar_50 numeroCAF
        varchar_50 registroIMA
        varchar_20 statusAprovacao
        int idMicrorregiao FK
    }

    Comprador {
        int idUsuario "PK, FK"
        varchar_255 endereco
    }

    Administrador {
        int idUsuario "PK, FK"
    }

    Avaliacao {
        int id PK
        int nota
        varchar_500 comentario
        datetime data
        int idComprador FK
        int idProdutor FK
    }

    Pedido {
        int id PK
        datetime data
        varchar_20 status
        varchar_20 formaEntrega
        datetime dataEntregaAgendada "NULL"
        int idComprador FK
        int idProdutor FK
    }

    Mensagem {
        int id PK
        varchar_500 conteudo
        datetime dataEnvio
        bit lida
        int idComprador FK
        int idProdutor FK
    }

    Produto {
        int id PK
        varchar_150 nome
        varchar_100 categoria
        decimal_10_2 preco
        int quantidade
        varchar_255 fotos
        varchar_20 disponibilidadeEntrega
        int idProdutor FK
    }

    ItemPedido {
        int id PK
        int quantidade
        decimal_10_2 precoUnitario
        int idPedido FK
        int idProduto FK
    }

    Usuario ||--o| Produtor : "e"
    Usuario ||--o| Comprador : "e"
    Usuario ||--o| Administrador : "e"

    Microrregiao ||--o{ Produtor : "possui"

    Produtor ||--o{ Avaliacao : "recebe"
    Produtor ||--o{ Pedido : "recebe"
    Produtor ||--o{ Mensagem : "envia/recebe"
    Produtor ||--o{ Produto : "cadastra"

    Comprador ||--o{ Avaliacao : "faz"
    Comprador ||--o{ Pedido : "realiza"
    Comprador ||--o{ Mensagem : "envia/recebe"

    Pedido ||--o{ ItemPedido : "contem"
    Produto ||--o{ ItemPedido : "compoe"
```

## ATENÇÃO!!!

Os três artefatos — **Diagrama de Classes, Modelo ER e Projeto da Base de Dados** — devem ser desenvolvidos de forma sequencial e integrada, garantindo total coerência e compatibilidade entre eles. O diagrama de classes orienta a estrutura e o comportamento do software; o modelo ER traduz essa estrutura para o nível conceitual dos dados; e o projeto da base de dados materializa essas definições no formato físico (tabelas, colunas, chaves e restrições). A construção isolada ou desconexa desses elementos pode gerar inconsistências, dificultar a implementação e comprometer a qualidade do sistema.

## Tecnologias Utilizadas

Descreva aqui qual(is) tecnologias você vai usar para resolver o seu problema, ou seja, implementar a sua solução. Liste todas as tecnologias envolvidas, linguagens a serem utilizadas, serviços web, frameworks, bibliotecas, IDEs de desenvolvimento, e ferramentas.

Apresente também uma figura explicando como as tecnologias estão relacionadas ou como uma interação do usuário com o sistema vai ser conduzida, por onde ela passa até retornar uma resposta ao usuário.

## Hospedagem

Explique como a hospedagem e o lançamento da plataforma foi feita.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)
