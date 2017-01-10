
//使用TT模板生成代码的片段
using System.Text;
using System.Threading.Tasks;
using OA.DAL;
using OA.IBLL;
using OA.IDAL;
using OA.Model;

namespace OA.BLL
{

    //在这里需要一个for循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有的表对应的仓储显示出来了。
    public partial class Org_OrganService : BaseService<Org_Organ>, IOrg_OrganService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Org_OrganRepository;
        }
    }
    public partial class Org_OrganPersonService : BaseService<Org_OrganPerson>, IOrg_OrganPersonService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Org_OrganPersonRepository;
        }
    }
    public partial class Org_PersonService : BaseService<Org_Person>, IOrg_PersonService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Org_PersonRepository;
        }
    }
    public partial class Sys_AttachmentService : BaseService<Sys_Attachment>, ISys_AttachmentService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_AttachmentRepository;
        }
    }
    public partial class Sys_AttachmentConverService : BaseService<Sys_AttachmentConver>, ISys_AttachmentConverService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_AttachmentConverRepository;
        }
    }
    public partial class Sys_AttachmentSetService : BaseService<Sys_AttachmentSet>, ISys_AttachmentSetService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_AttachmentSetRepository;
        }
    }
    public partial class Sys_BillNoService : BaseService<Sys_BillNo>, ISys_BillNoService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_BillNoRepository;
        }
    }
    public partial class Sys_FunctionService : BaseService<Sys_Function>, ISys_FunctionService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_FunctionRepository;
        }
    }
    public partial class Sys_IdentityValuesService : BaseService<Sys_IdentityValues>, ISys_IdentityValuesService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_IdentityValuesRepository;
        }
    }
    public partial class Sys_LogService : BaseService<Sys_Log>, ISys_LogService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_LogRepository;
        }
    }
    public partial class Sys_MailService : BaseService<Sys_Mail>, ISys_MailService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_MailRepository;
        }
    }
    public partial class Sys_MenuService : BaseService<Sys_Menu>, ISys_MenuService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_MenuRepository;
        }
    }
    public partial class Sys_Menu_BakService : BaseService<Sys_Menu_Bak>, ISys_Menu_BakService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_Menu_BakRepository;
        }
    }
    public partial class Sys_ModuleService : BaseService<Sys_Module>, ISys_ModuleService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_ModuleRepository;
        }
    }
    public partial class Sys_RoleService : BaseService<Sys_Role>, ISys_RoleService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_RoleRepository;
        }
    }
    public partial class Sys_RoleFunctionService : BaseService<Sys_RoleFunction>, ISys_RoleFunctionService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_RoleFunctionRepository;
        }
    }
    public partial class Sys_SysInfoService : BaseService<Sys_SysInfo>, ISys_SysInfoService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_SysInfoRepository;
        }
    }
    public partial class Sys_UnitInfoService : BaseService<Sys_UnitInfo>, ISys_UnitInfoService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_UnitInfoRepository;
        }
    }
    public partial class Sys_UserService : BaseService<Sys_User>, ISys_UserService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_UserRepository;
        }
    }
    public partial class Sys_User_FunctionService : BaseService<Sys_User_Function>, ISys_User_FunctionService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_User_FunctionRepository;
        }
    }
    public partial class Sys_UserConfigService : BaseService<Sys_UserConfig>, ISys_UserConfigService
    {
        //只要想操作数据库，我们只要拿到DbSession就行
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.Sys_UserConfigRepository;
        }
    }
}