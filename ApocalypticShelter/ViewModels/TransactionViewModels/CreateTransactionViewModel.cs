using ApocalypticShelter.Enums;
using System;
using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApocalypticShelter.ViewModels.TransactionViewModels
{
    public class CreateTransactionViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public TransactionEnums.Type Type { get; set; }
        public int ResourceId { get; set; }
        public int ShelterId { get; set; }
        public int SurvivorId { get; set; }
        public int QuantityMoved { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .IsGreaterThan(QuantityMoved,0, "QuantityMoved", "A quantidade movimentada deve ser maior que 0")
                    .IsGreaterThan(ResourceId, 0, "ResourceId", "Insira um produto valido")
                    .IsGreaterThan(ShelterId, 0, "ShelterId", "Insira um abrigo valido")
                    .IsGreaterThan(SurvivorId, 0, "SurvivorId", "Insira um usuario valido")

                );;
        }
    }
}
