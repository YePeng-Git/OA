

//使用TT模板生成代码的片段
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL
{
    public partial interface IDbSession
    {

        //在这里需要一个for循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有的表对应的仓储显示出来了。
        //每个表对应的实体仓储对象
        IDAL.IOrg_OrganRepository Org_OrganRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.IOrg_OrganPersonRepository Org_OrganPersonRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.IOrg_PersonRepository Org_PersonRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_AttachmentRepository Sys_AttachmentRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_AttachmentConverRepository Sys_AttachmentConverRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_AttachmentSetRepository Sys_AttachmentSetRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_BillNoRepository Sys_BillNoRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_FunctionRepository Sys_FunctionRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_IdentityValuesRepository Sys_IdentityValuesRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_LogRepository Sys_LogRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_MailRepository Sys_MailRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_MenuRepository Sys_MenuRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_Menu_BakRepository Sys_Menu_BakRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_ModuleRepository Sys_ModuleRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_RoleRepository Sys_RoleRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_RoleFunctionRepository Sys_RoleFunctionRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_SysInfoRepository Sys_SysInfoRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_UnitInfoRepository Sys_UnitInfoRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_UserRepository Sys_UserRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_User_FunctionRepository Sys_User_FunctionRepository { get; }

        //每个表对应的实体仓储对象
        IDAL.ISys_UserConfigRepository Sys_UserConfigRepository { get; }

    }
}