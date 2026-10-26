namespace ComandaFlow.Application.Common.Messages;

public static class Mensagens
{
    public static class Erro
    {
        public const string ErroInterno = "Ocorreu um erro interno ao processar a solicitação.";

        public const string FiltroInvalido = "O filtro informado é inválido.";
    }

    public static class Alerta
    {
        public const string ComandaNaoEncontrada = "Comanda não encontrada.";

        public const string ComandaIndisponivel = "A comanda não está disponível.";

        public const string NenhumaComandaEncontrada = "Nenhuma comanda encontrada.";
    }

    public static class Sucesso
    {
        public const string ComandaCadastrada = "Comanda cadastrada com sucesso.";

        public const string ComandaAtualizada = "Comanda atualizada com sucesso.";

        public const string ComandaExcluida = "Comanda excluída com sucesso.";
    }
}