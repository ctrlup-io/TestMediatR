using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMediatR.Application.Commands
{
    public record UpdateProductCommand(Guid id, string name) : IRequest;
}
