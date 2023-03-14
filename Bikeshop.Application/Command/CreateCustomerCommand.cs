using Bikeshop.Application.ViewModel;
using Domain.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.Command
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public Customer Customer { get; set; }

        public CreateCustomerCommand(Customer newCustomer)
        {
            Customer = newCustomer;
        }
    }
}
