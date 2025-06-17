namespace Aplicacion.UseCases.UseCasesPersona;

public class ValidarUsuarioYContraseña(IRepositorioPersona repositorio) : PersonaUseCase(repositorio)
{

    public int Ejecutar(String nombre, Srting apellido, String contraseña)
    {
        return repositorio.ValidarUserYPass(nombre, apellido, contraseña);
        
    }

}