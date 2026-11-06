namespace RotaRural.Models;

public static class CpfHelper
{
    public static string SomenteDigitos(string? valor) =>
        new((valor ?? string.Empty).Where(char.IsDigit).ToArray());

    public static bool Validar(string? valor)
    {
        var d = SomenteDigitos(valor);

        if (d.Length != 11 || d.Distinct().Count() == 1)
        {
            return false;
        }

        return d[9] - '0' == CalcularDigito(d, 9) && d[10] - '0' == CalcularDigito(d, 10);
    }

    public static string Formatar(string? valor)
    {
        var d = SomenteDigitos(valor);
        return $"{d[..3]}.{d[3..6]}.{d[6..9]}-{d[9..]}";
    }

    private static int CalcularDigito(string d, int quantidade)
    {
        var soma = 0;
        for (var i = 0; i < quantidade; i++)
        {
            soma += (d[i] - '0') * (quantidade + 1 - i);
        }
        return (soma * 10 % 11) % 10;
    }
}
