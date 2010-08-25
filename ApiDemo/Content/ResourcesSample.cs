//
// Copyright (C) 2007 The Android Open Source Project
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;

using Android.App;
using Android.OS;
using Java.Lang;
using Android.Widget;
using Android.Content;

namespace MonoDroid.ApiDemo
{
	public class ResourcesSample : Activity
	{
		public ResourcesSample (IntPtr handle)
			: base (handle)
		{
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (R.layout.resources);

			TextView tv;
			CharSequence cs;
			string str;

			// ====== Using the Context.getString() convenience method ===========

			// Using the GetString() conevenience method, retrieve a string
			// resource that hapepns to have style information.  Note the use of
			// CharSequence instead of String so we don't lose the style info.
			cs = GetText (R.@string.styled_text);
			tv = (TextView)FindViewById (R.id.styled_text);
			tv.Text = cs;

			// Use the same resource, but convert it to a string, which causes it
			// to lose the style information.
			str = GetString (R.@string.styled_text);
			tv = (TextView)FindViewById (R.id.plain_text);
			tv.Text = str;

			// ====== Using the Resources object =================================

			// You might need to do this if your code is not in an activity.
			// For example View has a protected mContext field you can use.
			// In this case it's just 'this' since Activity is a context.
			Context context = this;

			// Get the Resources object from our context
			Android.Content.Res.Resources res = context.Resources;

			// Get the string resource, like above.
			cs = res.GetText (R.@string.styled_text);
			tv = (TextView)FindViewById (R.id.res1);
			tv.Text = cs;

			// Note that the Resources class has methods like getColor(),
			// getDimen(), getDrawable() because themes are stored in resources.
			// You can use them, but you might want to take a look at the view
			// examples to see how to make custom widgets.
		}
	}
}