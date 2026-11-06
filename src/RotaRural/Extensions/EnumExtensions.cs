using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RotaRural.Extensions
{
    public static class EnumExtensions
    {
        public static string NomeExibicao(this Enum valor) =>
            valor.GetType().GetMember(valor.ToString()).First()
                .GetCustomAttribute<DisplayAttribute>()?.GetName() ?? valor.ToString();
    }
}