using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMediatR.Application.Commands
{
    public record UpdateProductCommand(int id, string name) : IRequest;
}
