//引进TT模板的命名空间

//使用TT模板生成代码的片段
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Model;

namespace OA.IBLL
{

    //在这里需要一个for循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有的表对应的仓储显示出来了。
    public partial interface IOrg_OrganService : IBaseService<Org_Organ>
    {
    }
    public partial interface IOrg_OrganPersonService : IBaseService<Org_OrganPerson>
    {
    }
    public partial interface IOrg_PersonService : IBaseService<Org_Person>
    {
    }
    public partial interface ISys_AttachmentService : IBaseService<Sys_Attachment>
    {
    }
    public partial interface ISys_AttachmentConverService : IBaseService<Sys_AttachmentConver>
    {
    }
    public partial interface ISys_AttachmentSetService : IBaseService<Sys_AttachmentSet>
    {
    }
    public partial interface ISys_BillNoService : IBaseService<Sys_BillNo>
    {
    }
    public partial interface ISys_FunctionService : IBaseService<Sys_Function>
    {
    }
    public partial interface ISys_IdentityValuesService : IBaseService<Sys_IdentityValues>
    {
    }
    public partial interface ISys_LogService : IBaseService<Sys_Log>
    {
    }
    public partial interface ISys_MailService : IBaseService<Sys_Mail>
    {
    }
    public partial interface ISys_MenuService : IBaseService<Sys_Menu>
    {
    }
    public partial interface ISys_Menu_BakService : IBaseService<Sys_Menu_Bak>
    {
    }
    public partial interface ISys_ModuleService : IBaseService<Sys_Module>
    {
    }
    public partial interface ISys_RoleService : IBaseService<Sys_Role>
    {
    }
    public partial interface ISys_RoleFunctionService : IBaseService<Sys_RoleFunction>
    {
    }
    public partial interface ISys_SysInfoService : IBaseService<Sys_SysInfo>
    {
    }
    public partial interface ISys_UnitInfoService : IBaseService<Sys_UnitInfo>
    {
    }
    public partial interface ISys_UserService : IBaseService<Sys_User>
    {
    }
    public partial interface ISys_User_FunctionService : IBaseService<Sys_User_Function>
    {
    }
    public partial interface ISys_UserConfigService : IBaseService<Sys_UserConfig>
    {
    }
}