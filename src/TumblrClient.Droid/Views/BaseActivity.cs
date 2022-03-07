using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;

namespace TumblrClient.Droid.Views
{
    public abstract class BaseActivity<TViewModel> : MvxActivity<TViewModel>
        where TViewModel : class, IMvxViewModel
    {
        protected abstract int ActivityLayoutId { get; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(ActivityLayoutId);
        }

        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            if(ev.Action == MotionEventActions.Down)
            {
                var view = CurrentFocus;

                if(view is EditText)
                {
                    var outRect = new Rect();

                    view.GetGlobalVisibleRect(outRect);

                    if(!outRect.Contains((int) ev.RawX, (int) ev.RawY))
                    {
                        HideKeyboard();
                    }
                }
            }

            return base.DispatchTouchEvent(ev);
        }

        private void HideKeyboard()
        {
            if(CurrentFocus == null)
            {
                return;
            }

            var inputMethodManager = (InputMethodManager) GetSystemService(InputMethodService);

            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);
            CurrentFocus.ClearFocus();
        }
    }
}
