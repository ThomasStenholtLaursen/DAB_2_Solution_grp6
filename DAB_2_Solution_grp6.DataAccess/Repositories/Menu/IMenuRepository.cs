﻿namespace DAB_2_Solution_grp6.DataAccess.Repositories.Menu
{
    public interface IMenuRepository
    {
        Task<Entities.Menu> GetMenuByIdAsync(Guid id);
    }
}
