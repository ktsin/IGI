using Microsoft.Extensions.DependencyInjection;

namespace WpfApp
{
    public static class ServicesHolder
    {
        private static ServiceCollection _collection = null;

        private static ServiceProvider _provider = null;

        public static ServiceCollection Collection
        {
            get
            {
                if (_collection == null)
                {
                    _collection = new ServiceCollection();
                    return _collection;
                }
                else
                    return _collection;
            }
        }

        public static ServiceProvider Provider
        {
            get => _provider;
            set => _provider = value;
        }


    }
}
