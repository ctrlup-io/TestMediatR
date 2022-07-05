using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMediatR.Domain.Queries
{
    public record CheckIfProductExists(int Id) : IRequest<bool>;
}
