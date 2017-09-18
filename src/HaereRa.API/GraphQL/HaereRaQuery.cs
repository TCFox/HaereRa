﻿using Microsoft.AspNetCore.Http;
using GraphQL.Types;
using HaereRa.API.GraphQL.Types;
using HaereRa.API.Services;

namespace HaereRa.API.GraphQL
{
    public class HaereRaQuery : ObjectGraphType
    {
        public HaereRaQuery(IHttpContextAccessor httpContextAccessor, IPersonService personService)
        {
            var user = httpContextAccessor.HttpContext.User;

            Field<PersonType>(
                "person",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                description: "A physical person in the organisation.",
                
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return personService.GetPersonAsync(id);
                    // return new Person { Id = 1, FullName = "John Smith", KnownAs = "John", IsAdmin = false };
                }
            );
        }
    }
}
