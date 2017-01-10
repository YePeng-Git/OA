using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.IDAL;

namespace OA.DAL
{
    //一次跟数据库交互的会话
    public partial class DbSession : IDbSession //代表应用程序跟数据库之间的一次会话，也是数据库访问层的统一入口
    {

        //在这里需要一个for循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有的表对应的仓储显示出来了。
        public IDAL.IOrg_OrganRepository Org_OrganRepository
        {
            get { return new Org_OrganRepository(); }
        }
        public IDAL.IOrg_OrganPersonRepository Org_OrganPersonRepository
        {
            get { return new Org_OrganPersonRepository(); }
        }
        public IDAL.IOrg_PersonRepository Org_PersonRepository
        {
            get { return new Org_PersonRepository(); }
        }
        public IDAL.ISys_AttachmentRepository Sys_AttachmentRepository
        {
            get { return new Sys_AttachmentRepository(); }
        }
        public IDAL.ISys_AttachmentConverRepository Sys_AttachmentConverRepository
        {
            get { return new Sys_AttachmentConverRepository(); }
        }
        public IDAL.ISys_AttachmentSetRepository Sys_AttachmentSetRepository
        {
            get { return new Sys_AttachmentSetRepository(); }
        }
        public IDAL.ISys_BillNoRepository Sys_BillNoRepository
        {
            get { return new Sys_BillNoRepository(); }
        }
        public IDAL.ISys_FunctionRepository Sys_FunctionRepository
        {
            get { return new Sys_FunctionRepository(); }
        }
        public IDAL.ISys_IdentityValuesRepository Sys_IdentityValuesRepository
        {
            get { return new Sys_IdentityValuesRepository(); }
        }
        public IDAL.ISys_LogRepository Sys_LogRepository
        {
            get { return new Sys_LogRepository(); }
        }
        public IDAL.ISys_MailRepository Sys_MailRepository
        {
            get { return new Sys_MailRepository(); }
        }
        public IDAL.ISys_MenuRepository Sys_MenuRepository
        {
            get { return new Sys_MenuRepository(); }
        }
        public IDAL.ISys_Menu_BakRepository Sys_Menu_BakRepository
        {
            get { return new Sys_Menu_BakRepository(); }
        }
        public IDAL.ISys_ModuleRepository Sys_ModuleRepository
        {
            get { return new Sys_ModuleRepository(); }
        }
        public IDAL.ISys_RoleRepository Sys_RoleRepository
        {
            get { return new Sys_RoleRepository(); }
        }
        public IDAL.ISys_RoleFunctionRepository Sys_RoleFunctionRepository
        {
            get { return new Sys_RoleFunctionRepository(); }
        }
        public IDAL.ISys_SysInfoRepository Sys_SysInfoRepository
        {
            get { return new Sys_SysInfoRepository(); }
        }
        public IDAL.ISys_UnitInfoRepository Sys_UnitInfoRepository
        {
            get { return new Sys_UnitInfoRepository(); }
        }
        public IDAL.ISys_UserRepository Sys_UserRepository
        {
            get { return new Sys_UserRepository(); }
        }
        public IDAL.ISys_User_FunctionRepository Sys_User_FunctionRepository
        {
            get { return new Sys_User_FunctionRepository(); }
        }
        public IDAL.ISys_UserConfigRepository Sys_UserConfigRepository
        {
            get { return new Sys_UserConfigRepository(); }
        }
    }
}