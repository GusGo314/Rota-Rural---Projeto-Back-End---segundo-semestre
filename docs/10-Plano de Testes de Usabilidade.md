# Plano de Testes de Usabilidade

## Definição do(s) objetivo(s)

O teste de usabilidade tem como objetivo avaliar a interface, a facilidade de navegação e a fluidez das tarefas essenciais dentro da plataforma. Os principais objetivos incluem:

- **Avaliação de Tarefas Críticas:** Verificar se os perfis (Comprador, Produtor e Administrador) conseguem realizar fluxos principais sem falhas ou confusões.
- **Mapeamento de Barreiras:** Identificar gargalos de UX, falhas de clareza em formulários e problemas de acessibilidade.
- **Análise de Eficiência e Satisfação:** Medir tempo de conclusão, taxa de erro e nível de satisfação percebido.
- **Validação de Negócio e LGPD:** Garantir a conformidade dos dados e fluxos de cadastro sem expor informações sensíveis.

## Seleção dos participantes

Para garantir representatividade real do público-alvo, serão selecionados no mínimo 8 a 10 participantes divididos em três grupos de perfis.

### Critérios de Seleção

- **Perfil Produtor Rural (3-4 voluntários):** Pessoas com variação na alfabetização digital, atuantes no setor produtivo local.
- **Perfil Comprador (3-4 voluntários):** Consumidores com diferentes níveis de experiência em e-commerce e plataformas digitais.
- **Perfil Administrador (1-2 voluntários):** Usuários com conhecimento técnico ou gestor intermediário.

## Cenários de Teste

Abaixo estão definidos 6 cenários essenciais abrangendo todos os 13 Requisitos Funcionais (RF01 ao RF13).

## Cenário 1: Cadastro e Aprovação de Produtor

- **Requisitos Associados:** RF01, RF02, RF03, RF10
- **Objetivo:** Avaliar a clareza e facilidade do preenchimento de documentos e a aprovação por parte do perfil administrador.
- **Contexto:** Um produtor rural da microrregião de Minas Gerais deseja cadastrar sua propriedade e linha de produtos na plataforma. Em seguida, um administrador precisa validar a documentação enviada.
- **Tarefas:**
  - Acessar a plataforma e selecionar a opção de cadastro como Produtor.
  - Preencher os dados obrigatórios: CPF, nome da unidade familiar, número do CAF e registro IMA (opcional).
  - Verificar se a microrregião foi vinculada automaticamente à sua localização.
  - Com o perfil de Administrador, acessar a aba de pendências, analisar a documentação e aprovar o cadastro.
- **Critérios de Sucesso:**
  - O cadastro do produtor é concluído sem erros de validação em campos válidos.
  - O sistema associa corretamente a microrregião sem intervenção manual.
  - O administrador consegue aprovar o cadastro e o sistema dispara a notificação de confirmação.
  - Processo de cadastro realizado pelo produtor em menos de 4 minutos.

## Cenário 2: Gestão de Catálogo do Produtor

- **Requisitos Associados:** RF04
- **Objetivo:** Testar a eficiência da criação, edição e exclusão de itens na vitrine do produtor.
- **Contexto:** Um produtor aprovado precisa incluir novos produtos (como queijos e hortaliças), atualizar estoques e remover itens esgotados.
- **Tarefas:**
  - Realizar login como Produtor.
  - Cadastrar um novo produto contendo: nome, categoria, preço, quantidade em estoque e pelo menos uma imagem.
  - Editar a quantidade do produto recém-criado.
  - Excluir um produto de teste do catálogo.
- **Critérios de Sucesso:**
  - O upload de imagem funciona sem interrupções.
  - O produto é publicado na vitrine pública imediatamente após a criação.
  - A edição e remoção confirmam as alterações corretamente.

## Cenário 3: Busca, Filtro e Favoritos pelo Comprador

- **Requisitos Associados:** RF05, RF11
- **Objetivo:** Avaliar a usabilidade da busca regionalizada, uso de filtros e persistência de itens salvos.
- **Contexto:** Um comprador deseja encontrar produtores de queijo artesanal em uma microrregião específica de Minas Gerais e salvar seus favoritos para compras futuras.
- **Tarefas:**
  - Acessar a plataforma como Comprador.
  - Utilizar a busca por microrregião e aplicar filtros de categoria ("Laticínios") e limite de preço.
  - Selecionar um produtor da lista e adicioná-lo aos "Produtores Favoritos".
  - Adicionar um produto à lista de "Produtos Favoritos" e verificar a aba de salvos.
- **Critérios de Sucesso:**
  - Os resultados da busca trazem apenas itens/produtores correspondentes aos filtros aplicados.
  - Botões de "Favoritar" fornecem feedback visual claro.
  - A lista de favoritos exibe os itens corretamente atualizados em menos de 2 cliques.

## Cenário 4: Realização e Acompanhamento de Pedido

- **Requisitos Associados:** RF06, RF07, RF08
- **Objetivo:** Medir a facilidade do fluxo de compra, escolha do formato de entrega e aceite por parte do produtor.
- **Contexto:** O comprador deseja realizar um pedido direto com o produtor, escolhendo entre entrega agendada ou retirada no local, e acompanhar a resposta do produtor.
- **Tarefas:**
  - Selecionar produtos de um mesmo produtor e iniciar o pedido.
  - Escolher a modalidade "Entrega Agendada" (selecionando data e hora) ou "Retirada".
  - Enviar o pedido para o produtor.
  - Alternar para a visão do Produtor, visualizar a notificação do pedido e alterar o status para "Confirmado".
  - Alternar para a visão do Comprador e verificar a atualização do status na tela de acompanhamento.
