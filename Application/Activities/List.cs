using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        //Query interface from irequest       irest return  list of activity
        public class Query : IRequest<List<Activity>> { }

        //hander   type paramter is query     return is list of acrtivity
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            //injext context to use in this class
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }


            //query request parameter. inside handle we need to access context, so we need injext context
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await _context.Activities.ToListAsync();

                return activities;
            }
        }
    }
}