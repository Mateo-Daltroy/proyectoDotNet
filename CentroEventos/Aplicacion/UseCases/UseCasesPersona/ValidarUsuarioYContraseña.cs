using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ValidarUsuarioYContraseña(IRepositorioPersona repositorio) : PersonaUseCase(repositorio)
{

    public int Ejecutar(String mail, String contraseña)
    {
        return repositorio.ValidarUserYPass(mail, contraseña);

    }

}