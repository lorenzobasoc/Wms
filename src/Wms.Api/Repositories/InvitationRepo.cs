using Wms.Api.DataAccess;
using Wms.Api.Extensions;
using Wms.Api.Infrastructure;

namespace Wms.Api.Repositories;

public class InvitationRepo(AppConfiguration config, Db db) : BaseRepo(config, db)
{
    public async Task<List<Invitation>> List(Guid userId) {
        var invitations = await _db.Invitations
            .Where(i => i.ToUserId == userId)
            .ToListAsync();
        return invitations;
    }

    public async Task<Invitation> Find(Guid id) {
        var invitation = await _db.Invitations.SingleOrDefaultAsync(r => r.Id == id);
        return invitation;
    }

    public async Task Create(Invitation invitation) {
        _db.Invitations.Add(invitation);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Invitation invitation) {
        _db.Invitations.Update(invitation);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Invitation invitation) {
        _db.Invitations.Remove(invitation);
        await _db.SaveChangesAsync();
    }
}
