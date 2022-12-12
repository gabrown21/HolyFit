using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyFitLibrary.DataAccess
{
    public class MongoDayModel
    {
        private readonly IMongoCollection<DayModel> _days;
        private readonly IMemoryCache _cache;
        private const string cacheName = "DayData";

        public MongoDayModel(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
           _days = db.DayCollection;
        }

        public async Task<List<DayModel>> GetAllDays()
        {
            var output = _cache.Get<List<DayModel>>(cacheName);
            if(output is null)
            {
                var results = await _categories.FindAsync(_ => true);
                output = results.ToList();

                _cache.Set(cacheName, output, TimeSpan.FromDays(1));
            }

            return output;
        }
    }
}
