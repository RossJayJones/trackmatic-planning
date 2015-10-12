using System;

namespace Trackmatic.Planning.Framework
{
    public class ReadonlyMixin
    {
        private readonly bool _isReadonly;

        public ReadonlyMixin(bool isReadonly)
        {
            _isReadonly = isReadonly;
        }

        public void Guard()
        {
            if (!_isReadonly)
            {
                return;
            }

            throw new InvalidOperationException("The object is currently read only");
        }
    }
}
