using CQRS;
using MediatR;

namespace CQRS_MediatR.Commands
{
    public class AddValueCommand
    {
        public class Command : IRequest
        {
            public string Value { get; set; }
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly FakeDataStore _db;

            public Handler(FakeDataStore db)
            {
                _db = db;
            }

            protected override void Handle(Command request)
            {
                _db.AddValue(request.Value);
            }
        }
    }
}