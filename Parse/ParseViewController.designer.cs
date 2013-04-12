// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Parse
{
	[Register ("ParseViewController")]
	partial class ParseViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField txt { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txt != null) {
				txt.Dispose ();
				txt = null;
			}

			if (btn != null) {
				btn.Dispose ();
				btn = null;
			}
		}
	}
}
