using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JustMovedGit.Classes;

namespace JustMovedGit.Adapters
{
    class PlannenAdapter : BaseAdapter<Plannen>
    {
        private List<Plannen> plannen;
        private Context mContext;
        private int mtestLayout;

        public PlannenAdapter(Context context, List<Plannen> items, int testLayout)
        {
            plannen = items;
            mContext = context;
            mtestLayout = testLayout;
        }

        public override int Count
        {
            get { return plannen.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Plannen this[int position]
        {
            get { return plannen[position]; }
        }

        public Plannen GetPlannen(int position)
        {
            return plannen[position];
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mtestLayout, null, false);
            }

            TextView txtTitel = row.FindViewById<TextView>(Resource.Id.txtTitel);
            txtTitel.Text = plannen[position].titel;

            return row;
        }
    }
}