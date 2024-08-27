using Wms.Api.DataAccess;
using Wms.Api.Extensions;
using Wms.Api.Infrastructure;

namespace Wms.Api.Repositories;

public class TableRepo(AppConfiguration config, Db db) : BaseRepo(config, db)
{
    public async Task Create(Table table) {
        if (table.Photo != null) {
            _db.AppFiles.Add(table.Photo);
        }
        _db.Tables.Add(table);
        await _db.SaveChangesAsync();
    }

    public async Task<Table> GetTable(Guid tableId) {
        var table = await _db.Tables
            .Include(t => t.Seats)
            .SingleOrThrowAsync(t => t.Id == tableId);
        return table;
    }

    public async Task Delete(Table table) {
        _db.Tables.Remove(table);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Table table) {
        _db.Tables.Update(table);
        await _db.SaveChangesAsync();
    }
}
