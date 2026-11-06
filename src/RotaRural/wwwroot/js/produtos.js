document.addEventListener('DOMContentLoaded', () => {
    const modal = document.getElementById('modal');
    if (!modal) return;

    // Coloca a view recebida dentro do modal e liga a validação ao formulário
    function mostrarNoModal(html) {
        modal.innerHTML = html;

        const form = modal.querySelector('form');
        if (form) {
            $.validator.unobtrusive.parse(form);
        }
    }

    // ---------- Abrir: busca a view da ação (GET) ----------
    document.querySelectorAll('[data-abrir-modal]').forEach(botao => {
        botao.addEventListener('click', async () => {
            const resposta = await fetch(botao.dataset.url);

            if (!resposta.ok) {
                alert('Não foi possível abrir. Tente novamente.');
                return;
            }

            modal.classList.toggle('modal-pequeno', botao.dataset.tamanho === 'pequeno');
            mostrarNoModal(await resposta.text());
            modal.showModal();
        });
    });

    // ---------- Salvar: envia o formulário do modal (POST) ----------
    modal.addEventListener('submit', async evento => {
        evento.preventDefault();

        const form = evento.target;
        if (!$(form).valid()) return;   // a validação do navegador encontrou erros

        const resposta = await fetch(form.action, {
            method: 'POST',
            body: new FormData(form),   // inclui os campos, a foto e o token de segurança
            redirect: 'manual'
        });

        // O controller redirecionou para o Index: salvou com sucesso
        if (resposta.type === 'opaqueredirect') {
            window.location.reload();
            return;
        }

        if (!resposta.ok) {
            alert('Não foi possível salvar. Tente novamente.');
            return;
        }

        // O controller devolveu a view de novo: erro de validação, mostra as mensagens
        mostrarNoModal(await resposta.text());
    });

    // ---------- Fechar no "Cancelar" ----------
    modal.addEventListener('click', evento => {
        if (evento.target.closest('[data-fechar-modal]')) {
            modal.close();
        }
    });
});