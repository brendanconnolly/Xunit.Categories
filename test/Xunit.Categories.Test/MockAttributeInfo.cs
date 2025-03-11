using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Xunit.Categories.Test
{
    public class MockAttributeInfo: IAttributeInfo
    {
        private readonly string _identifier;

        public MockAttributeInfo()
        {
            _identifier = null;
        }

        public MockAttributeInfo(string identifier)
        {
            _identifier = identifier;
        }

        public IEnumerable<object> GetConstructorArguments()
        {
            return new object[]{"test"};
        }

        public IEnumerable<IAttributeInfo> GetCustomAttributes(string assemblyQualifiedAttributeTypeName)
        {
            return Array.Empty<IAttributeInfo>();
        }

        public TValue GetNamedArgument<TValue>(string argumentName)
        {
            return (TValue) Convert.ChangeType(_identifier, typeof(TValue));
        }
    }
}