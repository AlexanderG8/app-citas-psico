using app_citas_psico.Models;
using app_citas_psico.PatronRepository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace app_citas_psico.Controllers
{
    public class RolController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _unitOfWork.Rol.GetAll();
            return Json(new { success = true, data = roles });
        }

        public IActionResult GetRol()
        {
            var rol = new ROL();
            return PartialView(rol);
        }

        public async Task<IActionResult> GetRolEdit(int id)
        {
            var rol = new ROL();
            if (id > 0)
            {
                rol = await _unitOfWork.Rol.GetID(id);
            }
            return PartialView(rol);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRol(ROL model)
        {
            var success = false;
            var message = string.Empty;
            try
            {
                if (model.ID_ROL > 0)
                {
                    var rol = await _unitOfWork.Rol.GetID(model.ID_ROL);
                    if (rol != null)
                    {
                        rol.NOMBRE_ROL = model.NOMBRE_ROL;
                        _unitOfWork.Rol.Update(rol);
                        success = true;
                        message = "Se actualizó exitosamente!";
                    }
                }
                else
                {
                    await _unitOfWork.Rol.Save(model);
                    await _unitOfWork.SaveAsync();
                    success = true;
                    message = "Se agregó exitosamente!";
                }
            }
            catch (Exception ex)
            {
                success = false;
                message = $"Error al guardar la opción: {ex.Message}";
            }
            return Json(new { success = success, message = message });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var success = false;
            var message = string.Empty;
            try
            {
                if (id > 0)
                {
                    var rol = await _unitOfWork.Rol.GetID(id);
                    if (rol != null)
                    {
                        _unitOfWork.Rol.Remove(rol);
                        await _unitOfWork.SaveAsync();
                        success = true;
                        message = "Se eliminó exitosamente!";
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                message = $"Error al eliminar la opción: {ex.Message}";
            }
            return Json(new { success = success, message = message });
        }
    }
}
