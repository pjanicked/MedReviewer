using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedReviewer.Core.InterfaceRepository;
using MedReviewer.Core.Models;

namespace MedReviewer.Core.Repository
{
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {
    }
}
