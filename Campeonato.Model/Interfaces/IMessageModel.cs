using Campeonato.Model.Enums;
using System;

namespace Campeonato.Model
{
    public interface IMessageModel
    {
        DateTime DataOcorrecia { get; set; }
        string Detalhe { get; set; }
        string Mensagem { get; set; }
        MensagemTipoEnum Tipo { get; set; }

        void Alerta(string message);
        void Erro(string message);
        void Erro(string message, string detalhe);
        void Info(string message);
    }
}