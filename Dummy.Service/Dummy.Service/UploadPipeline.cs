using Microsoft.Extensions.Logging;
using UploadStreamToQuestDB.Application.Handlers;
using UploadStreamToQuestDB.Application.Handlers.Abstraction;

namespace UploadStreamToQuestDB.Application {
    /// <summary>
    /// Represents the upload pipeline for handling file uploads.
    /// </summary>
    public class UploadPipeline : IUploadPipeline {
        private readonly IacceptanceHandler acceptanceHandler;
        private readonly ICommitteeHandler comitieeHandler;
        private readonly ILogger<UploadPipeline> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadPipeline"/> class.
        /// </summary>
        /// <param name="accetpanceHandler">The upload handler.</param>
        /// <param name="extensionHandler">The extension handler.</param>
        /// <param name="comittieeHandler">The antivirus handler.</param>
        /// <param name="dataIngestionerHandler">The data ingestion handler.</param>
        /// <param name="diskCleanUpHandler">The disk cleanup handler.</param>
        /// <param name="logger">The logger.</param>
        public UploadPipeline(IacceptanceHandler accetpanceHandler,
            ICommitteeHandler comittieeHandler,
            ILogger<UploadPipeline> logger) {
            this.acceptanceHandler = accetpanceHandler;
            this.comitieeHandler = comittieeHandler;
            this.logger = logger;
        }

        /// <summary>
        /// Initializes the upload pipeline
        /// </summary>
        /// <param name="controller">The controller to set for the upload handler.</param>
        public void Initialize() {
            logger.LogTrace("Controller for UploadHandler is set.");
            logger.LogTrace("Pipeline configuration starts.");
            acceptanceHandler
               .SetNext(comitieeHandler);
            logger.LogTrace("Pipeline configuration is ended.");
        }

        /// <summary>
        /// Runs the upload pipeline with the specified files.
        /// Order of handlers is specific.
        /// </summary>
        /// <param name="files">The files to process.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Run(AcceptanceVO files) {
            logger.LogTrace("Start handling.");
            await acceptanceHandler.Handle(files);
            logger.LogTrace("Handling is ended.");
        }
    }
}
