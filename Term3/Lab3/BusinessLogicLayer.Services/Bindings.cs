using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Serialization;
using BusinessLogicLayer.Entities;

namespace BusinessLogicLayer.Services
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(ISerializer<>)).To(typeof(XmlSerializer<>));
        }
    }
}
