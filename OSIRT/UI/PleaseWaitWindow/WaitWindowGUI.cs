/*
 * Created by SharpDevelop.
 * User: mjackson
 * Date: 05/03/2010
 * Time: 09:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Jacksonsoft
{
	/// <summary>
	/// The dialogue displayed by a WaitWindow instance.
	/// </summary>
	internal partial class WaitWindowGUI : Form
	{
		public WaitWindowGUI(WaitWindow parent){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			_Parent = parent;
			
			//	Position the window in the top right of the main screen.
			//this.Top = Screen.PrimaryScreen.WorkingArea.Top + 32;
			//this.Left = Screen.PrimaryScreen.WorkingArea.Right - this.Width - 32;
            //this.CenterToScreen();
            StartPosition = FormStartPosition.CenterScreen;
		}

		private WaitWindow _Parent;
		private delegate T FunctionInvoker<T>();
    	internal object _Result;
    	internal Exception _Error;
    	private IAsyncResult threadResult;
    	
		protected override void OnPaint(PaintEventArgs e){
			base.OnPaint(e);
			//	Paint a 3D border
			ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle.Raised);
		}

		protected override void OnShown(EventArgs e){
			base.OnShown(e);
						
			//   Create Delegate
			FunctionInvoker<object> threadController = new FunctionInvoker<object>(DoWork);

			//   Execute on secondary thread.
			threadResult = threadController.BeginInvoke(WorkComplete, threadController);
    	}
		
		internal object DoWork(){
			//	Invoke the worker method and return any results.
			WaitWindowEventArgs e = new WaitWindowEventArgs(_Parent, _Parent._Args);
			if ((_Parent._WorkerMethod != null)){
				_Parent._WorkerMethod(this, e);
			}
			return e.Result;
		}

    	private void WorkComplete(IAsyncResult results){
    		if (!IsDisposed){
	    		if (InvokeRequired){
	    			Invoke(new WaitWindow.MethodInvoker<IAsyncResult>(WorkComplete), results);
	    		} else {
	    			//	Capture the result
	    			try {
						_Result = ((FunctionInvoker<object>)results.AsyncState).EndInvoke(results);
	    			} catch (Exception ex) {
	    				//	Grab the Exception for rethrowing after the WaitWindow has closed.
						_Error = ex;
	    			}
					Close();
	    		}
    		}
    	}
		
		internal void SetMessage(string message){
			MessageLabel.Text = message;
		}
    	
    	internal void Cancel(){
    		Invoke(new MethodInvoker(Close), null);
    	}

        private void MessageLabel_Click(object sender, EventArgs e)
        {

        }

        private void WaitWindowGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
