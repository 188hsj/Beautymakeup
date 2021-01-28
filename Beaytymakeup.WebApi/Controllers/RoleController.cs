using Beautymakeup.Core.Core;
using Beautymakeup.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beautymakeup.WebApi.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleController : BaseController
    {
        [HttpPost]
        public ExecuteResult Post(RoleViewModel viewModel)
        {
            return new ExecuteResult();
        }
    }
}
