using Beautymakeup.Core.Core;
using Beautymakeup.Core.Entitys;
using Beautymakeup.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beautymakeup.Model.Services.RoleService
{
   public interface IRoleService : IBaseService
    {
        Task<ExecuteResult<Role>> Create(RoleViewModel viewModel);
        Task<ExecuteResult> Update(RoleViewModel viewModel);
        Task<ExecuteResult> Delete(RoleViewModel viewModel);
    }
}
