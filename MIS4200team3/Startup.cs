﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIS4200team3.Startup))]
namespace MIS4200team3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
