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
    class HuishoudenAdapter : BaseAdapter<Huishouden>
    {
        private List<Huishouden> huishouden;
        private Context mContext;
        private int mtestLayout;

        public HuishoudenAdapter(Context context, List<Huishouden> items, int testLayout)
        {
            huishouden = items;
            mContext = context;
            mtestLayout = testLayout;
        }

        public override int Count
        {
            get { return huishouden.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Huishouden this[int position]
        {
            get { return huishouden[position]; }
        }

        public Huishouden GetHuishouden(int position)
        {
            return huishouden[position];
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mtestLayout, null, false);
            }

            TextView txtTitel = row.FindViewById<TextView>(Resource.Id.txtTitel);
            TextView txtCategorie = row.FindViewById<TextView>(Resource.Id.txtSubTitel);
            txtTitel.Text = huishouden[position].wat;
            txtCategorie.Text = huishouden[position].categorie;
            return row;
        }
    }
}