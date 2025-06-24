using Microsoft.Extensions.Logging;
using UploadStreamToQuestDB.Application.Handlers.Abstraction;

namespace UploadStreamToQuestDB.Application.Handlers {
    internal class AcceptanceHandler : AbstractHandler, IacceptanceHandler {
        private readonly ILogger<AcceptanceHandler> _logger;
        private readonly IDatabase session;
        private readonly IMapper mapper;

        public AcceptanceHandler(ILogger<AcceptanceHandler> logger) {
            this._logger = logger;
        }

        public async override Task<object> Handle(AcceptanceVO item) {
            // WIP

           
            return base.Handle(item);
        }
    }
}
