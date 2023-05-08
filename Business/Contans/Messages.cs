using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contans
{
    public class Messages
    {
        public static string AddedSuccess { get; internal set; }
        public static string DeletedSuccess { get; internal set; }
        public static string UpdatedSuccess { get; internal set; }
        public static string AccesTokenCreated { get; internal set; }
        public static string UserNotFound { get; internal set; }
        public static string UserSuccesfulLogin { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string UserRegistered { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static string OperationClaimAdded { get; internal set; }
        public static string OperationClaimDeleted { get; internal set; }
        public static string OperationClaimUpdated { get; internal set; }
        public static string UserOperationClaimAdded { get; internal set; }
        public static string UserOperationClaimAdd { get; internal set; }
        public static string UserOperationClaimUpdated { get; internal set; }
    }
}
