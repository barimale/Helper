namespace UploadStreamToQuestDB.Application.Handlers.Abstraction {
    public interface IHandler {
        IHandler SetNext(IHandler handler);

        Task<object> Handle(AcceptanceVO files);
    }
}
