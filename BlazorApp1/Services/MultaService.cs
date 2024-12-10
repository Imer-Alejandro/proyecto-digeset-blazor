using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MultaService
{
    private readonly AppDbContext _context;

    public MultaService(AppDbContext context)
    {
        _context = context;
    }

    
    // Método para iniciar sesión
    public async Task<Agente?> LoginAsync(string cedula, string clave)
    {
        return await _context.Agentes
            .FirstOrDefaultAsync(u => u.Cedula == cedula && u.Clave == clave);
    }

    // Método para registrar un nuevo usuario
    public async Task<bool> RegistrarUsuarioAsync(Agente nuevoAgente)
    {
        try
        {
            await _context.Agentes.AddAsync(nuevoAgente);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    // Registrar una nueva multa
    public async Task<bool> RegistrarMultaAsync(Multa nuevaMulta)
    {
        try
        {
            await _context.Multas.AddAsync(nuevaMulta);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    // Obtener todas las multas de un agente por su ID
    public async Task<List<Multa>> ObtenerMultasPorAgenteAsync(int agenteId)
    {
        return await _context.Multas
            .Where(m => m.AgenteId == agenteId)
            .OrderByDescending(m => m.Fecha)
            .ToListAsync();
    }

    // Obtener las multas de las últimas 4 semanas de un agente
    public async Task<List<Multa>> ObtenerMultasUltimas4SemanasAsync(int agenteId)
    {
        var fechaLimite = DateTime.Now.AddDays(-28);
        return await _context.Multas
            .Where(m => m.AgenteId == agenteId && m.Fecha >= fechaLimite)
            .ToListAsync();
    }

    // Calcular comisión por multas activas de un agente
    public async Task<decimal> CalcularComisionMensualAsync(int agenteId)
        {
            // Filtrar las multas cuyo estado 'Pagada' es false
            var multasNoPagadas = await _context.Multas
                .Where(m => m.AgenteId == agenteId && !m.Pagada)
                .ToListAsync();

            // Calcular el total de la comisión (10% del monto total de las multas no pagadas)
            return multasNoPagadas.Sum(m => m.Monto) * 0.1m; // Usar Monto directamente
        }
}