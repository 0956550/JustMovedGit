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
    class KostenAdapter : BaseAdapter<Kosten>
    {
        private List<Kosten> kosten;
        private Context mContext;
        private int mtestLayout;

        public KostenAdapter(Context context, List<Kosten> items, int testLayout)
        {
            kosten = items;
            mContext = context;
            mtestLayout = testLayout;
        }

        public override int Count
        {
            get { return kosten.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Kosten this[int position]
        {
            get { return kosten[position]; }
        }

        public Kosten GetKosten(int position)
        {
            return kosten[position];
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mtestLayout, null, false);
            }

            TextView txtNaam = row.FindViewById<TextView>(Resource.Id.txtTitel);
            TextView txtKosten = row.FindViewById<TextView>(Resource.Id.txtSubTitel);
            txtNaam.Text = kosten[position].kosten;
            txtKosten.Text = kosten[position].beschrijving;

            return row;
        }
    }
}