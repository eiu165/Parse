using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ParseTouch;

namespace Parse
{
	public partial class ParseViewController : UIViewController
	{
		public ParseViewController () : base ("ParseViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}



		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
 
			this.txt.ShouldReturn += (textField) => { 
				textField.ResignFirstResponder();
				return true; 
			}; 

			this.btn.TouchUpInside += (o,s) => { 
				var actionSheet = new UIActionSheet ("Send Post?", null, "Cancel", null, "Send"){
					Style = UIActionSheetStyle.Default
				};
				actionSheet.Clicked += ( sender,  args) => {
					Console.WriteLine ("Clicked on item {0}  text: {1}", args.ButtonIndex, this.txt.Text);
					if (args.ButtonIndex == 0)
					{
						MakePost(this.txt.Text);
					}
				};
				
				actionSheet.ShowInView (View);
			}; 




			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}


		
		void MakePost (string body)
		{
			var post = new ParseObject ("Post");
			post ["title"] = new NSString ("I love Parse with Xamarin");
			post ["body"] = new NSString (body);
			post.SaveAsync ((success, error) => {
				var alert = new UIAlertView("Parse", "just pushed to parse", null, "cancel", "ok");
				alert.Show(); 
			});
		}


	}
}

