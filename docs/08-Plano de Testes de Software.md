# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

| **Caso de Teste** | **Detalhes do Teste** |
|:---:|:---:|
| **Caso de Teste** | **CT01 – Cadastrar perfil** |
| **Requisito Associado** | RF-01 - A plataforma deve permitir que usuários se cadastrem, selecionando seu perfil (produtor, comprador ou administrador). |
| **Objetivo do Teste** | Verificar se o usuário consegue realizar seu cadastro na plataforma. |
| **Passos** | - Acessar o navegador <br> - Informar o endereço do site https://rotarutal/src/index.html <br> - Clicar em "Criar conta" <br> - Preencher os campos obrigatórios (e-mail, nome, sobrenome, celular, CPF, senha, confirmação de senha e tipo de usuário) <br> - Aceitar os termos de uso <br> - Clicar em "Registrar" |
| **Critério de Êxito** | - O cadastro foi realizado com sucesso. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT02 – Efetuar login** |
| **Requisito Associado** | RF-01 - A plataforma deve permitir que usuários façam login. |
| **Objetivo do Teste** | Verificar se o usuário consegue realizar login na plataforma. |
| **Passos** | - Acessar o navegador <br> - Informar o endereço do site https://rotarutal/src/index.html <br> - Clicar no botão "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Clicar em "Login" |
| **Critério de Êxito** | - O login foi realizado com sucesso. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT03 – Validar a documentação** |
| **Requisito Associado** | RF-02 - A plataforma deve validar a documentação do produtor (CPF, nome da unidade familiar e número do CAF), com campo opcional para registro IMA em produtos processados. |
| **Objetivo do Teste** | Validar a veracidade dos documentos de produtor dos usuários que optarem por esse tipo de perfil. |
| **Passos** | - Acessar o navegador <br> - Realizar o login <br> - Selecionar a opção "Perfil" na barra de navegação do site <br> - Selecionar a opção "Validar Documentos de Produtor" <br> - Preencher os campos obrigatórios com os dados dos documentos <br> - Clicar em "Enviar" |
| **Critério de Êxito** | - As informações inseridas foram validadas e aprovadas. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT04 – Verificar associação da conta à microrregião devida** |
| **Requisito Associado** | RF-03 - A plataforma deve associar automaticamente o produtor à sua microrregião de Minas Gerais a partir da localização cadastrada. |
| **Objetivo do Teste** | Verificar se a conta do usuário será associada à microrregião correspondente ao endereço cadastrado. |
| **Passos** | - Acessar o navegador <br> - Selecionar a opção "Criar conta" <br> - Preencher os dados pessoais solicitados <br> - Informar o endereço do produtor <br> - Finalizar o cadastro <br> - Acessar o perfil do produtor e verificar a microrregião associada |
| **Critério de Êxito** | - O produtor é associado automaticamente à microrregião correspondente à localização cadastrada. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT05 – CRUD de Produtos** |
| **Requisito Associado** | RF-04 - A plataforma deve permitir que o produtor cadastre, edite e remova seus produtos (nome, categoria, preço, quantidade e fotos). |
| **Objetivo do Teste** | Verificar se o produtor consegue realizar todas as funções referentes ao cadastro e gerenciamento de seus produtos na plataforma. |
| **Passos** | - Acessar o navegador <br> - Realizar login <br> - Navegar até a função "Anunciar" <br> - Preencher os dados do produto que deseja vender <br> - Selecionar a opção "Salvar" <br> - Selecionar a opção "Editar" <br> - Alterar os dados do produto editado <br> - Selecionar a opção "Salvar" <br> - Selecionar a opção "Remover" |
| **Critério de Êxito** | - O usuário consegue cadastrar, editar e remover seus produtos com sucesso. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT06 – Utilizar o campo de pesquisa** |
| **Requisito Associado** | RF-05 - A plataforma deve permitir que o comprador busque produtores e produtos por microrregião, com filtros por produto, categoria e preço. |
| **Objetivo do Teste** | Verificar se o comprador consegue utilizar as funções de busca da plataforma e seus filtros. |
| **Passos** | - Acessar o navegador <br> - Realizar login <br> - Clicar no campo de pesquisa <br> - Digitar o nome do produto desejado <br> - Clicar no ícone de pesquisar <br> - Clicar no ícone de limpar pesquisa <br> - Selecionar filtro de produto, categoria ou preço <br> - Selecionar dentro do filtro escolhido as opções desejadas <br> - Selecionar "Limpar filtros" |
| **Critério de Êxito** | - Os resultados das pesquisas correspondem aos dados digitados ou aos filtros selecionados. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT07 – Simular uma compra** |
| **Requisito Associado** | RF-06 - A plataforma deve permitir que o comprador faça pedidos diretamente ao produtor e acompanhe a confirmação ou recusa do produtor. <br><br> RF-08 - A plataforma deve permitir que o comprador escolha entre entrega agendada (data/horário) ou retirada no produtor. |
| **Objetivo do Teste** | Verificar se o comprador consegue realizar todas as etapas da funcionalidade de compra. |
| **Passos** | - Acessar o navegador <br> - Realizar login <br> - Selecionar o(s) produto(s) desejado(s) <br> - Selecionar a quantidade desejada <br> - Clicar no ícone "Adicionar ao carrinho" <br> - Selecionar a opção de entrega ou retirada no produtor <br> - Caso seja escolhida a entrega, selecionar a data e horário disponíveis <br> - Clicar na opção "Finalizar Pedido" |
| **Critério de Êxito** | - O pedido é realizado com sucesso e registrado na lista de pedidos do usuário, contendo a forma de entrega escolhida. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT08 – Acompanhamento de Pedido** |
| **Requisito Associado** | RF-06 - A plataforma deve permitir que o comprador faça pedidos diretamente ao produtor e acompanhe a confirmação ou recusa do produtor. |
| **Objetivo do Teste** | Verificar se o comprador consegue acompanhar o status do pedido efetuado. |
| **Passos** | - Acessar o navegador <br> - Realizar login <br> - Clicar na opção "Minhas compras" na aba de navegação lateral <br> - Clicar na opção "Compras em andamento" <br> - Clicar no botão "Mais detalhes" |
| **Critério de Êxito** | - O pedido realizado está incluído na lista de compras. <br> - A quantidade, tipo e preço correspondem à compra realizada. <br> - O status atual do pedido está visível para o comprador. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT09 – Simular uma venda** |
| **Requisito Associado** | RF-07 - A plataforma deve permitir que o produtor visualize e atualize o status dos seus pedidos (itens, dados do comprador e forma de entrega). |
| **Objetivo do Teste** | Verificar se o produtor consegue realizar todas as etapas da funcionalidade de venda. |
| **Passos** | - Acessar o navegador <br> - Realizar login <br> - Clicar na opção "Minhas Vendas" na aba de navegação lateral <br> - Selecionar o pedido de venda recebido <br> - Verificar os itens, dados do comprador e forma de entrega <br> - Clicar em "Aceitar" ou "Recusar pedido" <br> - Caso o pedido seja aceito, atualizar o status conforme o andamento da venda <br> - Concluir a venda |
| **Critério de Êxito** | - O produtor consegue aceitar ou recusar o pedido e atualizar seu status corretamente até a conclusão da venda. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT10 – Avaliação de uma compra** |
| **Requisito Associado** | RF-09 - A plataforma deve permitir que o comprador avalie e comente sobre o produtor após a compra, exibindo a avaliação no perfil público dele. |
| **Objetivo do Teste** | Verificar se o comprador consegue realizar avaliações referentes à sua experiência com o produtor. |
| **Passos** | - Acessar o navegador <br> - Realizar login <br> - Clicar na opção "Minhas compras" na aba de navegação lateral <br> - Clicar na opção "Compras finalizadas" <br> - Selecionar um dos pedidos do histórico de compras <br> - Clicar na opção "Avaliar pedido" <br> - Selecionar uma nota de 1 a 5 <br> - Clicar na caixa de texto <br> - Digitar a avaliação <br> - Clicar no botão "Enviar Avaliação" |
| **Critério de Êxito** | - A avaliação é registrada com sucesso e fica disponível no perfil público do produtor. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT11 – Avaliação de cadastro de Produtor** |
| **Requisito Associado** | RF-10 - A plataforma deve permitir que o administrador aprove ou recuse cadastros de produtores com base na documentação, notificando o resultado. |
| **Objetivo do Teste** | Verificar se o administrador consegue aprovar ou recusar a documentação enviada pelo produtor. |
| **Passos** | - Acessar o navegador <br> - Realizar login com uma conta de administrador <br> - Acessar a área de gerenciamento de produtores <br> - Selecionar um cadastro de produtor pendente <br> - Verificar a documentação enviada <br> - Selecionar a opção "Aprovar" ou "Recusar" <br> - Confirmar a decisão |
| **Critério de Êxito** | - O cadastro é aprovado ou recusado de acordo com a decisão do administrador. <br> - O resultado da análise é registrado e o produtor é notificado. |
| &nbsp; | &nbsp; |
| **Caso de Teste** | **CT12 – Salvar produtos e produtores** |
| **Requisito Associado** | RF-11 - A plataforma deve permitir que o comprador salve produtores e produtos favoritos para acessá-los rapidamente e receber novidades. |
| **Objetivo do Teste** | Verificar se o comprador consegue marcar produtos e produtores como favoritos e acessar a lista de favoritos posteriormente. |
| **Passos** | - Acessar o navegador <br> - Realizar login <br> - Clicar no ícone de "Favorito" no produto desejado nos campos "Compras finalizadas", "Resultados de pesquisa", "Produtos na sua região" ou no perfil do produtor <br> - Clicar na opção "Favoritos" na barra lateral |
| **Critério de Êxito** | - Os produtos e produtores marcados como "Favorito" são registrados e exibidos na aba "Favoritos" do usuário. |
