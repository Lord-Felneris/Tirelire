using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tirelire.Utility
{
    public class SD
    {
        //static detail role
        public const string Role_Client = "Client";
        public const string Role_Admin = "Admin";
        public const string Role_Moderateur = "Mod";
        public const string Role_Assistant = "Assistant";

        //static detail payment
        public const string PaymentStatusPending = "En attente";
        public const string PaymentStatusApproved = "Accepte";
        public const string PaymentStatusDelayPayment = "Accepte Payment avec delais";
        public const string PaymentStatusRejected = "Rejecté";

        //static detail commande
        public const string StatusPending = "En attente";
        public const string StatusInProcess = "En preparation";
        public const string StatusShipped = "Expedié";
        public const string StatusDeliver = "Livré";
        public const string StatusCancel = "Annulé";
    }
}
