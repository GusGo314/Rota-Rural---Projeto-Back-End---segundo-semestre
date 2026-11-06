(function () {
    'use strict';

    const form = document.querySelector('form[data-perfil]');
    if (!form) return;

    const radios = document.querySelectorAll('input[name="Perfil"]');
    const avisoAdmin = document.getElementById('aviso-admin');

    function perfilSelecionado() {
        const marcado = document.querySelector('input[name="Perfil"]:checked');
        return (marcado ? marcado.value : form.dataset.perfil || 'produtor').toLowerCase();
    }

    function aplicarPerfil() {
        const perfil = perfilSelecionado();
        form.dataset.perfil = perfil;

        form.querySelectorAll('[data-perfis]').forEach(campo => {
            const ativo = campo.dataset.perfis.split(' ').includes(perfil);
            campo.hidden = !ativo;
            campo.querySelectorAll('input').forEach(input => input.disabled = !ativo);
        });

        const admin = perfil === 'administrador';
        form.hidden = admin;
        if (avisoAdmin) avisoAdmin.hidden = !admin;
    }

    radios.forEach(radio => radio.addEventListener('change', aplicarPerfil));
    aplicarPerfil();

    // Máscara de CPF
    const cpf = document.getElementById('Cpf');
    if (cpf) {
        cpf.addEventListener('input', event => {
            const digitos = event.target.value.replace(/\D/g, '').slice(0, 11);
            event.target.value = digitos
                .replace(/^(\d{3})(\d)/, '$1.$2')
                .replace(/^(\d{3})\.(\d{3})(\d)/, '$1.$2.$3')
                .replace(/\.(\d{3})(\d)/, '.$1-$2');
        });
    }
})();
