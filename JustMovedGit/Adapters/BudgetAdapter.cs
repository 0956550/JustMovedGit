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
    class BudgetAdapter : BaseAdapter<Budget>
    {
        private List<Budget> budget;
        private Context mContext;
        private int mtestLayout;

        public BudgetAdapter(Context context, List<Budget> items, int testLayout)
        {
            budget = items;
            mContext = context;
            mtestLayout = testLayout;
        }

        public override int Count
        {
            get { return budget.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Budget this[int position]
        {
            get { return budget[position]; }
        }

        public Budget GetBudget(int position)
        {
            return budget[position];
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mtestLayout, null, false);
            }

            TextView txtTitel = row.FindViewById<TextView>(Resource.Id.txtTitel);
            txtTitel.Text = budget[position].titel;

            return row;
        }
    }
}