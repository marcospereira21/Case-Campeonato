using Campeonato.Model.Enums;
using System;

namespace Campeonato.Model
{
    public class MessageModel : IMessageModel
    {
        public string Mensagem { get; set; } = "Tarefa realizada com sucesso.";
        public string Detalhe { get; set; }
        public DateTime DataOcorrecia { get; set; } = DateTime.Now;
        public MensagemTipoEnum Tipo { get; set; } = MensagemTipoEnum.Info;


        public void Info(string message)
        {
            Mensagem = message;
        }

        public void Erro(string message, string detalhe)
        {
            Mensagem = message;
            Detalhe = detalhe;
            Tipo = MensagemTipoEnum.Erro;
        }

        public void Erro(string message)
        {
            Mensagem = message;
            Tipo = MensagemTipoEnum.Erro;
        }

        public void Alerta(string message)
        {
            Mensagem = message;
            Tipo = MensagemTipoEnum.Alerta;
        }
    }
}
