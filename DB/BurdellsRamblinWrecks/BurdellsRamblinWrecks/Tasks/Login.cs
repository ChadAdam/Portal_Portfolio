using BurdellsRamblinWrecks.Entities;
using BurdellsRamblinWrecks.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Tasks
{
    public class Login
    {        
        public static Login SingletonInstance = new Login();
        protected Login() { }

        public bool IsUserAuthenticated { get; protected set; }
        public PriviledgedUser CurrentUser { get; protected set; } = defaultUser();
        public UserRolesEnum CurrentUserRoles { get; protected set; }

        public static Login GetLoginTask()
        {
            return SingletonInstance;
        }

        public bool LoginUser(string username, string password)
        {
            QueryExecutor dataAccess = new QueryExecutor();
            PriviledgedUser user = dataAccess.AuthenticateUser(username, password);

            if (user != null)
            {
                IsUserAuthenticated = true;
                CurrentUser = new PriviledgedUser() { username = username, first_name = user.first_name, last_name = user.last_name };
                CurrentUserRoles = GetUserRoles();
                return true;
            }
            else
            {
                LogoutUser();                
                return false;
            }            
        }

        public void LogoutUser()
        {
            IsUserAuthenticated = false;
            CurrentUserRoles = UserRolesEnum.PublicOnly;
            CurrentUser = defaultUser();          
        }

        public UserRolesEnum GetUserRoles()
        {
            if (IsUserAuthenticated)
            {
                QueryExecutor dataAccess = new QueryExecutor();
                UserRolesEnum assignedRoles = dataAccess.QueryUserRoles(this.CurrentUser.username);
                return assignedRoles;
            }
            else
            {
                return UserRolesEnum.PublicOnly;
            }
        }

        protected static PriviledgedUser defaultUser()
        {
            return new PriviledgedUser() { username = null, first_name = "Public", last_name = "(Not Logged In)" };
        }
    }
}
