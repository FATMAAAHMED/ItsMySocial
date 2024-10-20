using ItsMySocialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IShareRepository
    {
        Task sharepost(long postId,long userId);
    }
}
