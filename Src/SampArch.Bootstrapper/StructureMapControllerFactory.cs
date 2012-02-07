using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using System.Web.Mvc;
using System.Web.Routing;

namespace SampArch.Bootstrapper
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        private readonly Container _container;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="container">StructureMap container.</param>
        public StructureMapControllerFactory(Container container)
        {
            if (container == null)
                throw new ArgumentNullException("container", "The structureMap container cannot be null.");

            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                var controller = (Controller)_container.GetInstance(controllerType);
                return controller;
            }
            return null;
        }
    }


}
