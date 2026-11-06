// A validação do jQuery entende "4.50", mas não "4,50". Aqui ensinamos o formato brasileiro.

$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^\d+(,\d{1,2})?$/.test(value);
};

$.validator.methods.range = function (value, element, param) {
    const numero = Number(String(value).replace(',', '.'));
    return this.optional(element) || (numero >= param[0] && numero <= param[1]);
};