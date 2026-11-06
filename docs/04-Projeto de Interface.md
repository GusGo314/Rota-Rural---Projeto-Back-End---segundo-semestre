
# Projeto de Interface

## Diagrama de Fluxo

A jornada do usuário pelas interfaces do sistema está ilustrada no fluxograma da imagem a seguir. O detalhamento individual de cada tela pode ser consultado na seção posterior, dedicada ao Protótipo de Alta Fidelidade.

<img width="6618" height="2383" alt="rota-rural-userflow" src="https://github.com/user-attachments/assets/73797f37-11e6-470d-acf1-ef6755ebb690" />

## Wireframes

Os wireframes a seguir representam a primeira versão visual das principais telas do Rota Rural, elaborados a partir das histórias de usuário e dos requisitos funcionais levantados anteriormente. O objetivo é validar o fluxo de navegação e a organização das funcionalidades entre os perfis de produtor, comprador e administrador antes de avançar para a etapa de codificação.



## Tela - Login do produtor
Tela de autenticação com abas "Entrar" e "Criar conta". Com o papel Produtor selecionado, o login pede e-mail/senha; o cadastro pede responsável, CPF, nome da unidade familiar, endereço, número do CAF (obrigatório) e registro IMA (opcional).

<img width="1920" height="1080" alt="Tela de Login - produtor" src="https://github.com/user-attachments/assets/5978a943-59c9-48a9-801f-8d59ad2bb489" />

<img width="1920" height="1080" alt="Login produtor" src="https://github.com/user-attachments/assets/116c8e0f-8839-4a31-b181-47a0e6e74e47" />


Requisitos atendidos: 

<strong>RF01</strong> -	A plataforma deve permitir que usuários se cadastrem e façam login, selecionando seu perfil (produtor, comprador ou administrador).

<strong>RF02</strong> -	A plataforma deve validar a documentação do produtor (CPF, nome da unidade familiar e número do CAF), com campo opcional para registro IMA em produtos processados.

<strong>RF03</strong>	- A plataforma deve associar automaticamente o produtor à sua microrregião de Minas Gerais a partir da localização cadastrada.
<hr> 

## Tela - Login do comprador
Tela de autenticação com abas "Entrar" e "Criar conta", com o papel Comprador selecionado. O login é simples (e-mail/senha); o cadastro pede nome, cidade/endereço e e-mail/senha.

<img width="1920" height="1080" alt="Tela de Login - comprador" src="https://github.com/user-attachments/assets/b62b96cc-d5ad-4379-b56d-a95d7de5e47f" />

<img width="1920" height="1080" alt="Login comprador" src="https://github.com/user-attachments/assets/6c33823d-6c55-4de0-94c7-101072908a25" />


Requisito atendido:  

<strong>RF01</strong> -	A plataforma deve permitir que usuários se cadastrem e façam login, selecionando seu perfil (produtor, comprador ou administrador).
<hr>

## Tela - Login do administrador
Mesma tela de autenticação, com o papel Administrador selecionado. Só permite login — a aba de cadastro exibe um aviso de que contas de administrador são criadas internamente pela equipe.

<img width="1920" height="1080" alt="Tela de Login - administrador" src="https://github.com/user-attachments/assets/08b51bcb-347e-495d-aa54-a46700818513" />

Requisito atendido: 

<strong>RF01</strong> -	A plataforma deve permitir que usuários se cadastrem e façam login, selecionando seu perfil (produtor, comprador ou administrador).
<hr>

## Tela - Menu inicial do comprador
Tela "Explorar produtores" em modo mapa: busca por texto, filtros por categoria e preço, e um mapa estilizado com pinos de cada produtor aprovado na microrregião, além da vitrine de produtos disponíveis logo abaixo.

<img width="1920" height="1080" alt="Tel inicial - comprador" src="https://github.com/user-attachments/assets/c47c1429-da35-4828-8248-50d939dd448e" />

Requisito atendido:

<strong>RF05</strong>	- A plataforma deve permitir que o comprador busque produtores e produtos por microrregião, com filtros por produto, categoria e preço.
<hr>

