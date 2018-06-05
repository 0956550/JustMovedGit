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
    class ReceptenAdapter : BaseAdapter<Recept>
    {
        private List<Recept> recepten;
        private Context mContext;
        private int mtestLayout;

        public ReceptenAdapter(Context context, List<Recept> items, int testLayout)
        {
            recepten = items;
            mContext = context;
            mtestLayout = testLayout;
        }

        public override int Count
        {
            get { return recepten.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Recept this[int position]
        {
            get { return recepten[position]; }
        }

        public Recept GetRecept(int position)
        {
            return recepten[position];
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mtestLayout, null, false);
            }

            //LinearLayout layout = row.FindViewById<LinearLayout>(Resource.Id.linearLayout);
            TextView txtNaam = row.FindViewById<TextView>(Resource.Id.txtReceptNaam);
            TextView txtKosten = row.FindViewById<TextView>(Resource.Id.txtReceptKosten);
            txtNaam.Text = recepten[position].naam;
            txtKosten.Text = recepten[position].kosten;

            return row;
        }
    }
}