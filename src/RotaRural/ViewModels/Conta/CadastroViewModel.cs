using System.ComponentModel.DataAnnotations;
using RotaRural.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace RotaRural.ViewModels.Conta;

public class CadastroViewModel
{
    [Display(Name = "Tipo de conta")]
    public string Perfil { get; set; } = Perfis.Produtor;

    [Required(ErrorMessage = "Informe seu nome.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o CPF.")]
    [Cpf]
    [Display(Name = "CPF")]
    public string Cpf { get; set; } = string.Empty;

    [StringLength(150, ErrorMessage = "O nome da unidade familiar deve ter no máximo {1} caracteres.")]
    [Display(Name = "Nome da unidade familiar")]
    public string? NomeUnidadeFamiliar { get; set; }

    [StringLength(255, ErrorMessage = "O endereço deve ter no máximo {1} caracteres.")]
    [Display(Name = "Endereço da propriedade")]
    public string? Endereco { get; set; }
    [Required(ErrorMessage = "Selecione o municipio")]
    [Display(Name = "Municipio")]
    public int? MicrorregiaoId { get; set; }

    public IEnumerable<SelectListItem> Municipios { get; set; } = Enumerable.Empty<SelectListItem>();

    [StringLength(50, ErrorMessage = "O número do CAF deve ter no máximo {1} caracteres.")]
    [Display(Name = "Número do CAF")]
    public string? Caf { get; set; }

    [StringLength(50, ErrorMessage = "O registro IMA deve ter no máximo {1} caracteres.")]
    [Display(Name = "Registro IMA")]
    public string? Ima { get; set; }

    [Required(ErrorMessage = "Informe o e-mail.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    [StringLength(150, ErrorMessage = "O e-mail deve ter no máximo {1} caracteres.")]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a senha.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Senha { get; set; } = string.Empty;

    [Required(ErrorMessage = "Confirme a senha.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Senha), ErrorMessage = "As senhas não coincidem.")]
    [Display(Name = "Confirmar senha")]
    public string ConfirmarSenha { get; set; } = string.Empty;
}
