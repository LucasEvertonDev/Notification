using Notification.Entities;

namespace Notification.Models;

public class EnderecoModel
{
    public string Cep { get; set; }
    public string Estado { get; set; }
    public string Cidade { get; set; }

    public Logradouro Logradouro { get; set; }
}
