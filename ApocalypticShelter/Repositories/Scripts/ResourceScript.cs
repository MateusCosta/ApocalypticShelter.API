using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.Repositories.Scripts
{
    public static class ResourceScript
    {
        public static string Get => @"SELECT resourceid as ID, resourcename as Name, description, quantity, observation, perishable, shelflife, enabled FROM public.resources WHERE resourceid = @ID ";
        public static string All => @"SELECT resourceid as ID, resourcename as Name, description, quantity, observation, perishable, shelflife, enabled FROM public.resources";
    }
}
