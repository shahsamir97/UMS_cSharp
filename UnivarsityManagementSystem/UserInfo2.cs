﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivarsityManagementSystem
{
    partial class UserInfo
    {
       
        public string student_email
        {
            get
            {
                return this.student.email;
            }
            set
            {
                this.student.email = value;
            }
        }

        public string internationalstudent
        {
            get
            {
                return this.student.int_stu;
            }
        }

        

    }
}
