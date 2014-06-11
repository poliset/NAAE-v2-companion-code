﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public abstract class Saga
    {
        public Guid Id { get; protected set; }

        public IBus Bus { get; private set; }

        public Saga(IBus bus)
        {
            if (bus == null)
            {
                throw new ArgumentNullException("bus");
            }
            Bus = bus;
        }

        protected abstract void ConfigureSagaMappings();

        protected void ConfigureMapping<TMessage>(Expression<Func<TMessage, object>> messageProperty)
        {

        }
    }
}