- **Critérios de Sucesso:**
  - O seletor de data e horário de entrega é intuitivo.
  - O produtor consegue atualizar o status do pedido sem ambiguidade.
  - As alterações de status refletem em tempo real no painel do comprador.

## Cenário 5: Comunicação e Avaliação Pós-Venda

- **Requisitos Associados:** RF09, RF13
- **Objetivo:** Avaliar a usabilidade do sistema de mensageria direta e o formulário de avaliação do produtor.
- **Contexto:** Após a conclusão de uma entrega, comprador e produtor precisam alinhar detalhes por mensagem e o comprador deseja deixar uma avaliação no perfil do produtor.
- **Tarefas:**
  - Acessar a central de mensagens do pedido e enviar uma dúvida ao produtor.
  - Como produtor, responder à mensagem recebida.
  - Como comprador, acessar a aba "Meus Pedidos Finalizados", atribuir uma nota em estrelas e redigir um comentário sobre a experiência.
  - Acessar o perfil público do produtor e verificar a exibição da nota e comentário.
- **Critérios de Sucesso:**
  - O envio e recebimento de mensagens ocorrem sem perdas de texto ou atrasos significativos.
  - A avaliação é vinculada ao perfil público do produtor corretamente.
  - O formulário de avaliação limita a nota/comentário apenas a compras finalizadas.

## Cenário 6: Emissão de Relatórios Administrativos

- **Requisitos Associados:** RF12
- **Objetivo:** Verificar a acessibilidade dos relatórios gerenciais e a aplicação de filtros temporais.
- **Contexto:** O administrador da plataforma precisa extrair um relatório de vendas e atividade por microrregião referente ao último mês.
- **Tarefas:**
  - Realizar login como Administrador.
  - Navegar até o painel de Relatórios.
  - Filtrar os dados por período (ex: últimos 30 dias) e por microrregião.
  - Visualizar os gráficos/tabelas e exportar ou consultar as métricas consolidadas.
- **Critérios de Sucesso:**
  - Os filtros atualizam os dados da tela em menos de 3 segundos.
  - As informações visuais (gráficos/tabelas) são legíveis e fáceis de interpretar.

## Métodos de coleta de dados

Os dados coletados devem ajudar a entender a experiência dos usuários por meio de métricas quantitativas, qualitativas e questionários pós-teste.

- **Métricas Quantitativas:**
  - **Taxa de Conclusão de Tarefas (Completion Rate):** Porcentagem de voluntários que concluíram o cenário com sucesso.
  - **Tempo Médio na Tarefa (Time on Task):** Medição do tempo desde o início até a finalização da ação.
  - **Taxa de Erro (Error Rate):** Quantidade de cliques incorretos ou navegação desviada por tarefa.
  - **Frequência de Pedidos de Ajuda:** Número de vezes em que o usuário solicitou auxílio do facilitador.

- **Métricas Qualitativas:**
  - **Observação Direta (Protocolo Think Aloud):** Solicitar que o participante fale seus pensamentos enquanto navega.
  - **Mapeamento de Pontos de Fricção:** Registro de hesitações, expressões corporais e comentários espontâneos durante o uso.

- **Questionário Pós-Teste (System Usability Scale - SUS Modificado):**
  - Ao final das tarefas, cada participante responderá às seguintes perguntas em uma escala Likert de 1 (Discordo Totalmente) a 5 (Concordo Totalmente):
    - Achei a interface fácil de utilizar.
    - Achei que as etapas para concluir as tarefas foram lógicas e diretas.
    - Senti necessidade de ajuda técnica para navegar no sistema.
    - Encontrei facilmente as informações de produtores e microrregiões.
    - Me senti seguro em relação às informações e etapas realizadas.

## Consolidação e Coleta de Dados dos Participantes

Ficha individual simplificada a ser preenchida para cada voluntário do teste (em conformidade com a LGPD):

```text
====================================================================
FICHA DE AVALIAÇÃO DE USABILIDADE - TESTE INDIVIDUAL
====================================================================
ID do Voluntário: VOL-01              Perfil: Comprador
Data do Teste: __/__/202X             Facilitador: [Nome]

METRICAS POR CENÁRIO:
--------------------------------------------------------------------
Cenário | Concluído? | Tempo (s) | N° Erros | Pedidos de Ajuda
--------|------------|-----------|----------|------------------
C1      | [S/N]      |           |          |
C2      | [S/N]      |           |          |
C3      | [S/N]      |           |          |
C4      | [S/N]      |           |          |
C5      | [S/N]      |           |          |
C6      | [S/N]      |           |          |

OBSERVAÇÕES QUALITATIVAS (THINK ALOUD):
- [Comentários e dificuldades relatadas pelo usuário durante o teste]

RESPOSTAS AO QUESTIONÁRIO PÓS-TESTE (Escala 1 a 5):
Q1: [ ] | Q2: [ ] | Q3: [ ] | Q4: [ ] | Q5: [ ]

SUGESTÕES DE MELHORIA RELATADAS:
- [Ponto de melhoria 1]
- [Ponto de melhoria 2]
====================================================================
