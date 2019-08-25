﻿using AutoMapper.Configuration;
using Sinemapp.Admin.Models;
using Sinemapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinemapp.Admin
{
    public class AutoMapperConfig
    {
       public void Initialize()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AllowNullCollections = true;
            cfg.AllowNullDestinationValues = true;

        
        }
    }
}