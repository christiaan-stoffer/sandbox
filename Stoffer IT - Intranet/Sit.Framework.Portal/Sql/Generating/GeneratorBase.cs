using System;

namespace Sit.Framework.Portal.Sql.Generating
{
    public abstract class GeneratorBase
    {
        public Type TypeForGenerating
        {
            get; private set;
        }

        protected GeneratorBase(Type typeForGenerating)
        {
            TypeForGenerating = typeForGenerating;
        }
    }
}