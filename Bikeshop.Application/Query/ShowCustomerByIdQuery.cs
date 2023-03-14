using Bikeshop.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.Query
{
    public class ShowCustomerByIdQuery : IRequest<CustomerVM>
    {
        public int Id { get; set; }

        public ShowCustomerByIdQuery(int id) { Id = id; }
    }
}