## Tela - Menu inicial do comprador (lista)
Mesma tela de exploração, alternada para modo lista: cada produtor aprovado aparece em um cartão com suas categorias e avaliação média, com botão para abrir sua vitrine.

<img width="1920" height="1080" alt="Tela inicial - comprador (lista)" src="https://github.com/user-attachments/assets/c8020051-c651-484b-817b-390abf7c5d72" />

Requisito atendido:

<strong>RF05</strong>	- A plataforma deve permitir que o comprador busque produtores e produtos por microrregião, com filtros por produto, categoria e preço.
<hr>

## Tela - Detalhes do produtor
Modal aberto ao tocar em um pino do mapa ou num produtor da lista: mostra microrregião, avaliação média, a lista de produtos com preço e estoque (com botão "Pedir" em cada um), comentários recentes de compradores e um atalho para iniciar conversa.

<img width="1906" height="1091" alt="detalhes do produtor" src="https://github.com/user-attachments/assets/2c5e1651-842b-41d4-991e-9eac7fd7f024" />
<hr>

## Tela - Realização de pedidos
Modal de pedido de um produto específico: quantidade, forma de entrega (retirada e/ou agendada, conforme o que o produtor oferece), data/horário e observações. Ao confirmar, o pedido é criado e o estoque do produtor é descontado.

<img width="1920" height="1080" alt="Tela de pedido - comprador" src="https://github.com/user-attachments/assets/e7db5f9d-5118-493e-8506-a124014b02d9" />

Requisitos atendidos:

<strong>RF06</strong> -	A plataforma deve permitir um que o comprador faça pedidos diretamente ao produtor e acompanhe a confirmação ou recusa do produtor.

<strong>RF08</strong> -	A plataforma deve permitir que o comprador escolha entre entrega agendada (data/horário) ou retirada no produtor.
<hr>

## Tela - Histórico de compras
Tela "Minhas compras": lista os pedidos feitos pelo comprador com o status atualizado em tempo real (novo, aceito, em entrega/retirada, concluído) e libera o botão de avaliação quando o pedido é concluído.

<img width="1920" height="1080" alt="Minhas compras - comprador" src="https://github.com/user-attachments/assets/87f5460f-4b05-4f49-a794-88e88a3cbbee" />

Requisitos atendidos:

<strong>RF06</strong> - A plataforma deve permitir um que o comprador faça pedidos diretamente ao produtor e acompanhe a confirmação ou recusa do produtor

<strong>RF09</strong> -	A plataforma deve permitir que o comprador avalie e comente sobre o produtor após a compra, exibindo a avaliação no perfil público dele.
<hr>

## Tela - Avaliação do produtor
Modal acessado pelo histórico após um pedido concluído, para o comprador dar uma nota em estrelas e escrever um comentário, que é publicado no perfil público do produtor.

<img width="1920" height="1080" alt="Avaliar produtor - comprador" src="https://github.com/user-attachments/assets/58b7d593-0c20-4096-8534-0af6ebb1a4e7" />

Requisito atendido: 

<strong>RF09</strong> -	A plataforma deve permitir que o comprador avalie e comente sobre o produtor após a compra, exibindo a avaliação no perfil público dele.
<hr>

## Tela - Favoritos do comprador
Tela que reúne os produtos que o comprador salvou como favoritos, cada um com produtor, preço e botão de "Pedir" direto, além da opção de remover o item da lista de favoritos.

<img width="1920" height="1080" alt="Favoritos - comprador" src="https://github.com/user-attachments/assets/88c72af5-ef9e-4d5d-8cec-740be2e83008" />

Requisito atendido:

<strong>RF11</strong> -	A plataforma deve permitir que o comprador salve produtores e produtos favoritos para acessá-los rapidamente e receber novidades.
<hr>

## Tela - Mensagens do comprador
Modal de conversa com um produtor específico: exibe o histórico de mensagens trocadas e um campo para enviar uma nova, usado para alinhar quantidade, ponto de encontro e prazo.

<img width="1920" height="1080" alt="Mensagens - comprador" src="https://github.com/user-attachments/assets/eca273e3-5edf-4119-b52c-497ca0efabec" />

Requisito atendido:

