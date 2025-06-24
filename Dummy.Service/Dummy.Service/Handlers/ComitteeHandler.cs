using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UploadStreamToQuestDB.Application.Handlers.Abstraction;

namespace UploadStreamToQuestDB.Application.Handlers {
    internal class ComitteeHandler : AbstractHandler, ICommitteeHandler {
        private readonly IConfiguration configuration;
        private readonly ILogger<ComitteeHandler> _logger;

        public ComitteeHandler(
            IConfiguration configuration,
            ILogger<ComitteeHandler> logger) {
            this.configuration = configuration;
            this._logger = logger;
        }
        public override async Task<object> Handle(AcceptanceVO files) {
            //WIP

            return base.Handle(files);
        }
    }
}
