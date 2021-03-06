﻿using BEQLDB.ServiceModel;
using ServiceStack;

namespace BEQLDB.ServiceInterface
{
    public class MyServices : ServiceStack.Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}