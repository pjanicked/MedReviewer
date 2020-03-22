using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedReviewer.Core.Helpers;
using MedReviewer.Core.Models;
using MedReviewer.Core.Repository;

namespace MedReviewer.Core.Operation
{
    public class AccountOperation
    {
        private readonly AccountRepository _accountRepository;

        public AccountOperation()
        {
            _accountRepository = new AccountRepository();
        }

        public User CreateUser()
        {
            try
            {
                if (!_accountRepository.CheckDuplicate(x => x.OktaUserId == HelperClass.UserSession.OktaUserId))
                {
                    var user = new User
                    {
                        OktaUserId = HelperClass.UserSession.OktaUserId,
                        OktaUserName = HelperClass.UserSession.UserName,
                        UserEmail = HelperClass.UserSession.UserEmail,
                        UserCreatedDate = DateTime.Now
                    };

                    var isUserAdded = _accountRepository.Add(user);
                    if (isUserAdded != null)
                    {
                        return isUserAdded;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                    //throw new Exception("User already created!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
