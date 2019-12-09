using DesktopGameClient.Models;
using DesktopGameClient.ServiceAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopGameClient.Controllers {
    public class CGUserController {
        CGUserManagementServiceAccess cGUserManagementServiceAccess = new CGUserManagementServiceAccess();

        public List<CGUserModel> GetAll() {
            return cGUserManagementServiceAccess.GetAll();
        }

        public bool DeleteCGUser(CGUserModel user) {
            return cGUserManagementServiceAccess.DeleteCGUser(user);
        }

        public CGUserModel GetById(string userId) {
            return cGUserManagementServiceAccess.GetById(userId);
        }
    }
}
