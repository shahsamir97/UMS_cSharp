using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivarsityManagementSystem
{
    partial class UserInfo
    {
        public string EMAIL
        {
            get
            {
                return this.TeacherTable.EMAIL;
            }
            set
            {
                this.TeacherTable.EMAIL = value;
            }
        }
    }
}
