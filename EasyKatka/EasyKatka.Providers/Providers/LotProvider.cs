using EasyKatka.Providers.AppContext;

namespace EasyKatka.Providers.Providers
{
    public class LotProvider
    {
        private ApplicationContext _context;

        public LotProvider()
        {
            _context = new ApplicationContext();
        }
    }
}
