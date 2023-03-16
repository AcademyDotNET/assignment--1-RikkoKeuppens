using Bikeshop.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop.Application.Query
{
    public class ShowCustomerByUserIdQuery : IRequest<CustomerVM>
    {
        public string UserId { get; set; }

        public ShowCustomerByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
