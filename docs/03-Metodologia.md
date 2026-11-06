
# Metodologia

A equipe adotou a metodologia ágil Scrum para guiar o desenvolvimento do projeto e resolver o problema proposto. O trabalho foi dividido em ciclos de desenvolvimento, onde o foco inicial foi a organização do que deveria ser feito e a divisão clara de responsabilidades. A gestão do código-fonte e o acompanhamento do progresso das atividades foram centralizados no GitHub, garantindo que tanto a parte técnica (programação) quanto a parte conceitual (documentação e relatórios) caminhassem juntas e fossem visíveis para todos os membros do grupo.


## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/), sendo que o [Github](https://github.com)
foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `main`: versão estável já testada do software
- `unstable`: versão já testada do software, porém instável
- `testing`: versão em testes do software
- `dev`: versão de desenvolvimento do software

Quanto à gerência de issues, o projeto adota a seguinte convenção para
etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: uma funcionalidade encontra-se com problemas
- `enhancement`: uma funcionalidade precisa ser melhorada
- `feature`: uma nova funcionalidade precisa ser introduzida

## Gerenciamento de Projeto

O repositório foi configurado no GitHub com acesso compartilhado para todos os membros do grupo. O fluxo de trabalho de ramificação (branching) foi estruturado de forma que nenhum integrante trabalhasse diretamente na branch main. O desenvolvimento do dia a dia acontece na branch dev. Quando uma nova funcionalidade ou documento é finalizado, ele passa para a branch testing para validação do grupo e, após aprovado e considerado estável, é realizado o merge (combinação de códigos) para a branch main. Os commits são realizados de forma frequente com mensagens claras descrevendo o que foi alterado.A gerência de issues é feita diretamente na aba Issues do repositório do grupo. Cada entrega de etapa será separada em views dentro da aba project onde ficaram os BackLogs das respectivas etapas, categorizada com as etiquetas (labels) correspondentes e atribuída (assigned) ao membro responsável pela execução.


### Divisão de Papéis

- `Product Owner` : Bruno Savelli Brandão Gomes
- `Scrum Master` : Gustavo Gomes Evangelista
- `Dev Team` : Emilly Sara Felicio Amorin, Augusto César Queiroz de Lima, João Pedro de Andrade Oliveira e Weslley Henrique Ribeiro Cavalcante


### Processo

O grupo implementou o Scrum utilizando uma abordagem adaptada para o contexto acadêmico.

O processo funciona através dos seguintes passos: 

- `Construção do Backlog`: listagem de todas as tarefas de código e documentação (como preenchimento de metodologia e requisitos) na aba Issues do repositório do GitHub.

- `Planejamento e Execução`: O grupo utiliza o recurso de GitHub Projects configurado em modo Board (Kanban). As tarefas prioritárias saem do Backlog e entram na coluna Todo (A Fazer), recebendo um responsável direto.

- `Acompanhamento Diário`: Conforme o trabalho evolui, os membros arrastam os cartões pelas colunas In Progress (Em Andamento) até chegar em Done (Concluído), permitindo que todo o grupo e o professor acompanhem o status real do desenvolvimento da solução em tempo real.


### Ferramentas

As ferramentas empregadas no projeto são:
- `Editor de código`: VS Code (Visual Studio Code) – O editor de código foi escolhido porque possui uma integração nativa e excelente com o sistema de versão Git. Ele permite que o time escreva o código, faça commits e envie as alterações para o GitHub de forma rápida, tudo dentro do mesmo ambiente de trabalho.


- `Ferramentas de comunicação`: Microsoft Teams – O Teams foi selecionado como nossa central de comunicação oficial por já estar integrado ao ambiente acadêmico da faculdade. Ele possui recursos excelentes para reuniões agendadas, chamadas de vídeo rápidas e chat organizado por canais. Além disso, permite a criação de guias dinâmicas onde conseguimos fixar o link do nosso repositório do GitHub e do quadro Kanban, deixando o acesso às tarefas muito mais rápido para o grupo.


- `Ferramentas de desenho de tela (wireframing)`: Figma – Para criar os diagramas e protótipos, utilizamos o Figma por melhor captar as necessidades da nossa solução. Ele foi escolhido por ser uma ferramenta baseada em nuvem que permite a colaboração simultânea e em tempo real de todo o grupo. Com ele, conseguimos desenhar as telas do sistema juntos, garantindo que o visual e o fluxo do usuário fiquem alinhados antes de iniciarmos a programação.

 
> **Possíveis Ferramentas que auxiliarão no gerenciamento**: 
> - [Slack](https://slack.com/)
> - [Github](https://github.com/)
