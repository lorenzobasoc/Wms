using Wms.Api.DataAccess;
using Wms.Api.Infrastructure;

namespace Wms.Api.Repositories;

public class BaseRepo(AppConfiguration config, Db db) {
    protected readonly AppConfiguration _config = config;
    protected readonly Db _db = db;
}
