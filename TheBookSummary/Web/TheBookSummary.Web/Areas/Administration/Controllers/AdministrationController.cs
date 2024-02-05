namespace TheBookSummary.Web.Areas.Administration.Controllers
{
    using TheBookSummary.Common;
    using TheBookSummary.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}