using MediatR;
using CustomerService.Domain;

namespace CustomerService.Queries
{

    public class FindAllCustomersByDateQuery :IRequest<List<CustomerDto>>
    {
        private DateTime _dateTime;

        public FindAllCustomersByDateQuery(DateTime dateTime)
        {
            this._dateTime = dateTime;
        }
        
    }
}
