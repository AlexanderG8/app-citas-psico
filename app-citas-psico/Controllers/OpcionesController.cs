using app_citas_psico.Data;
using app_citas_psico.Models;
using app_citas_psico.PatronRepository.IRepository;
using app_citas_psico.PatronRepository.Repository;
using Microsoft.AspNetCore.Mvc;

namespace app_citas_psico.Controllers
{
    public class OpcionesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OpcionesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetOpciones()
        {
            var opciones = await _unitOfWork.Opciones.GetAll();
            return Json(new { success = true, data = opciones });
        }

        public IActionResult GetOpcion()
        {
            var opcion = new OPCIONES();
            return PartialView(opcion);
        }

        public async Task<IActionResult> GetOpcionEdit(int id)
        {
            var opcion = new OPCIONES();
            if (id > 0)
            {
                opcion = await _unitOfWork.Opciones.GetID(id);
            }
            return PartialView(opcion);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOpcion(OPCIONES model)
        {
            var success = false;
            var message = string.Empty;
            try
            {
                if (model.ID_OPCION > 0)
                {
                    var opcion = await _unitOfWork.Opciones.GetID(model.ID_OPCION);
                    if (opcion != null)
                    {
                        opcion.OPCION = model.OPCION;
                        opcion.CONTROLLER = model.CONTROLLER;
                        opcion.ACCION = model.ACCION;
                        _unitOfWork.Opciones.Update(opcion);
                        success = true;
                        message = "Se actualizó exitosamente!";
                    }
                }
                else
                {
                    await _unitOfWork.Opciones.Save(model);
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
        public async Task<IActionResult> DeleteOpcion(int id)
        {
            var success = false;
            var message = string.Empty;
            try
            {
                if (id > 0)
                {
                    var opcion = await _unitOfWork.Opciones.GetID(id);
                    if (opcion != null)
                    {
                        _unitOfWork.Opciones.Remove(opcion);
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