<strong>RF13</strong>	- A plataforma deve permitir que produtor e comprador troquem mensagens entre si.
<hr>

## Tela - Perfil do produtor
Tela com os dados de identificação do produtor (nome da unidade familiar, CPF, CAF, IMA opcional), endereço e microrregião associada automaticamente, status do cadastro (aprovado, pendente ou recusado) e a avaliação pública recebida.

<img width="1920" height="1080" alt="Meu perfil - produtor" src="https://github.com/user-attachments/assets/7348c674-8301-42f9-9880-256a6f2e64cd" />
<hr>

## Tela - Produtos
Tela "Meus produtos": lista os itens cadastrados pelo produtor com categoria, preço, estoque atual, forma de entrega disponível e ações de editar, ajustar estoque ou remover.

<img width="1920" height="1080" alt="Meus produtos - produtor" src="https://github.com/user-attachments/assets/0a9e3d25-6a3a-48c6-9f09-cad9e905f5e7" />

Requisito atendido:

<strong>RF04</strong> -	A plataforma deve permitir que o produtor cadastre, edite e remova seus produtos (nome, categoria, preço, quantidade e fotos).
<hr>

## Tela - Criação e edição de produtos
Modal de cadastro/edição de um produto: nome, categoria, unidade, preço, quantidade em estoque e chips para marcar se está disponível para retirada, entrega agendada ou ambos.

<img width="1920" height="1080" alt="Criar produto - produtor" src="https://github.com/user-attachments/assets/f3ff2706-a940-45ae-bbd1-f81ceb57e016" />

<img width="1920" height="1080" alt="Editar produto - produtor" src="https://github.com/user-attachments/assets/87568fe3-d005-4739-9379-24870d2fe061" />

Requisito atendido:

<strong>RF04</strong> -	A plataforma deve permitir que o produtor cadastre, edite e remova seus produtos (nome, categoria, preço, quantidade e fotos).
<hr> 

## Tela - Pedidos recebidos
Tela do produtor com os pedidos feitos pelos compradores, mostrando item, quantidade, forma de entrega e um seletor de status (novo → aceito → em entrega/retirada → concluído).

<img width="1920" height="1080" alt="Pedidos recebidos - produtor" src="https://github.com/user-attachments/assets/92675663-4dd8-4bfa-8af4-eae1de1e287e" />

Requisito atendido: 

<strong>RF07</strong> -	A plataforma deve permitir que o produtor visualize e atualize o status dos seus pedidos (itens, dados do comprador e forma de entrega).
<hr>

## Tela - Mensagens do produtor
Tela que reúne as conversas iniciadas por compradores, sinalizando as pendentes de resposta e permitindo responder cada uma diretamente.

<img width="1920" height="1080" alt="Mensagens- produtor" src="https://github.com/user-attachments/assets/9f194e4f-5824-413d-a2e9-52f9fda90f76" />

Requisito atendido:

<strong>RF13</strong>	- A plataforma deve permitir que produtor e comprador troquem mensagens entre si.
<hr>

## Tela - Cadastro de produtores do administrador
Tela "Cadastros de produtores": lista todos os produtores com seus dados de documentação (CPF, CAF, IMA e microrregião) e permite aprovar ou recusar os que estão pendentes.

<img width="1920" height="1080" alt="Cadastro de produtores - administrador" src="https://github.com/user-attachments/assets/fdb91682-c171-48b6-a831-4b1b59a39523" />


Requisito atendido: 

<strong>RF10</strong> -	A plataforma deve permitir que o administrador aprove ou recuse cadastros de produtores com base na documentação, notificando o resultado
<hr>

## Tela - Relatórios do administrador
Painel com indicadores (total vendido, pedidos concluídos, produtores aprovados e microrregiões atendidas) filtráveis por período, além de um gráfico de vendas por microrregião.

<img width="1920" height="1080" alt="Relatórios - administrador" src="https://github.com/user-attachments/assets/781eab2a-baa1-477b-86e1-bd8b42dcb878" />


Requisito atendido:

<strong>RF12</strong> -	A plataforma deve permitir que o administrador acesse relatórios de vendas, produtores e microrregiões, com filtro por período.
<hr>



