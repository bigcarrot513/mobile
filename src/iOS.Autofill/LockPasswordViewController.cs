using System;
using UIKit;

namespace Bit.iOS.Autofill
{
    public partial class LockPasswordViewController : Core.Controllers.LockPasswordViewController
    {
        public LockPasswordViewController(IntPtr handle)
            : base(handle)
        {
            BiometricIntegrityKey = "autofillBiometricState";
            DismissModalAction = Cancel;
        }

        public CredentialProviderViewController CPViewController { get; set; }
        public override UINavigationItem BaseNavItem => NavItem;
        public override UIBarButtonItem BaseCancelButton => CancelButton;
        public override UIBarButtonItem BaseSubmitButton => SubmitButton;
        public override Action Success => () => CPViewController.DismissLockAndContinue();
        public override Action Cancel => () => CPViewController.CompleteRequest();

        partial void SubmitButton_Activated(UIBarButtonItem sender)
        {
            var task = CheckPasswordAsync();
        }

        partial void CancelButton_Activated(UIBarButtonItem sender)
        {
            Cancel();
        }
    }
}
