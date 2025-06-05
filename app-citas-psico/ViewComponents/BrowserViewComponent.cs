using app_citas_psico.PatronRepository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace app_citas_psico.ViewComponents
{
    public class BrowserViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrowserViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var user = User.Identity.Name;
            var user = "70994785";
            var listOptions = await _unitOfWork.Opciones.GetOpcionesUser(user);
            return View(listOptions);
        }
    }
}
