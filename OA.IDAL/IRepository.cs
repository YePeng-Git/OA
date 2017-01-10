
//使用TT模板生成代码的片段
using OA.Model;

namespace OA.IDAL
{

    //在这里需要一个for循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有的表对应的仓储显示出来了。
    public partial interface IOrg_OrganRepository : IBaseRepository<Org_Organ>
    {

    }

    public partial interface IOrg_OrganPersonRepository : IBaseRepository<Org_OrganPerson>
    {

    }

    public partial interface IOrg_PersonRepository : IBaseRepository<Org_Person>
    {

    }

    public partial interface ISys_AttachmentRepository : IBaseRepository<Sys_Attachment>
    {

    }

    public partial interface ISys_AttachmentConverRepository : IBaseRepository<Sys_AttachmentConver>
    {

    }

    public partial interface ISys_AttachmentSetRepository : IBaseRepository<Sys_AttachmentSet>
    {

    }

    public partial interface ISys_BillNoRepository : IBaseRepository<Sys_BillNo>
    {

    }

    public partial interface ISys_FunctionRepository : IBaseRepository<Sys_Function>
    {

    }

    public partial interface ISys_IdentityValuesRepository : IBaseRepository<Sys_IdentityValues>
    {

    }

    public partial interface ISys_LogRepository : IBaseRepository<Sys_Log>
    {

    }

    public partial interface ISys_MailRepository : IBaseRepository<Sys_Mail>
    {

    }

    public partial interface ISys_MenuRepository : IBaseRepository<Sys_Menu>
    {

    }

    public partial interface ISys_Menu_BakRepository : IBaseRepository<Sys_Menu_Bak>
    {

    }

    public partial interface ISys_ModuleRepository : IBaseRepository<Sys_Module>
    {

    }

    public partial interface ISys_RoleRepository : IBaseRepository<Sys_Role>
    {

    }

    public partial interface ISys_RoleFunctionRepository : IBaseRepository<Sys_RoleFunction>
    {

    }

    public partial interface ISys_SysInfoRepository : IBaseRepository<Sys_SysInfo>
    {

    }

    public partial interface ISys_UnitInfoRepository : IBaseRepository<Sys_UnitInfo>
    {

    }

    public partial interface ISys_UserRepository : IBaseRepository<Sys_User>
    {

    }

    public partial interface ISys_User_FunctionRepository : IBaseRepository<Sys_User_Function>
    {

    }

    public partial interface ISys_UserConfigRepository : IBaseRepository<Sys_UserConfig>
    {

    }

}