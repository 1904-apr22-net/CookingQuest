using CookingQuest.Library.Models.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingQuest.Library.IRepository
{
    public interface IEquipmentRepo : IDisposable
    {
        Task<IEnumerable<EquipmentModel>> GetAllEquipment();
        Task<EquipmentModel> GetEquipmentById(int PlayerId);
        Task<int> AddEquipment(EquipmentModel equipmentModel);
        Task<bool> EditEquipment(EquipmentModel equipmentModel);
        Task<bool> DeleteEquipment(int equipmentId);
        void Save();
    }
}
