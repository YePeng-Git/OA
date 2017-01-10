//使用TT模板生成代码的片段
using OA.IDAL;
using OA.Model;

namespace OA.DAL
{
    //在这里需要一个for循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有的表对应的仓储显示出来了。
    public partial class Org_OrganRepository : BaseRepository<Org_Organ>, IOrg_OrganRepository
    {

    }

    public partial class Org_OrganPersonRepository : BaseRepository<Org_OrganPerson>, IOrg_OrganPersonRepository
    {

    }

    public partial class Org_PersonRepository : BaseRepository<Org_Person>, IOrg_PersonRepository
    {

    }

    public partial class Sys_AttachmentRepository : BaseRepository<Sys_Attachment>, ISys_AttachmentRepository
    {

    }

    public partial class Sys_AttachmentConverRepository : BaseRepository<Sys_AttachmentConver>, ISys_AttachmentConverRepository
    {

    }

    public partial class Sys_AttachmentSetRepository : BaseRepository<Sys_AttachmentSet>, ISys_AttachmentSetRepository
    {

    }

    public partial class Sys_BillNoRepository : BaseRepository<Sys_BillNo>, ISys_BillNoRepository
    {

    }

    public partial class Sys_FunctionRepository : BaseRepository<Sys_Function>, ISys_FunctionRepository
    {

    }

    public partial class Sys_IdentityValuesRepository : BaseRepository<Sys_IdentityValues>, ISys_IdentityValuesRepository
    {

    }

    public partial class Sys_LogRepository : BaseRepository<Sys_Log>, ISys_LogRepository
    {

    }

    public partial class Sys_MailRepository : BaseRepository<Sys_Mail>, ISys_MailRepository
    {

    }

    public partial class Sys_MenuRepository : BaseRepository<Sys_Menu>, ISys_MenuRepository
    {

    }

    public partial class Sys_Menu_BakRepository : BaseRepository<Sys_Menu_Bak>, ISys_Menu_BakRepository
    {

    }

    public partial class Sys_ModuleRepository : BaseRepository<Sys_Module>, ISys_ModuleRepository
    {

    }

    public partial class Sys_RoleRepository : BaseRepository<Sys_Role>, ISys_RoleRepository
    {

    }

    public partial class Sys_RoleFunctionRepository : BaseRepository<Sys_RoleFunction>, ISys_RoleFunctionRepository
    {

    }

    public partial class Sys_SysInfoRepository : BaseRepository<Sys_SysInfo>, ISys_SysInfoRepository
    {

    }

    public partial class Sys_UnitInfoRepository : BaseRepository<Sys_UnitInfo>, ISys_UnitInfoRepository
    {

    }

    public partial class Sys_UserRepository : BaseRepository<Sys_User>, ISys_UserRepository
    {

    }

    public partial class Sys_User_FunctionRepository : BaseRepository<Sys_User_Function>, ISys_User_FunctionRepository
    {

    }

    public partial class Sys_UserConfigRepository : BaseRepository<Sys_UserConfig>, ISys_UserConfigRepository
    {

    }

}