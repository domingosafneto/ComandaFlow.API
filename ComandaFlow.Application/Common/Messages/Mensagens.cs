
namespace ComandaFlow.Application.Common.Messages;

public static class Mensagens
{
    public static class Erro
    {
        public const string ErroInterno =
            "Ocorreu um erro interno ao processar a solicitação.";
    }

    public static class Alerta
    {
        public const string ComandaNaoEncontrada =
            "Comanda não encontrada.";

        public const string ComandaIndisponivel =
            "A comanda não está disponível.";
    }

    public static class Sucesso
    {
        public const string ComandaCadastrada =
            "Comanda cadastrada com sucesso.";

        public const string ComandaAtualizada =
            "Comanda atualizada com sucesso.";
    }
}