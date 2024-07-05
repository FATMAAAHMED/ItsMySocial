using ItsMySocialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILikeRepository
    {
        Task AddLikeAsync(Like like);
        Task RemoveLikeAsync(long PostId, long UserId);
    }
}
