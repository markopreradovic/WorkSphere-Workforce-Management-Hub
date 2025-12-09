using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations;

public class EmployeeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Employee>
{
    public async Task<GeneralResponse> DeleteById(int id)
    {
        var item = await appDbContext.Employees.FindAsync(id);
        if (item is null) return NotFound();

        appDbContext.Employees.Remove(item);
        return await Commit().ContinueWith(_ => Success());
    }

    public async Task<List<Employee>> GetAll() => await appDbContext.Employees
        .AsNoTracking()
        .Include(t => t.Town)
        .ThenInclude(b => b!.City)
        .ThenInclude(c => c!.Country)
        .Include(d => d.Branch)
        .ThenInclude(g => g!.Department)
        .ThenInclude(gd => gd!.GeneralDepartment)
        .ToListAsync();

    public async Task<Employee> GetById(int id)
    {
        var entity = await appDbContext.Employees
            .Include(t => t.Town)
            .ThenInclude(b => b!.City)
            .ThenInclude(c => c!.Country)
            .Include(d => d.Branch)
            .ThenInclude(g => g!.Department)
            .ThenInclude(gd => gd!.GeneralDepartment)
            .FirstOrDefaultAsync(ei => ei.Id == id);
        return entity is null ? throw new InvalidOperationException($"Employee with ID {id} not found.") : entity;
    }

    public async Task<GeneralResponse> Insert(Employee item)
    {
        if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Employee already added");
        appDbContext.Employees.Add(item);
        return await Commit().ContinueWith(_ => Success());
    }



    public async Task<GeneralResponse> Update(Employee employee)
    {
        var findUser = await appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
        if (findUser is null) return new GeneralResponse(false, "Employee does not exist");

        findUser.Name = employee.Name;
        findUser.Other = employee.Other;
        findUser.Address = employee.Address;
        findUser.TelephoneNumber = employee.TelephoneNumber;
        findUser.BranchId = employee.BranchId;
        findUser.TownId = employee.TownId;
        findUser.CivilId = employee.CivilId;
        findUser.JobName = employee.JobName;
        findUser.Photo = employee.Photo;
        await appDbContext.SaveChangesAsync();
        await Commit();
        return Success();
    }
    private async Task Commit() => await appDbContext.SaveChangesAsync();
    private static GeneralResponse NotFound() => new(false, "Sorry Employee not fount");
    private static GeneralResponse Success() => new(true, "Process completed");

    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Employees.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        return item is null;
    }

}