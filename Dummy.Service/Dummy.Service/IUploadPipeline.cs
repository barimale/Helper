using UploadStreamToQuestDB.Application.Handlers.Abstraction;

namespace UploadStreamToQuestDB.Application {
    /// <summary>
    /// Defines the interface for an upload pipeline.
    /// </summary>
    public interface IUploadPipeline {
        void Initialize();
        /// <summary>
        /// Runs the upload pipeline with the specified files.
        /// </summary>
        /// <param name="files">The files to process.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Run(AcceptanceVO files);
    }
}
